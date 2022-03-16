

namespace GeoSquare.Models
{
    public class Line
    {

        public int? Id { get;set; }
        public double Distance { get; set; }

        public double Inclination { get; set; }

        public int? FirstSquareId { get; set; }

        public int? SecondSquareId { get; set; }


    }
}