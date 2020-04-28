using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    interface IView
    {
        int How_many { get; set; }
        string[] puzzle { get; set; }
        string firstClick { get; }
        string secentClick { get;  }
        void win(int ile);
        void Couple();
        event Action Check;
        event Action Start;
        event Action Winer;

    }
}
