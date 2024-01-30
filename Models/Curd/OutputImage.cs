namespace ApiPhoneEcommerce.Models.Curd
{
    public class OutputImage
    {
        public string Urlimg { get; set; }
        public int Position { get; set; } = 1;
        public OutputImage()
        {
            this.Urlimg = "http://localhost:7007/img/LogoApple.png";
            this.Position = 1;
        }

    }

    public class ListOutputImage
    {
        public List<OutputImage> Urlimg { get; set; } = new List<OutputImage>();
        public ListOutputImage() 
        {
            Urlimg = new List<OutputImage>();
        }
    }
}
