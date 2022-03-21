using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message) //Mesaj ile birlikte göndermek istersek.
        {

        }

        public SuccessResult() : base(true) //Mesaj göndermeden sadece sonuç almak istersek.
        {

        }
    }
}
