using Business.Abstract;
using Core.Utilities.ElasticSearch;
using Core.Utilities.ElasticSearch.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
           
        }
        [HttpPost("rent")]
        public IActionResult Rent(Rental rental)
        {
            var isCarAvaible = _rentalService.CheckCarIsAvailable(rental.CarId);
            if (isCarAvaible)
            {
                _rentalService.Add(rental);
                return Ok("added");
            }
            return BadRequest("car not available");
        }
        [HttpPost("return")]
        public IActionResult Return(int carId)
        {
            var result = _rentalService.Return(carId);
            return Ok(result.Message);
        }


    } 
}


