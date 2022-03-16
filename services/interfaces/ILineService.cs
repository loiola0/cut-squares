using System.Collections.Generic;
using System.Threading.Tasks;
using GeoSquare.Models;

namespace GeoSquare.services.interfaces
{
    public interface ILineService
    {
        List<Line> FindAllLines();

        Task<Line> CalculateLine(Square firstSquare,Square secondSquare);

    }
}