using LinaqSnake.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using System.Windows.Threading;

namespace LinaqSnake.Model
{
    public class Game:BaseModel
    {
        private static DispatcherTimer _timer;
        static Random rand = new Random();
        private double dX= 0;
        private double dY = 0;
        private double _fX= 0;
        public double fX
        {
            get
            {
                return _fX;
            }
            set
            {
                _fX = value;
                RaisePropertyChanged("fX");
            }
        }
        private double _fY = 0;
        public double fY
        {
            get
            {
                return _fY;
            }
            set
            {
                _fY = value;
                RaisePropertyChanged("fY");
            }
        }
        public Game()
        {
            FieldWidth = 640;
            FieldHeight = 512;
            partSize = 16;
            ChangeDirection = new RelayCommand(ChangeDirectionExe);
            init();
        }
        private void init()
        {
            Snake = new SnakeBody(partSize);
            Snake.haveEaten = generateFood;
            Snake.gameOver = gameOver;
            Start();
        }
        private void ChangeDirectionExe(object obj)
        {
            switch (obj.ToString())
            {
                case "Up":
                    dX = 0;
                    if (dY == 0)
                        dY = -16;
                    return;
                case "Down":
                    dX = 0;
                    if (dY == 0)
                        dY = 16;
                    return;
                case "Left":
                    if (dX == 0)
                        dX = -16;
                    dY = 0;
                    return;
                case "Right":
                    if (dX == 0)
                        dX = 16;
                    dY = 0;
                    return;
                default:
                    return;
            }
        }

        public void Start()
        {
            generateFood("", EventArgs.Empty);
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            _timer.Start();
        }
        public ICommand ChangeDirection { get; set; }
        void _timer_Tick(object sender, EventArgs e)
        {
            Snake.MoveForward(dX,dY,fX,fY);
        }
        public double FieldWidth { get; set; }
        public double FieldHeight { get; set; }
        private double partSize { get; set; }

        private SnakeBody _snake;
        public SnakeBody Snake
        {
            get
            {
                return _snake;
            }
            set
            {
                _snake = value;
                RaisePropertyChanged("Snake");
            }
        }
        private void gameOver(object obj, EventArgs args)
        {
            _timer.Stop();
            init();
        }
        private void generateFood(object obj,EventArgs args)
        {
            fX = GetRandomMultiple(16,0, (int)FieldWidth-16);
            fY = GetRandomMultiple(16,0, (int)FieldHeight-16);
        }

        public static int GetRandomMultiple(int divisor, int min, int max)
        {
            if (rand == null)
            {
                rand = new Random();

            }

            if (min > max) //Assert that min is lower than max
            {
                int Temp = max;
                max = min;
                min = Temp;

            }

            int NextRandom = rand.Next(min, max + 1); //Add 1 to Max, because Next always returns one less than the value of Max.

            while (NextRandom % divisor != 0)
            {
                NextRandom = rand.Next(min, max + 1); //Add 1 to Max, because Next always returns one less than the value of Max.

            }

            return NextRandom;

        }
    }
}
