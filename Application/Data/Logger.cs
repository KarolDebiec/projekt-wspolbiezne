using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Logger : IDisposable
    {
        BlockingCollection<string> FirstInFirstOut;
        StreamWriter streamWriter;
        private void endlessLoop()
        {
            try
            {
                foreach (string i in FirstInFirstOut.GetConsumingEnumerable())
                {
                    streamWriter.WriteLine(i);
                }
            }
            finally
            {
                Dispose();
            }

        }

        public Logger(string filename)
        {
            FirstInFirstOut = new BlockingCollection<string>();
            streamWriter = new StreamWriter(filename, false);
            Task.Run(endlessLoop);
        }

        public void log(Ball ball) => FirstInFirstOut.Add(DateTime.Now.ToString("HH:mm:ss ")
                    + " ID: " + ball.Id
                    + " Position.X: "
                    + Math.Round(ball.posX, 4)
                    + " Position.Y: "
                    + Math.Round(ball.posY, 4)
                    + " Velocity.X: " + Math.Round(ball.offsetX, 4)
                    + " Velocity.Y: " + Math.Round(ball.offsetY, 4));

        public void Dispose()
        {
            streamWriter.Dispose();
            FirstInFirstOut.Dispose();
        }
    }
}
