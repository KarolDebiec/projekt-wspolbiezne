using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private Vector2 currentVector;
        private Vector2 destinationVector;
        private float speed;
        private int radius;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Ball()
        {
        }

        public Ball(Vector2 vector)
        {
            currentVector = vector;
            radius = 15;
        }

        public Ball(int x, int y, int radius, float speed)
        {
            currentVector.X = x;
            currentVector.Y = y;
            this.radius = radius;
            this.speed = speed;
            System.Random random = new System.Random();
            int edge = random.Next(1, 5);// 4 - down, 1 - right, 3 - up, 2 - left
            if (edge == 1)
            {
                destinationVector.X = Storage.width - this.radius;
                destinationVector.Y = random.Next(this.radius, Storage.height - this.radius);
            }
            else if (edge == 2)
            {
                destinationVector.X = this.radius;
                destinationVector.Y = random.Next(this.radius, Storage.height - this.radius);
            }
            else if (edge == 3)
            {
                destinationVector.Y = Storage.height - this.radius;
                destinationVector.X = random.Next(this.radius, Storage.width - this.radius);
            }
            else
            {
                destinationVector.Y = this.radius;
                destinationVector.X = random.Next(this.radius, Storage.width - this.radius);
            }
        }

        public void generateNewVectorDestination()
        {
            System.Random random = new System.Random();
            int edge; // 4 - down, 1 - right, 3 - up, 2 - left
            if (currentVector.X == radius)
            {
                edge = 2;
            }
            else if (currentVector.X == Storage.width - radius)
            {
                edge = 1;
            }
            else if (currentVector.Y == radius)
            {
                edge = 4;
            }
            else
            {
                edge = 3;
            }
            int destinationWall;
            int wall = random.Next(1, 4);
            if (edge > wall)
            {
                destinationWall = wall;
            }
            else if (wall == 3)
            {
                destinationWall = 4;
            }
            else
                destinationWall = edge + wall;
            float XCoordinate;
            float YCoordinate;
            if (destinationWall < 3)
            {
                YCoordinate = random.Next(radius, Storage.height - radius);
                XCoordinate = (destinationWall % 2) * (Storage.width - 2 * radius) + radius;
            }
            else
            {
                XCoordinate = random.Next(radius, Storage.width - radius);
                YCoordinate = ((destinationWall - 2) % 2) * (Storage.height - 2 * radius) + radius;
            }
            destinationVector.X = XCoordinate;
            destinationVector.Y = YCoordinate;
            double howManyChanges = System.Math.Sqrt((System.Math.Pow(currentVector.X - destinationVector.X, 2) + System.Math.Pow(currentVector.Y - destinationVector.Y, 2))) / speed;

        }

        public void UpdatePosition()
        {
            if (currentVector == destinationVector)
            {
                generateNewVectorDestination();
            }
            double howManyChanges = System.Math.Sqrt((System.Math.Pow(currentVector.X - destinationVector.X, 2) + System.Math.Pow(currentVector.Y - destinationVector.Y, 2))) / speed;
            if (howManyChanges < 1)
            {
                currentVector = destinationVector;
            }
            else
            {
                currentVector.X += (float)((destinationVector.X - currentVector.X) / howManyChanges);
                currentVector.Y += (float)((destinationVector.Y - currentVector.Y) / howManyChanges);
            }
            RaisePropertyChanged(nameof(X));
            RaisePropertyChanged(nameof(Y));
        }

        public Vector2 VectorCurrent
        {
            get => currentVector;
            set => currentVector = value;
        }

        public Vector2 VectorDestination
        {
            get => destinationVector;
            set => destinationVector = value;
        }

        public int Diameter
        {
            get => 2 * radius;
        }

        public float X
        {
            get => currentVector.X;
        }

        public float Y
        {
            get => currentVector.Y;
        }

        public float Speed
        {
            get => speed;
        }
    }
}