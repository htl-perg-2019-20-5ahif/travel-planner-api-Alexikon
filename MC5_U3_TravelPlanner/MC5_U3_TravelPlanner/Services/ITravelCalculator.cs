using System.Collections.Generic;

namespace MC5_U3_TravelPlanner.Services
{
    public interface ITravelCalculator
    {
        Departure calculateTravel(string from, string to, string start, List<Travel> travels);
    }
}
