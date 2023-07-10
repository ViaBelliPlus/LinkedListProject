using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial class ViaList<T>
    {
        private readonly ListType type;
        private readonly ILithe _lithe;
        private readonly IRegular<T> _regular;
        public ViaList()
        {
            if(typeof(T) == typeof(lithe))
            {
                type = ListType.Lithe;
                _lithe=new lithe();
            }
            else if(typeof(T) != typeof(lithe))
            {
                type = ListType.Regular;
                _regular = new Regular<T>();
            }
        }

    }
    public enum ListType
    {
        Regular = 0,
        Lithe = 1
    }
}
