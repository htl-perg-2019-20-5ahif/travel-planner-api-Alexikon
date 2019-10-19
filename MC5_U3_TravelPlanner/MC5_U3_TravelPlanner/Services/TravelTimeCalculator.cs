using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MC5_U3_TravelPlanner.Services
{
    internal class TravelTimeCalculator : ITravelCalculator
    {
        /*private readonly ILogger<AnagramComparer> _logger;

        public TravelTimeCalculator(ILogger<TravelTimeCalculator> logger)
        {
            _logger = logger;
        }*/

        public Departure calculateTravel(string from, string to, string start, List<Travel> travels)
        {
            if (from.Equals(to))
            {
                return null;
            }
            else if (from.Equals("Linz"))
            {
                var travel = travels.FirstOrDefault(i => i.City.Equals(to));

                if (travel == null)
                {
                    return null;
                }

                var time = travel.FromLinz.FirstOrDefault(i => TimeSpan.ParseExact(i.Leave, @"hh\:mm", CultureInfo.InvariantCulture) >= TimeSpan.ParseExact(start, @"hh\:mm", CultureInfo.InvariantCulture));

                if (time == null)
                {
                    return null;
                }

                var depart = new Departure();
                depart.Depart = from;
                depart.Arrive = to;
                depart.DepartureTime = time.Leave;
                depart.ArrivalTime = time.Arrive;

                return depart;
            }
            else if (to.Equals("Linz"))
            {
                var travel = travels.FirstOrDefault(i => i.City.Equals(from));

                if (travel == null)
                {
                    return null;
                }

                var time = travel.ToLinz.FirstOrDefault(i => TimeSpan.ParseExact(i.Leave, @"hh\:mm", CultureInfo.InvariantCulture) >= TimeSpan.ParseExact(start, @"hh\:mm", CultureInfo.InvariantCulture));

                if (time == null)
                {
                    return null;
                }

                var depart = new Departure();
                depart.Depart = from;
                depart.Arrive = to;
                depart.DepartureTime = time.Leave;
                depart.ArrivalTime = time.Arrive;

                return depart;
            }
            else
            {
                var travel1 = travels.FirstOrDefault(i => i.City.Equals(from));

                if (travel1 == null)
                {
                    return null;
                }

                var time1 = travel1.ToLinz.FirstOrDefault(i => TimeSpan.ParseExact(i.Leave, @"hh\:mm", CultureInfo.InvariantCulture) >= TimeSpan.ParseExact(start, @"hh\:mm", CultureInfo.InvariantCulture));

                if (time1 == null)
                {
                    return null;
                }

                var travel2 = travels.FirstOrDefault(i => i.City.Equals(to));

                if (travel2 == null)
                {
                    return null;
                }

                var time2 = travel2.FromLinz.FirstOrDefault(i => TimeSpan.ParseExact(i.Leave, @"hh\:mm", CultureInfo.InvariantCulture) >= TimeSpan.ParseExact(time1.Arrive, @"hh\:mm", CultureInfo.InvariantCulture));

                if (time2 == null)
                {
                    return null;
                }

                var depart = new Departure();
                depart.Depart = from;
                depart.Arrive = to;
                depart.DepartureTime = time1.Leave;
                depart.ArrivalTime = time2.Arrive;

                return depart;
            }
        }
    }
}
