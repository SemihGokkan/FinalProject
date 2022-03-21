using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message) //Mesaj ile birlikte göndermek istersek.
        {

        }

        public ErrorResult() : base(false) //Mesaj göndermeden sadece sonuç almak istersek.
        {

        }
    }
}
