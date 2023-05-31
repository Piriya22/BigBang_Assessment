using BigBang_Assessment.Models;

namespace BigBang_Assessment.Repository
{
    public interface IHotel
    {
        public IEnumerable<Hotel> GetAll();
        public Hotel GetId(int id);
        public Hotel AddHotel(Hotel h);
        public Hotel UpdateHotel(int id, Hotel h);
        public Hotel DeleteHotel(int id);
        public object CountAvail(int id);
        public object RoomList();
        public object GetHotelsByLocation(string location);
    }
}
