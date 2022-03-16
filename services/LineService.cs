using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSquare.database;
using GeoSquare.Models;
using GeoSquare.services.interfaces;
using GeoSquare.services.Utils;
using Microsoft.EntityFrameworkCore;

namespace GeoSquare.services
{
    public class LineService : ILineService
    {

        private AppDbContext _Db;
        private ISquareService _squareService;

        public LineService(AppDbContext Db,ISquareService squareService)
        {
            _Db = Db;
            _squareService = squareService;
        }

        public List<Line> FindAllLines()
        {
            
             List<Line> lines = _Db.Lines.ToList();
             return lines;
        }

        public async Task<Line> CalculateLine(Square firstSquare,Square secondSquare)
        {
            double distance = CalculateMethods.calcDistance(firstSquare,secondSquare);

            double inclination = CalculateMethods.calcInclination(firstSquare,secondSquare);

            Line line = new Line()
            {
                Distance = distance,
                Inclination = inclination,
                FirstSquareId = firstSquare.Id,
                SecondSquareId = secondSquare.Id
            };

            await _Db.Lines.AddAsync(line);
            await _Db.SaveChangesAsync();

            return line;
        }
        
    }
}