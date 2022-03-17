namespace TrokaTroka.Api.Models
{
    public class Category : EntityBase
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public Category()
        { }
    }
}