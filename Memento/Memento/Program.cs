using System;

namespace MementoImplementation
{
    /// <summary>
    /// Startup Class for the Program
    /// Memento Design Pattern
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main - The entry point into the console application
        /// </summary>
        static void Main()
        {
            // Abstract Scenario
            Console.WriteLine("Abstract Scenario");
            Console.ReadLine();
            Console.WriteLine("Lets set our data to equal 'On' and then store it as a Memento: ");
            Console.ReadLine();

            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.AbstractMemento = o.CreateMemento();

            Console.ReadLine();
            Console.WriteLine("Now lets update the data in the originator to equal 'Off': ");
            Console.ReadLine();

            // Continue changing originator
            o.State = "Off";

            Console.ReadLine();
            Console.WriteLine("I don't like the changes I just made so I want to revert them. Lets do that!");
            Console.ReadLine();

            // Restore saved state
            o.SetMemento(c.AbstractMemento);

            // Wait for user
            Console.ReadKey();
            Console.WriteLine("Now let's see how this might be applied to a real-world scenario.");
            Console.ReadLine();


            // Real World Scenario
            Console.Clear();
            Console.WriteLine("Real World Scenario");
            Console.ReadLine();
            Console.WriteLine("Here is the original information on a potential client I'm going to save using Memento:");
            Console.ReadLine();

            SalesProspect s = new SalesProspect();
            s.Name = "John Smith";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            Console.ReadLine();
            Console.WriteLine("Ok, now saving that info.");

            // Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            Console.ReadLine();
            Console.WriteLine("Let's say my client's contact info changed and budget just increased, so I want to update that information later to this:");
            Console.ReadLine();

            // Continue changing originator
            s.Name = "Jonh Smith";
            s.Phone = "(310) 209-7111";
            s.Budget = 100000.0;

            Console.ReadLine();
            Console.WriteLine("Oh no, I accidentally misspelled my client's name updating their entry.");
            Console.ReadLine();
            Console.WriteLine("I need to restore my previous saved state and try that again. Time to use Memento.");
            Console.ReadLine();

            s.RestoreMemento(m.Memento);

            // Wait for user
            Console.ReadKey();

            Console.WriteLine("Previous informtion has been restored using Memento.");
        }
    }

    /// <summary>
    /// The 'Originator class
    /// </summary>
    class Originator
    {
        private string _state;

        // Property
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        // Creates memento
        public AbstractMemento CreateMemento()
        {
            return (new AbstractMemento(_state));
        }

        // Restores original state
        public void SetMemento(AbstractMemento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    class AbstractMemento
    {
        private string _state;

        // Constructor
        public AbstractMemento(string state)
        {
            this._state = state;
        }

        // Gets or sets state
        public string State
        {
            get { return _state; }
        }
    }

    class Caretaker
    {
        private AbstractMemento _memento;

        // Gets or sets memento
        public AbstractMemento AbstractMemento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }

    /// <summary>
    /// SalesProspect - The 'Originator' class for the Real World example
    /// </summary>
    class SalesProspect
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Console.WriteLine("Name: " + _name);
            }
        }

        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Console.WriteLine("Phone: " + _phone);
            }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                Console.WriteLine("Budget: " + _budget);
            }
        }

        // Stores memento
        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(_name, _phone, _budget);
        }

        // Restores memento
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    class Memento
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Constructor
        public Memento(string name, string phone, double budget)
        {
            this._name = name;
            this._phone = phone;
            this._budget = budget;
        }

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    class ProspectMemory
    {
        private Memento _memento;

        // Property
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
