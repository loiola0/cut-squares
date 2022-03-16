using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSquare.database;
using GeoSquare.Models;
using GeoSquare.services;
using GeoSquare.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoSquare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartesianPlaneController : ControllerBase
    {

        private ILineService _lineService;
        private ISquareService _squareService;


        public CartesianPlaneController(ILineService lineService,ISquareService squareService)
        {
            _squareService = squareService;
            _lineService = lineService;
        }
        
        
        [HttpGet]
        [Route("/find/all/lines")]
        public List<Line> FindLines()
        {
            try
            {
                var lines = _lineService.FindAllLines();

                return lines;
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }

        [HttpPost]
        [Route("/calcule/line")]
        public async Task<Line> CalculateLineCutSquares([FromBody] SquaresRequest squares)
        {
            try
            {
                var firstSquare = _squareService.FindSquareById(squares.FirstSquareId);
                var secondSquare = _squareService.FindSquareById(squares.SecondSquareId);

                var line = await _lineService.CalculateLine(firstSquare,secondSquare);

                return line;

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

    }
}