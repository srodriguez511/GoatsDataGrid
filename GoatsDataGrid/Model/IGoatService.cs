using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoatsDataGrid.Model
{
    public interface IGoatService
    {
        IList<Goat> CreateGoats(int numberGoats);
    }
}
