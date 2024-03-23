using APBD3.Enums;

namespace APBD3.Classes
{
    public class Product(
        string name,
        double temperature,
        bool isDangerous,
        ProductCategory productCategory
    )
    {
        private static int _nextId = 0;

        public int Id { get; } = _nextId++;
        public string Name { get; } = name;
        public double Temperature { get; } = temperature;
        public bool IsDangerous { get; } = isDangerous;
        public ProductCategory ProductCategory { get; } = productCategory;
    }
}