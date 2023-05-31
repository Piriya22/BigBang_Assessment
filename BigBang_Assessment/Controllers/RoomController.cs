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
    public class RoomController : ControllerBase
    {
        private readonly IRoom room;
        public RoomController(IRoom room)
        {
            this.room = room;
        }
        [HttpGet]
        public IEnumerable<Rooms> Get()
        {

                return room.GetAll();
        }
        [HttpGet("{id}")]

        public Rooms GetId(int id)
        {
            return room.GetId(id);
        }

        [HttpPost]
        public Rooms Post(Rooms r)
        {
            return room.AddRoom(r);
        }
        [HttpPut]
        public Rooms Put(int id, Rooms r)
        {
                return room.UpdateRoom(id, r);
        }
        [HttpDelete]
        public Rooms Delete(int id)
        {
            return room.DeleteRoom(id);

        }
        [HttpGet("Avail/{maxPrice}")]
        public ActionResult<object> GetAvailableRoomsByHotelIdAndPriceRange(int maxPrice)
        {

                return room.GetByPriceRange(maxPrice);
      

        }
        [HttpGet("/room/filter/{aminities}")]
        public ActionResult<object> GetRoomsByType(string aminities)
        {

                var roo = room.GetRoomsByAminities(aminities.ToLower());
                return Ok(roo);
          
        }
    }
}
