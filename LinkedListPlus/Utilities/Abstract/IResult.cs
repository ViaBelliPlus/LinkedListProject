﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public interface IResult
    {
        string Message { get; init; }
        bool Success { get; }
    }
}
