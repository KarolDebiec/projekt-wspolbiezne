using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        private IList balls;
        private ModelAbstractApi modelLayer = ModelAbstractApi.CreateApi();
        private int width;
        private int height;
        private int number;
        private string text;


        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            modelLayer = modelAbstractApi;
            StartClick = new RelayCommand(() => CreateBalls());
            StopClick = new RelayCommand(() => StopBalls());
            height = modelLayer.Height + 4;
            width = modelLayer.Width + 4;
            balls = modelLayer.CreateBalls(number);
        }

        public ICommand StartClick { get; set; }

        private void CreateBalls()
        {
            modelLayer.CreateBalls(number);
            modelLayer.Moving();
        }

        public ICommand StopClick { get; set; }

        private void StopBalls()
        {
            modelLayer.StopBalls();
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                try
                {
                    int val = System.Int32.Parse(text);
                    if (val > 0 && val <= 20)
                    {
                        number = val;
                    }
                    else
                    {
                        number = 0;
                    }
                    RaisePropertyChanged(nameof(Number));

                }
                catch (System.FormatException)
                {
                    Trace.WriteLine("Text() z viewModel rzucil wyjatek Format");
                    number = 0;
                    RaisePropertyChanged(nameof(Number));
                }
                catch (System.OverflowException)
                {
                    Trace.WriteLine("Text() z viewModel rzucil wyjatek Overflow");
                    number = 0;
                    RaisePropertyChanged(nameof(Number));
                }
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
        }

        public IList Balls
        {
            get
            {
                return balls;
            }
            set
            {
                if (value.Equals(balls))
                    return;
                balls = value;
                RaisePropertyChanged(nameof(Balls));
            }
        }
    }
}