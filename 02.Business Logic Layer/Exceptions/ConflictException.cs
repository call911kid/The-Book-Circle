namespace The_Book_Circle._02.Business_Logic_Layer.Exceptions
{
    public class ConflictException : StatusCodeException
    {
        public ConflictException(string message)
            : base(StatusCodes.Status409Conflict, message) { }
    }
}
