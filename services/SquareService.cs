using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSquare.database;
using GeoSquare.Models;
using GeoSquare.services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeoSquare.services
{
    public class SquareService : ISquareService
    {
        private AppDbContext _Db;
        public SquareService(AppDbContext Db)
        {
            _Db = Db;
        }

        public List<Square> FindAllSquares()
        {
            var squares =  _Db.Squares.ToList();

            return squares;
        }
        
        public Square FindSquareById(int? squareId = 1)
        {
            
            var squareFound = _Db.Squares.Where(x => x.Id == squareId).SingleOrDefaultAsync();
            var t = squareFound.Result;
            return squareFound.Result;
        }

        public async Task Create(SquareRequest squareRequest)
        {
            Square square = new Square(squareRequest);
            await _Db.Squares.AddAsync(square);
            await _Db.SaveChangesAsync();
        }

        public async Task Delete(int squareId)
        {
            var square = new Square
            {
                Id = squareId
            };

            _Db.Squares.Remove(square);
            await _Db.SaveChangesAsync();
        }

    }
}