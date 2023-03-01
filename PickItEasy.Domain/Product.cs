namespace PickItEasy.Domain
{
    public class Product : EntityBase
    {
        public string? Name { get; set; }
        public bool IsDelete { get; set; }
    }
}
