using System;
using APBD3.Enums;
using APBD3.Interfaces;

namespace APBD3.Classes;

public class GasContainer: Container
{
    public GasContainer(
        double weight,
        double volume,
        double depth
        ) : base
        (
            weight,
            volume,
            depth
        )
    {
        SerialNum = $"KON-{_containerTypeSymbol}-{Id}";
    }

    private static char _containerTypeSymbol = 'G';


    public void NotifyDangerousOperation(string message)
    {
        Console.WriteLine(message + " in gas container with id: " + Id);
    }

    public override void LoadContainer(double weightOfProductToLoad, Product productToLoad)
    {
        if (Product != null)
        {
            if (Product.ProductCategory != ProductCategory.Gas)
            {
                NotifyDangerousOperation("attempt to load product with illegal state of matter");
                return;
            }
        }
        base.LoadContainer(weightOfProductToLoad, productToLoad);
    }

    public override void UnloadContainer()
    {
        Product tmpProduct = Product;
        base.UnloadContainer();
        base.LoadContainer(Volume*0.05, tmpProduct);
    }
}