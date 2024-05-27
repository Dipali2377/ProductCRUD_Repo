namespace ProductCRUD.RequestModels
{
    public class ProductDto
    {
        public int Productid { get; set; }

        public string? Productname { get; set; }

        public string? Productdescription { get; set; }

        public decimal? Price { get; set; }

        public int? Categoryid { get; set; }
    }
}
