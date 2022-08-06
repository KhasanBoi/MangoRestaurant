namespace Mango.Services.ProductApi.Dtos.ProductDtos
{
    public class ResponseProductDto
    {
        public bool Success { get; set; } = true;
        public  object Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> ErrorMessages { get; set; }
    }
}
