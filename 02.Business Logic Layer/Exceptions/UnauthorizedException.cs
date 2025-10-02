namespace The_Book_Circle._02.Business_Logic_Layer.Exceptions
{
    public class UnauthorizedException:StatusCodeException
    {
        public UnauthorizedException(string message)
            : base(StatusCodes.Status401Unauthorized, message) { }
        
    }
}
