using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoatsDataGrid.Model
{
    public class ConcreteGoatService : IGoatService
    {
        private readonly List<Goat> _currentGoats;
        private Random _random = new Random();

        public ConcreteGoatService()
        {
            _currentGoats = new List<Goat>();
        }

        public IList<Goat> CreateGoats(int numberGoats)
        {
            var newGoats = new List<Goat>();
            for (int i = 0; i < numberGoats; i++)
            {
                newGoats.Add(new Goat() { Name = "Goat" + (i * DateTime.Now.Millisecond) });
            }

            _currentGoats.AddRange(newGoats);
            return newGoats;
        }
    }
}
