using System;
using GeoSquare.Models;

namespace GeoSquare.services.Utils
{
    public class CalculateMethods
    {
        public static double calcDistance(Square firstSquare,Square secondSquare)
        {
            double distance = 0;

            double xDistance = Math.Pow((secondSquare.XCenter-firstSquare.XCenter),2);
            double yDistance = Math.Pow((secondSquare.YCenter-firstSquare.YCenter),2);

            distance = Math.Sqrt(xDistance+yDistance);

            return distance;
        }

        public static double calcInclination(Square firstSquare,Square secondSquare)
        {
            double inclination = ((secondSquare.YCenter-firstSquare.YCenter)/(secondSquare.XCenter-firstSquare.XCenter));
            return inclination;
        }
        

    }
}