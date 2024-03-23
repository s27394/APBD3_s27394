using APBD3.Exceptions;

namespace APBD3.Classes
{
    public abstract class Container (
        double weight,
        double volume,
        double depth
        )

    {
        private static int _nextId = 0;

        public int Id { get; } = _nextId++;
        public string SerialNum { get; protected set; }
        public double Weight { get; private set; } = weight;
        public double LoadWeight { get; private set; }
        public double Volume { get; private set; } = volume;
        public double Depth { get; private set; } = depth;
        public Product Product { get; protected set; } = null;


        public virtual void LoadContainer(double weightOfProductToLoad, Product productToLoad)
        {
            if (Volume < weightOfProductToLoad + LoadWeight)
            {
                throw new OverfillException("overfill happened");
            }

            LoadWeight += weightOfProductToLoad;
            Product = productToLoad;
        }

        public virtual void UnloadContainer()
        {
            Product = null;
            LoadWeight = 0;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(SerialNum)}: {SerialNum}, {nameof(Weight)}: {Weight}, {nameof(LoadWeight)}: {LoadWeight}, {nameof(Volume)}: {Volume}, {nameof(Depth)}: {Depth}";
        }



    }
}