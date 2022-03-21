using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult // <T> Generic, hangi tipte istediğimizi programda yazacağız, T her şey olabilir her şey döndürebilir. IResult'taki success ve message de içerebilir.
    {
        T Data { get; }
    }
}
