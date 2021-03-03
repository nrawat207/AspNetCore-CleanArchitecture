namespace ApplicationCore.Entities
{
    public class Brand: BaseEntity
    {
        public string Name { get; private set; }
        public Brand(string name)
        {
            Name = name;
        }
    }
}
