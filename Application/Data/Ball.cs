using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Data
{
    public class Ball : IObservable<int>
    {
        public int Id { get;}

        public double posX { get; private set; }
        public double posY { get; private set; }

        public int r { get; } = 15;
        public double mass { get; } = 10;

        public double offsetX { get; set; }
        public double offsetY { get; set; }

        internal readonly IList<IObserver<int>> observers;

        private Stopwatch Timer = new Stopwatch();

        public Logger logger;

        private Task BallThread;

        public Ball(int id, Logger log)
        {
            this.Id = id;

            Random random = new Random();

            logger = log;

            observers = new List<IObserver<int>>();

            this.posX = GeneratePos();
            this.posY = GeneratePos();

            this.offsetX = GenerateOffset();
            this.offsetY = GenerateOffset();
        }
        public double GeneratePos()
        {
            Random random = new Random();
            return Convert.ToDouble(random.Next(1, 500));
        }
        public double GenerateOffset()
        {
            Random random = new Random();
            return random.NextDouble() * (5 - 2) + 2;
        }

        public void StartMoving()
        {
            this.BallThread = new Task(MovingBall);
            BallThread.Start();
        }

        public void MovingBall()
        {
            while (true)
            {
                Timer.Restart();
                Timer.Start();
                MovePos();
                BallLog();
                foreach (var observer in observers.ToList())
                {
                    if (observer != null)
                    { 
                        observer.OnNext(Id);
                    }
                }
                System.Threading.Thread.Sleep(5);
                Timer.Stop();
            }
        }

        public void MovePos()
        {
            posX += offsetX;
            posY += offsetY;
        }
        public void BallLog()
        {
            logger.log(this);
        }
        #region provider

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private IList<IObserver<int>> _observers;
            private IObserver<int> _observer;

            public Unsubscriber
            (IList<IObserver<int>> observers, IObserver<int> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        #endregion
    }
}
