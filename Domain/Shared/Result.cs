namespace The_Project.Domain.Shared
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T? Value { get; }
        public Error Error { get; }

        private Result(bool isSuccess, Error error, T? value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result<T> Success(T value) => new(true, Error.None, value);

        public static Result<T> Failure(Error error) => new(false, error, default);
    }
}
