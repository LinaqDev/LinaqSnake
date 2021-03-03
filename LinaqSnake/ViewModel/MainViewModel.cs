using LinaqSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqSnake.ViewModel
{
    public class MainViewModel:BaseModel
    {
        public MainViewModel()
        {

        }
        private Game _mainGame = new Game();
        public Game MainGame
        {
            get
            {
                return _mainGame;
            }
            set
            {
                _mainGame = value;
                RaisePropertyChanged("MainGame");
            }
        }

    }
}
