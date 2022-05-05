using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class Storage
    {
        public static int width = 800;
        public static int height = 400;
        private Generator generator = new Generator();
        private ObservableCollection<Ball> balls = new ObservableCollection<Ball>();
        private List<Task> tasks = new List<Task>();
        CancellationTokenSource tokenSource;
        CancellationToken token;

        public Storage()
        {
        }

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }

        public void RemoveBall(Ball ball)
        {
            balls.Remove(ball);
        }

        public void CreateBalls(int number)
        {
            if (number > 0)
            {
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                for (int i = 0; i < number; i++)
                {
                    Ball ball = generator.GenerateBall();
                    AddBall(ball);
                }
            }

        }

        public void StopBalls()
        {
            if (tokenSource != null && !tokenSource.IsCancellationRequested)
            {
                tokenSource.Cancel();
                tasks.Clear();
                balls.Clear();
            }
        }

        public void Moving() // while its true the balls are moving
        {
            foreach (Ball ball in balls)
            {
                Task task = Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(5);
                        ball.UpdatePosition();
                        try { token.ThrowIfCancellationRequested(); }
                        catch (System.OperationCanceledException) { break; } //Rzuca OperationCanceledException jeżeli jest zgłoszone cancel.
                    }
                });
                tasks.Add(task);
            }
        }

        public Generator Generator
        {
            get => generator;
        }

        public ObservableCollection<Ball> Balls
        {
            get => balls;
        }

        public List<Task> Tasks
        {
            get => tasks;
        }

    }
}