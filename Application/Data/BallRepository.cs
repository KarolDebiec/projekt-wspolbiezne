using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallRepository
    {
        public List<Ball> balls { get; set; }
        public int BoardSize { get; private set; } = 515;

        public BallRepository()
        {
            balls = new List<Ball>();
        }

        public void CreateBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                balls.Add(new Ball(i + 1));
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
