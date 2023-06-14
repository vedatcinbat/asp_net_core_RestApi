namespace HelloWebApi.Models {
    public class Product {
        public int Id {get; set;}
        public string ProductName {get; set;} = String.Empty;
        public string ProductDescription {get; set;} = String.Empty;
        public int Price {get; set;}
    }
}