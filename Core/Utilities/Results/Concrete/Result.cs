using System;
using Core.Utilities.Results.Abstract;


namespace Core.Utilities.Results.Concrete;

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
