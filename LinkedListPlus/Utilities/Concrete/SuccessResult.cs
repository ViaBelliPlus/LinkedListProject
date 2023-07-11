using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public class SuccessResult : ISuccessResult
    {
        public string Message { get; init; }
        public bool Success => true;
        public SuccessResult()
        {
            Message = "Başarılı";
        }
        public SuccessResult(string message)
        {
            Message = message;
        }
    }
}
