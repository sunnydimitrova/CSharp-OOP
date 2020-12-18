using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComputer> Computers => (IReadOnlyCollection<IComputer>)this.computers;
        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;
        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var currentComputer = this.Computers.FirstOrDefault(x => x.Id == computerId);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (currentComputer.Components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                 component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                 component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                 component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                 component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                 component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            currentComputer.AddComponent(component);
            components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.Computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            if (computerType != "DesktopComputer" && computerType != "Laptop")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            if (computerType == "DesktopComputer")
            {
                this.computers.Add(new DesktopComputer(id, manufacturer, model, price));
            }
            else if (computerType == "Laptop")
            {
                this.computers.Add(new Laptop(id, manufacturer, model, price));
            }
            return String.Format(SuccessMessages.AddedComputer, id);
           
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var currentComputer = this.Computers.FirstOrDefault(x => x.Id == computerId);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (currentComputer.Peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance,connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }                       
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            currentComputer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var computersForBuy = computers.OrderByDescending(x => x.OverallPerformance).ThenBy(x => x.Price <= budget);
            var bestComputer = computersForBuy.First();
            if (bestComputer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(bestComputer);
            return bestComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            var currComp = this.Computers.FirstOrDefault(x => x.Id == id);
            if (currComp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            computers.Remove(currComp);
            return currComp.ToString();
            
        }

        public string GetComputerData(int id)
        {
            var currComp = this.Computers.FirstOrDefault(x => x.Id == id);
            if (currComp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
           return currComp.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var currComp = this.Computers.FirstOrDefault(x => x.Id == computerId);
            if (currComp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var component = currComp.Components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException
                    (String.Format
                    (ExceptionMessages.NotExistingComponent, componentType, currComp.GetType().Name, computerId));
            }
            currComp.RemoveComponent(componentType);
            components.Remove(component);
            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var currComp = this.Computers.FirstOrDefault(x => x.Id == computerId);
            if (currComp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var ph = currComp.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (ph == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingPeripheral);
            }
            currComp.RemoveComponent(peripheralType);
            peripherals.Remove(ph);
            return String.Format(SuccessMessages.RemovedComponent, peripheralType, ph.Id);
        }
    }
}
