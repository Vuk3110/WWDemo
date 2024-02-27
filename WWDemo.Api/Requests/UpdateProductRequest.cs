namespace WWDemo.Api.Requests
{
    public class UpdateProductRequest
    {
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Category { get; set; }
        public string? NewSerialNumber { get; set; }
    }
}
