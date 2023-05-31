using BigBang_Assessment.Db;
using BigBang_Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBang_Assessment.Repository
{
    public class RoomRepo:IRoom
    {
        private readonly HotelContext context;
        public RoomRepo(HotelContext context)
        {
            this.context = context;
        }

        public Rooms DeleteRoom(int id)
        {
            Rooms? ro = context.Rooms.FirstOrDefault(x => x.Room_No == id);
            if (ro != null)
            {
                context.Remove(ro);
                context.SaveChanges();
            }
            return ro;
        }

        public Rooms GetId(int id)
        {
            return context.Rooms.FirstOrDefault(x => x.Room_No == id);
        }

        public IEnumerable<Rooms> GetAll()
        {
            return context.Rooms.ToList();
        }

        public Rooms AddRoom(Rooms r)
        {
            context.Add(r);
            context.SaveChanges();
            return r;
        }

        public Rooms UpdateRoom(int id, Rooms r)
        {
            context.Entry(r).State = EntityState.Modified;
            context.SaveChanges();
            return r;
        }
        public object GetByPriceRange(int maxPrice)
        {
            return context.Rooms.Where(room => room.Room_Status == "Available" && room.Cost < maxPrice).ToList();
        }
        public object GetRoomsByAminities(string aminities)
        {
            return context.Rooms.Where(room => room.Aminities != null && room.Aminities.ToLower() == aminities).ToList();
        }
    }
}
