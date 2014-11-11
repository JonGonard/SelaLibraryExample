namespace Sela.LibraryExample.Core.Infrastructure
{
  public class Result
  {
    public Result(bool didSucceed, string error)
    {
      Error = error;
      DidSucceed = didSucceed;
    }

    public bool DidSucceed { get; private set; }

    public string Error { get; private set; }

    public static Result Success()
    {
      return new Result(true, string.Empty);
    }

    public static Result Fail(string error)
    {
      return new Result(false, error);
    }
  }

  public class Result<T> : Result
  {
    public Result(bool didSucceed, T returnValue, string error) : base(didSucceed, error)
    {
      ReturnValue = returnValue;
    }

    public Result(Result result, T returnValue) : this(result.DidSucceed, returnValue, result.Error)
    {
    }

    public T ReturnValue { get; private set; }

    public static Result<T> Success(T returnValue)
    {
      return new Result<T>(true, returnValue, string.Empty);
    }

    public new static Result<T> Success()
    {
      return Success(default(T));
    }

    public new static Result<T> Fail(string error)
    {
      return new Result<T>(false, default(T), error);
    }
  }
}