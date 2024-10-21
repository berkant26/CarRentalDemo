using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _carServivce;
        public CarController(ICarService carService)
        {
            _carServivce = carService;
        }

        ///<summary>
        /// Get All Cars
        ///</summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            Console.WriteLine("asdasdsadsa");
            var result = _carServivce.GetAll(null);
            return Ok(result);
        }
        [HttpGet("getdto")]
        public IActionResult GetDto()
        {
            var result = _carServivce.CarDetail();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result  = _carServivce.Add(car);
            return Ok(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            _carServivce.Delete(car);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carServivce.GetById(id);
            if(result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest($"not found id = {id}");
        }
        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carServivce.Update(car);
                return Ok(result.Message);
        }

    }
}
