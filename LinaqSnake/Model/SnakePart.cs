using LinaqSnake.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqSnake.Model
{
    public class SnakePart:BaseModel
    {
        public SnakePart( double size)
        { 
            this.Size = size;
        }
        public SnakePart(double x,double y ,double size)
        {
            this.x = x;
            this.y = y;
            this.Size = size;
        }
        private double _x;
        public double x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
               
            }
        }

        private double _y;
        public double y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
               
            }
        }

        public double Size { get; set; }

        internal void Refresh()
        {
            RaisePropertyChanged("x");
            RaisePropertyChanged("y");
        }
    }
}
