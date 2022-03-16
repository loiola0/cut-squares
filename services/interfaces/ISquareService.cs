using System.Collections.Generic;
using System.Threading.Tasks;
using GeoSquare.Models;

namespace GeoSquare.services.interfaces
{
    public interface ISquareService
    {
         List<Square> FindAllSquares();
         Square FindSquareById(int? squareId = 1);
         Task Create(SquareRequest squareRequest);
         Task Delete(int squareId);

    }
}