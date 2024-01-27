using System;

namespace DekoraterExtraZadatak
{
   
    public interface IComponent
    {
        void Add();
    }

    
    public class Noodles : IComponent
    {
        public void Add()
        {
            Console.WriteLine("Add Noodles");
        }
    }

    public class Beef : IComponent
    {
        public void Add()
        {
            Console.WriteLine("Add Beef");
        }
    }

    public class Mushrooms : IComponent
    {
        public void Add()
        {
            Console.WriteLine("Add Mushrooms");
        }
    }

    public class Water : IComponent
    {
        public void Add()
        {
            Console.WriteLine("Add Water");
        }
    }

    
    public abstract class Decorator : IComponent
    {
        protected IComponent _component;

        public Decorator(IComponent component)
        {
            _component = component;
        }

        public virtual void Add()
        {
            _component.Add();
        }
    }

    
    public class SaltDecorator : Decorator
    {
        public SaltDecorator(IComponent component) : base(component)
        {
        }

        public override void Add()
        {
            base.Add();
            AddSalt();
        }

        private void AddSalt()
        {
            Console.WriteLine("Add Salt");
        }
    }

  
    public class Meal
    {
        private IComponent _beef;
        private IComponent _mushrooms;
        private IComponent _noodles;
        private IComponent _water;

        public Meal()
        {
            _beef = new Beef();
            _mushrooms = new Mushrooms();
            _noodles = new Noodles();
            _water = new Water();
        }

        public void MakeMushroomNoodleSoup()
        {
            _water.Add();
            _mushrooms.Add();
            _noodles.Add();
        }

        public void MakeBeefNoodleSoup()
        {
            _water.Add();
            _beef.Add();
            _noodles.Add();
        }

        public void MakeMushroomBeefSoup()
        {
            _water.Add();
            _beef.Add();
            _mushrooms.Add();
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            
            IComponent beefWithSalt = new SaltDecorator(new Beef());

            beefWithSalt.Add();
        }
    }
}