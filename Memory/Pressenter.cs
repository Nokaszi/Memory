using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Pressenter
    {
        IView view;
        Model model;
        public Pressenter(IView view, Model model)
        {
            this.view = view;
            this.model = model;
            view.Start += View_puzzle;
            view.Check += View_Check;
            view.Winer += View_win;
        }
        private void View_puzzle()
        {
            view.puzzle = model.randomize();
        }
        private void View_Check()
        {
            if(model.decision(view.firstClick,view.secentClick)==true)
            {
                view.Couple();
            }
        }
        private void View_win()
        {
            if(model.checkwinner()==true)
            {
                view.win(model.suma);
            }
        }
    }
}
