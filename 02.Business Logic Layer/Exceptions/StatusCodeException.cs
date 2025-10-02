using System.Net;

namespace The_Book_Circle._02.Business_Logic_Layer.Exceptions
{
    public class StatusCodeException:Exception
    {
        public int StatusCode { get; }
        public StatusCodeException(int statusCode,string message)
            :base(message)
        {
            StatusCode= statusCode;
        }
    }
    
    
    


}
