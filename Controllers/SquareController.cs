using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSquare.database;
using GeoSquare.Models;
using GeoSquare.services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeoSquare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquareController : ControllerBase
    {
        private ISquareService _squareService;

        public SquareController(ISquareService squareService)
        {
            _squareService = squareService;
        }


        [HttpGet]
        [Route("find/all/squares/")]
        public List<Square> FindSquares()
        {
            List<Square> squares = _squareService.FindAllSquares();
            return squares;
        }

        [HttpPost]
        [Route("find/square/")]
        public Square FindSquare([FromBody] SquareSearchRequest squareRequest)
        {
            try
            {
                var square = _squareService.FindSquareById(squareRequest.Id);
                return square;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("create/square")]
        public async Task<IActionResult> CreateSquare([FromBody] SquareRequest squareRequest)
        {
            try
            {   
                await _squareService.Create(squareRequest);

                return Ok("Square registred");
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }

        [HttpPost]
        [Route("delete/square")]
        public IActionResult DeleteSquareById([FromBody] SquareSearchRequest square)
        {
            try
            {   
                _squareService.Delete(square.Id);
            
                return Ok("Square deleted");
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }

    }
}
