﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial interface IViaList<T>
    {
        public ViaListNode<T> Tail { get; }
        public ViaListNode<T> Head { get; }
        bool IsDecimalTypeList { get; init; }
        bool IsEmpty { get;}
        ViaList<ViaListNode<T>> SearchAll(T value);
        bool SerachFirst(T value);
        IResult AddSort(T Value);
        IResult Sort();
        IEnumerator<T> GetEnumerator();
        bool IsDecimalType(Type type);
        void Validate(object? toValidate);
        void Validate(object? toValidate, object? toValidate2);
    }
}
