using BigBang_Assessment.Db;
using BigBang_Assessment.Models;
using BigBang_Assessment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BigBang_Assessment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotel;
        public HotelController(IHotel hotel)
        {
            _hotel = hotel;
        }
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return _hotel.GetAll();
        }
        [HttpGet("{id}")]

        public Hotel GetId(int id)
        {
            return _hotel.GetId(id);
        }

        [HttpPost]
        public Hotel Post(Hotel h)
        {
            return _hotel.AddHotel(h);
        }
        [HttpPut]
        public Hotel Put(int id, Hotel h)
        {
            return _hotel.UpdateHotel(id, h);
        }
        [HttpDelete]
        public Hotel Delete(int id)
        {
            return _hotel.DeleteHotel(id);
        }
        [HttpGet("/count/{id}")]
        public ActionResult<object> Count(int id)
        {
            var result = _hotel.CountAvail(id);
            return Ok(result);
        }
        [HttpGet("/room/list")]
        public ActionResult<object> CountList()
        {
            var result = _hotel.RoomList();
            return Ok(result);
        }
        [HttpGet("/filter/{location}")]
        public ActionResult<object> GetHotelsByLocation(string location)
        {
            var hotels = _hotel.GetHotelsByLocation(location.ToLower());
            return Ok(hotels);
        }
    }
}
