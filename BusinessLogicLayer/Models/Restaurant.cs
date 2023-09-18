using BusinessLogicLayer.Models;

namespace RestaurantReservation
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpeningHours { get; set; }
        public int NumberOfTables { get; set; }
        public Address restaurantInformation { get; set; }
    }
}
