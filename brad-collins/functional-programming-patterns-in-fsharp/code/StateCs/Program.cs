using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCs
{
    public interface IState
    {
        int Gumballs { get; }
        IState InsertQuarter();
        IState EjectQuarter();
        IState Dispense();
    }

    public class NoQuarterState : IState
    {
        public NoQuarterState(int gumballs)
        {
            Gumballs = gumballs;
        }

        public int Gumballs { get; private set; }

        public IState InsertQuarter()
        {
            return new HasQuarterState(Gumballs);
        }

        public IState EjectQuarter()
        {
            return this;
        }

        public IState Dispense()
        {
            return this;
        }
    }

    public class HasQuarterState : IState
    {
        public HasQuarterState(int gumballs)
        {
            Gumballs = gumballs;
        }

        public int Gumballs { get; private set; }

        public IState InsertQuarter()
        {
            return this;
        }

        public IState EjectQuarter()
        {
            return new NoQuarterState(Gumballs);
        }

        public IState Dispense()
        {
            return Gumballs == 1
                ? new SoldOutState() as IState
                : new NoQuarterState(Gumballs - 1);
        }
    }

    public class SoldOutState : IState
    {
        public int Gumballs { get { return 0; } }

        public IState InsertQuarter()
        {
            return this;
        }

        public IState EjectQuarter()
        {
            return this;
        }

        public IState Dispense()
        {
            return this;
        }
    }

    public class GumballMachine
    {
        private IState state;
        public GumballMachine(int gumballs)
        {
            this.state = new NoQuarterState(gumballs);
        }

        public int Gumballs
        {
            get { return state.Gumballs; }
        }
        public void InsertQuarter()
        {
            state = state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            state = state.EjectQuarter();
        }

        public void Dispense()
        {
            state = state.Dispense();
        }

        public override string ToString()
        {
            return $"Gumball Machine with {Gumballs} gumballs";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = new GumballMachine(3);

            machine.InsertQuarter();
            Console.WriteLine($"After Insert Quarter: {machine}");
            machine.Dispense();
            Console.WriteLine($"After Dispense: {machine}");
            machine.InsertQuarter();
            Console.WriteLine($"After Insert Quarter: {machine}");
            machine.EjectQuarter();
            Console.WriteLine($"After Eject Quarter: {machine}");
            machine.Dispense();
            Console.WriteLine($"After Dispense: {machine}");
            machine.InsertQuarter();
            Console.WriteLine($"After Insert Quarter: {machine}");
            machine.Dispense();
            Console.WriteLine($"After Dispense: {machine}");
            machine.InsertQuarter();
            Console.WriteLine($"After Insert Quarter: {machine}");
            machine.Dispense();
            Console.WriteLine($"After Dispense: {machine}");
            machine.InsertQuarter();
            Console.WriteLine($"After Insert Quarter: {machine}");
            machine.Dispense();
            Console.WriteLine($"After Dispense: {machine}");
        }
    }
}
