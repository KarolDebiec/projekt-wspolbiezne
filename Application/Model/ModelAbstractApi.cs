using System.Numerics;
using Logic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int Height { get; }
        public abstract int Width { get; }
        public abstract ObservableCollection<Ball> CreateBalls(int number);
        public abstract void StopBalls();
        public abstract void Moving();
        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        private readonly Storage storage = new Storage();
        public override int Width => Storage.width;
        public override int Height => Storage.height;
        public override void Moving() => storage.Moving();
        public override ObservableCollection<Ball> CreateBalls(int number)
        {
            storage.CreateBalls(number);
            return storage.Balls;
        }

        public override void StopBalls() => storage.StopBalls();

    }
}
