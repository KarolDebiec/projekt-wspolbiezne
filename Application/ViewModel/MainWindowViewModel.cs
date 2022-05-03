using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Model;
using ViewModel;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        private IList _balls;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();
        private int _width;
        private int _height;
        private int _number;
        private string _text;


        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {

        }

        public ICommand StartClick { get; set; }

        private void CreateBalls()
        {

        }

        public ICommand StopClick { get; set; }

        private void StopBalls()
        {
            
        }

        public int Height
        {
            get
            {
                return _height;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                try
                {
                    int val = System.Int32.Parse(_text);
                    if (val > 0 && val <= 20)
                    {
                        _number = val;
                    }
                    else
                    {
                        _number = 0;
                    }
                    RaisePropertyChanged(nameof(Number));
                }
                catch (System.FormatException)
                {
                    Trace.WriteLine("Text() z viewModel rzucil wyjatek Format");
                    _number = 0;
                    RaisePropertyChanged(nameof(Number));
                }
                catch (System.OverflowException)
                {
                    Trace.WriteLine("Text() z viewModel rzucil wyjatek Overflow");
                    _number = 0;
                    RaisePropertyChanged(nameof(Number));
                }
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }
        }

        public IList Balls
        {
            get
            {
                return _balls;
            }
            set
            {
                if (value.Equals(_balls))
                    return;
                _balls = value;
                RaisePropertyChanged(nameof(Balls));
            }
        }
    }
}