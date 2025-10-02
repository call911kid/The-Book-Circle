using Microsoft.AspNetCore.Http;

namespace The_Book_Circle.Errors
{
    public class ServiceResult
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public int StatusCode { get; }

        protected ServiceResult(bool isSuccess, string error, int statusCode)
        {
            IsSuccess = isSuccess;
            Error = error;
            StatusCode = statusCode;
        }

        public static ServiceResult Success(int statusCode = StatusCodes.Status200OK)
            => new ServiceResult(true, string.Empty, statusCode);

        public static ServiceResult Failure(string error, int statusCode = StatusCodes.Status400BadRequest)
            => new ServiceResult(false, error, statusCode);

        public static ServiceResult<T> Success<T>(T data, int statusCode = StatusCodes.Status200OK)
            => ServiceResult<T>.Success(data, statusCode);

        public static ServiceResult<T> Failure<T>(string error, int statusCode = StatusCodes.Status400BadRequest)
            => ServiceResult<T>.Failure(error, statusCode);
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; }

        private ServiceResult(T data, int statusCode)
            : base(true, string.Empty, statusCode)
        {
            Data = data;
        }

        private ServiceResult(string error, int statusCode)
            : base(false, error, statusCode)
        {
            Data = default!;
        }

        public static ServiceResult<T> Success(T data, int statusCode = StatusCodes.Status200OK)
            => new ServiceResult<T>(data, statusCode);

        public static new ServiceResult<T> Failure(string error, int statusCode = StatusCodes.Status400BadRequest)
            => new ServiceResult<T>(error, statusCode);
    }
}
