namespace _2nd.Model.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; } 
        public bool IsSuccess { get; set; }=true;
        public string message { get; set; } = string.Empty;
    }
}
