using System;
using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete;

public class DataResult<T> : Result, IDataResult<T>
{
    public T Data { get; }
    public DataResult(T data, bool success, string message) : base(success, message)
    {
        Data = data;
    }
    public DataResult(T data, bool success):base(success)
    {
        Data = data;
    }
}
