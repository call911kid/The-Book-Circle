namespace The_Book_Circle._02.Business_Logic_Layer.Exceptions
{
    public class NotFoundException : StatusCodeException
    {
        public NotFoundException(string message)
            : base(StatusCodes.Status404NotFound, message) { }
    }
}
