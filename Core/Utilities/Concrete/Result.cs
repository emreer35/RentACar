using System;
using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete;

public class Result : IResult
{
    public bool Success { get; }

    public string Message { get; } = string.Empty;

    public Result(bool success, string message) :this(success)
    {
        Message = message;
    }
    public Result(bool success)
    {
        Success = success;
    }
}
