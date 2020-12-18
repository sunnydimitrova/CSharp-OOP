using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer
            (int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override decimal Price =>
            this.Components.Sum(x => x.Price) + this.Peripherals.Sum(x => x.Price) + base.Price;

        public override double OverallPerformance =>
            this.Components.Count == 0
            ? base.OverallPerformance : base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);

        public IReadOnlyCollection<IComponent> Components =>
            (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals =>
            (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.components.Contains(component))
             {
                 throw new ArgumentException
                     (String.Format
                      (ExceptionMessages.ExistingComponent, component, this.GetType().Name, this.Id));
             }
            components.Add(component);           
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Contains(peripheral))
            {
                throw new ArgumentException
                    (String.Format
                     (ExceptionMessages.ExistingPeripheral, peripheral, this.GetType().Name, this.Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count > 0)
            {
                IComponent component = components
                    .FirstOrDefault(x => x.GetType().Name == componentType);
                if (component != null)
                {
                    components.Remove(component);
                    return component;
                }
                else
                {
                    throw new ArgumentException
                        (String.Format
                        (ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
                }
            }
            else
            {
                throw new ArgumentException
                        (String.Format
                        (ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
           
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {

            if (peripherals.Count > 0)
            {
                IPeripheral peripheral = peripherals
                    .FirstOrDefault(x => x.GetType().Name == peripheralType);
                if (peripheral != null)
                {
                    peripherals.Remove(peripheral);
                    return peripheral;
                }
                else
                {
                    throw new ArgumentException
                        (String.Format
                        (ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
                }
            }
            else
            {
                throw new ArgumentException
                        (String.Format
                         (ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine
                ($"Overall Performance: {this.OverallPerformance:f2}." +
                $" Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }
            sb.AppendLine($" Peripherals ({this.Peripherals.Count});" +
                $" Average Overall Performance ({this.Peripherals.Average(x => x.OverallPerformance):f2}):");
            foreach (var ph in peripherals)
            {
                sb.AppendLine($"  {ph}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
