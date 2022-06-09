using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Data
{
    public class BallRepository
    {
        public List<Ball> balls { get; set; }
        public int BoardSize { get; private set; } = 515;

        private Logger logger;

        public BallRepository()
        {
            balls = new List<Ball>();
        }

        public void CreateBalls(int amount)
        {
            logger = new Logger("Logger.log");
            for (int i = 0; i < amount; i++)
            {
                Ball ball = new Ball(i + 1,logger);
                ball.logger = logger;
                balls.Add(ball);
            }
        }
        public void ClearBalls()
        {
            balls.Clear();
        }

        public Ball GetBall(int ballId)
        {
            return balls[ballId - 1];
        }
    }
}
