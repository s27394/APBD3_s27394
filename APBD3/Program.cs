using System;
using APBD3.Classes;
using APBD3.Enums;

namespace APBD3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // testing liquid containers
            Product milk = new Product("Milk", 4.0, false, ProductCategory.Liquid);
            LiquidContainer liquidContainer1 = new LiquidContainer(10.0, 20.0, 30.0);

            // correct
            liquidContainer1.LoadContainer(12, milk);
            Console.WriteLine(liquidContainer1);

            // correct - adding some new
            liquidContainer1.LoadContainer(3, milk);
            Console.WriteLine(liquidContainer1);


            //over 90%
            liquidContainer1.LoadContainer(4, milk);
            Console.WriteLine(liquidContainer1);

            // correct unload
            liquidContainer1.UnloadContainer();
            Console.WriteLine(liquidContainer1);


            Product gasoline = new Product("Gasoline", 25.0, true, ProductCategory.Liquid);

            // illegal dangerous operation
            liquidContainer1.LoadContainer(15, gasoline);
            Console.WriteLine(liquidContainer1);


            Product propane = new Product("Propane", 20.0, true, ProductCategory.Gas);
            GasContainer gasContainer1 = new GasContainer(15.0, 25.0, 35.0);

            // correct
            gasContainer1.LoadContainer(10, propane);
            Console.WriteLine(gasContainer1);

            // correct unload
            gasContainer1.UnloadContainer();
            Console.WriteLine(gasContainer1);

            // illegal dangerous operation
            gasContainer1.LoadContainer(30, propane);
            Console.WriteLine(gasContainer1);

            // correct - loading after unloading
            gasContainer1.LoadContainer(12, propane);
            Console.WriteLine(gasContainer1);




            Product apples = new Product("Apples", -10.0, false, ProductCategory.Solid);
            RefrigeratedContainer refrigeratedContainer1 = new RefrigeratedContainer(15.0, 30.0, 40.0, 0.0);

            // correct
            refrigeratedContainer1.LoadContainer(10, apples);
            Console.WriteLine(refrigeratedContainer1);

            // incorrect - loading a product requiring lower temperature
            Product iceCream = new Product("Ice Cream", 10.0, false, ProductCategory.Solid);
            refrigeratedContainer1.LoadContainer(5, iceCream);
            Console.WriteLine(refrigeratedContainer1);

            // incorrect - loading over 90% - overfill exception
            // refrigeratedContainer1.LoadContainerShip(50, apples);
            Console.WriteLine(refrigeratedContainer1);

            // correct unload
            refrigeratedContainer1.UnloadContainer();
            Console.WriteLine(refrigeratedContainer1);



            ContainerShip containerShip = new ContainerShip(30, 12, 2);
            containerShip.LoadContainerShip(refrigeratedContainer1);
            Console.WriteLine(containerShip);

            containerShip.LoadContainerShip(gasContainer1);

            containerShip.ReplaceContainer("KON-C-2", liquidContainer1);
        }
    }
}