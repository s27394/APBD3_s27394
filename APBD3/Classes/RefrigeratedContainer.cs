using System;
using APBD3.Enums;

namespace APBD3.Classes;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; private set; }

    public RefrigeratedContainer(
        double weight,
        double volume,
        double depth,
        double temperature
        ) : base
        (
            weight,
            volume,
            depth
        )
    {
        Temperature = temperature;
        SerialNum = $"KON-{_containerTypeSymbol}-{Id}";
    }

    private static char _containerTypeSymbol = 'C';


    public override void LoadContainer(double weightOfProductToLoad, Product productToLoad)
    {
        if (Product != null)
        {
            if (Product.ProductCategory != ProductCategory.Solid)
            {
                Console.WriteLine("attempt to load product with illegal state of matter");
                return;
            }
        }
        if (Temperature < productToLoad.Temperature)
        {
            Console.WriteLine("Attempt to insert product which needs higher temperature.");
            return;
        }
        base.LoadContainer(weightOfProductToLoad, productToLoad);
    }
}