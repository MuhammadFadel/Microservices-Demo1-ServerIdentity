namespace Demo1Api.DTOs
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }        
        public List<string> ErrorMessage { get; set; }
    }
}
