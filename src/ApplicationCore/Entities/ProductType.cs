namespace ApplicationCore.Entities
{
    public class ProductType : BaseEntity
    {
        public string Type { get; private set; }
        public ProductType(string type)
        {
            Type = type;
        }
    }
}
