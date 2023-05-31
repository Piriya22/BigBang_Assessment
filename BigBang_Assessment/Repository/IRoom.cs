using BigBang_Assessment.Models;

namespace BigBang_Assessment.Repository
{
    public interface IRoom
    {
        public IEnumerable<Rooms> GetAll();
        public Rooms GetId(int id);
        public Rooms AddRoom(Rooms r);
        public Rooms UpdateRoom(int id, Rooms r);
        public Rooms DeleteRoom(int id);
        public object GetByPriceRange(int maxPrice);
        public object GetRoomsByAminities(string aminities);
    }
}
