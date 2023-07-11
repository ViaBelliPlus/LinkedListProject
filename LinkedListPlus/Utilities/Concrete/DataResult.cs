using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Result { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public bool Success { get; init; }
        public DataResult(T value,bool success = true)
        {
            Result = value;
            Success = success;
        }
        public DataResult(T value,string message ,bool success = true):this(value,success)
        {
            Message = message;
        }
    }
}
