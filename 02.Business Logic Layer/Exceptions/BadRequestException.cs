namespace The_Book_Circle._02.Business_Logic_Layer.Exceptions
{
    public class BadRequestException : StatusCodeException
    {
        public BadRequestException(string message)
            : base(StatusCodes.Status400BadRequest, message) { }

    }
}
