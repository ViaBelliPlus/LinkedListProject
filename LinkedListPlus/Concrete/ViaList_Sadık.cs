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
        public ViaList()
        {
            if(typeof(T) == typeof(lithe))
            {
                type = ListType.Lithe;
            }
            else if(typeof(T) != typeof(lithe))
            {
                type = ListType.Regular;
            }
        }
    }
    public enum ListType
    {
        Regular = 0,
        Lithe = 1
    }
}
