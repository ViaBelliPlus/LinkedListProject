﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public interface ILithe : IViaList
    {
        void AddFirst(object value);
        void Remove(object value);
    }
}