using LinaqSnake.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqSnake.Model
{
    public class SnakeBody : BaseModel
    {
        public EventHandler<EventArgs> haveEaten;
        public EventHandler<EventArgs> gameOver;
        public SnakeBody(double partSize)
        {
            InitSnake();
        }


        private ObservableCollection<SnakePart> _body = new ObservableCollection<SnakePart>();
        public ObservableCollection<SnakePart> Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
                RaisePropertyChanged("Body");
            }
        }
        private double headX = 10 * 16;
        private double headY = 16 * 20;
        private void InitSnake()
        {
            Body.Add(new SnakePart(headX, headY, 16));
        }
        public void MoveForward(double dX, double dY, double fX, double fY)
        {
            for (int i = Body.Count - 1; i >= 0; i--)
            {
                if (i - 1 >= 0)
                {
                    Body[i].x = Body[i - 1].x;
                    Body[i].y = Body[i - 1].y;
                }
                else
                {
                    Body[i].x += dX;
                    Body[i].y += dY;
                }
            }
            if (Body[0].x == fX && Body[0].y == fY)
            {
                haveEaten("", EventArgs.Empty);
                Body.Add(new SnakePart(Body[0].x, Body[0].y, 16));
            }else
            if (checkIfHitedSelf())
            {
                gameOver("", EventArgs.Empty);
            }
            foreach (var item in Body)
            {
                item.Refresh();
            }
        }

        private bool checkIfHitedSelf()
        {
            if (Body.Where(x => x.x == Body[0].x && x.y == Body[0].y).Count() > 1  )
            {
                return true;
            }

            return false;
        }
    }
}
