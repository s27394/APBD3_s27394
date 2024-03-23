using System;
using System.Collections.Generic;
using System.Linq;

namespace APBD3.Classes;

public class ContainerShip
{
    private List<Container> _containers = new List<Container>();
    private double _maxWeight;
    private double _maxSpeed;
    private int _maxContainers;

    public ContainerShip(double maxWeight, double maxSpeed, int maxContainers)
    {
        _maxWeight = maxWeight;
        _maxSpeed = maxSpeed;
        _maxContainers = maxContainers;
    }


    public void LoadContainerShip(Container container)
    {
        if (_containers.Sum(c => c.Weight+c.LoadWeight) + container.Weight+container.LoadWeight > _maxWeight)
        {
            Console.WriteLine("Exceeded maximum weight capacity of the ship.");
            return;
        }

        if (_containers.Count >= _maxContainers)
        {
            Console.WriteLine("Exceeded maximum number of containers on the ship.");
            return;
        }

        _containers.Add(container);
    }

    public void UnloadContainer(Container container)
    {
        _containers.Remove(container);
    }

    public void ReplaceContainer(string serialNum, Container newContainer)
    {
        Container oldContainer = null;
        foreach (var container in _containers)
        {
            if (container.SerialNum.Equals(serialNum))
            {
                oldContainer = container;
                break;
            }
        }

        if (oldContainer != null)
        {
            if (newContainer.Weight > _maxWeight - (_containers.Sum(c => c.Weight) - oldContainer.Weight))
            {
                Console.WriteLine("Exceeded maximum weight capacity of the ship.");
                return;
            }

            _containers.Remove(oldContainer);
            _containers.Add(newContainer);
        }
        else
        {
            Console.WriteLine("This container number was not found on this ship. Cannot replace it.");
        }
    }

    public override string ToString()
    {
        return $"{nameof(_containers)}: {_containers}, {nameof(_maxWeight)}: {_maxWeight}, {nameof(_maxSpeed)}: {_maxSpeed}, {nameof(_maxContainers)}: {_maxContainers}";
    }
}