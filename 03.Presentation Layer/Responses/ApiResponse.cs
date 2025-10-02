namespace The_Book_Circle.DTOs
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
