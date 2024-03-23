using System;
using APBD3.Enums;
using APBD3.Exceptions;
using APBD3.Interfaces;

namespace APBD3.Classes;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(
        double weight,
        double volume,
        double depth
        ) : base(weight, volume, depth)
    {
        SerialNum = $"KON-{_containerTypeSymbol}-{Id}";
    }

    private static char _containerTypeSymbol = 'L';

    public override void LoadContainer(double weightOfProductToLoad, Product productToLoad)
    {
        if (Product != null)
        {
            if (Product.ProductCategory != ProductCategory.Liquid)
            {
                NotifyDangerousOperation("attempt to load product with illegal state of matter");
                return;
            }
        }
        if (productToLoad.IsDangerous && Volume * 0.5 < LoadWeight + weightOfProductToLoad)
        {
            NotifyDangerousOperation("attempt to load over 50% volume using dangerous product");
            return;
        }

        if (Volume*0.9 < LoadWeight + weightOfProductToLoad)
        {
            NotifyDangerousOperation("attempt to load over 90% volume");
            return;
        }

        base.LoadContainer(weightOfProductToLoad, productToLoad);
    }

    public void NotifyDangerousOperation(string message)
    {
        Console.WriteLine(message + " in liquid container with id: " + Id);
    }
}