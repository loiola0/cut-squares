using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeoSquare.Models
{
    public class Square
    {
        public int? Id { get; set;}

        public int x1 { get; set;}

        public int y1 { get; set;}

        public int x2 { get; set;}

        public int y2 { get; set;}

        public double XCenter { get; set;}

        public double YCenter { get; set;}

        public Square(){}

        public Square(SquareRequest square)
        {
            this.x1 = square.x1;
            this.y1 = square.y1;
            this.x2 = square.x2;
            this.y2 = square.y2;

            this.XCenter = (this.x1+this.x2)/2;
            this.YCenter = (this.y1+this.y2)/2;
        }
    }
}