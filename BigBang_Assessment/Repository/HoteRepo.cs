using BigBang_Assessment.Db;
using Microsoft.EntityFrameworkCore;
using BigBang_Assessment.Models;

namespace BigBang_Assessment.Repository
{
    public class HoteRepo : IHotel
    {
        private readonly HotelContext context;
        public HoteRepo(HotelContext context)
        {
            this.context = context;
        }
        public Hotel DeleteHotel(int id)
        {
            if (context.Hotels == null)
            {
                throw new Exception("Not able to get the details");
            }
            var hot = context.Hotels.Find(id);
            if (hot == null)
            {
                throw new Exception("Not able to get the details");
            }
            context.Hotels.Remove(hot);
            context.SaveChanges();
            return null;
        }

        public Hotel GetId(int id)
        {
            try
            {
                return context.Hotels.FirstOrDefault(x => x.Hotel_Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to get the details" + ex.Message);
            }
        }

        public IEnumerable<Hotel> GetAll()
        {
            try
            {
                return context.Hotels.Include(x => x.Rooms).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to get the details" + ex.Message);
            }
        }

        public Hotel AddHotel(Hotel h)
        {
            try
            {
                context.Add(h);
                context.SaveChanges();
                return h;
            }

            catch (Exception ex)
            {
                throw new Exception("Not able to get the details" + ex.Message);
            }
        }

        public Hotel UpdateHotel(int id, Hotel h)
        {
            try
            {
                context.Entry(h).State = EntityState.Modified;
                context.SaveChanges();
                return h;
            }

            catch (DbUpdateException ex)
            {
                throw new Exception("Not able to get the details" + ex.Message);
            }
        }

        public object CountAvail(int id)
        {
            try
            {
                int c = context.Rooms.Count(room => room.Hotel_Id == id && room.Room_Status == "Available");
                var result = new { Count = c + " Rooms available in " + id };
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to get the details" + ex.Message);
            }
        }
        public object RoomList()
        {
            try
            {
                var list = context.Rooms.Select(a => new { a.Hotel.Hotel_Name, a.Room_No }).ToList();
                int count = context.Rooms.Count();
                var result = new { Count = count + " Rooms and their details ;", Hotels = list };
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to get the details" + ex.Message);
            }
        }
        public object GetHotelsByLocation(string location)
        {
            try
            {
                return context.Hotels.Where(hotel => hotel.Hotel_Location.ToLower() == location).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to get the details" + ex.Message);
            }

        }

    }
}
