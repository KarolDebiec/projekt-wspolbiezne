using System;


namespace Logic
{
    public class Generator
    {
        private Random generator = new Random();
        private int xPos;
        private int yPos;
        private int radius = 15;
        private float speed = 1f;

        public Generator() { }

        public void GeneratePos()
        {
            this.X = generator.Next(2 + radius, Storage.width - radius - 2);
            this.Y = generator.Next(2 + radius, Storage.height - radius - 2);
        }

        public Ball GenerateBall()
        {
            GeneratePos();
            return new Ball(X, Y, Radius, Speed);
        }

        public int X
        {
            get => xPos;
            set => xPos = value;
        }

        public int Y
        {
            get => yPos;
            set => yPos = value;
        }

        public int Radius
        {
            get => radius;
            set => radius = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
    }
}