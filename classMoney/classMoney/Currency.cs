using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace classMoney
{
    class Currency
    {
        double money;
        int from, to;

        public Currency(double _money, int _from, int _to)
        {
            this.money = _money;
            this.from = _from;
            this.to = _to;
        }

       public double getMoney()
        {
            switch (from)
            {
                case 0: switch (to) 
                {
                    case 1: money *= 0.025; break; //гривні-долари
                    case 2: money *= 0.024; break; //гривні-евро
                } break;

                case 1: switch (to)
                    {
                        case 0: money *= 39.22; break; //долари-гривні
                        case 2: money *= 0.93; break; //долари-евро
                    } break;

                case 2: switch (to)
                    {
                        case 0: money *= 42.02; break; //евро-гривні
                        case 1: money *= 1.07; break; //евро-долари
                    } break;
            }
            return money;
        }
    }
}
