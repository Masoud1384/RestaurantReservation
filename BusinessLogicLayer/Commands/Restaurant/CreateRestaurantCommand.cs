using DataAccessLayer.Models;

namespace BusinessLogicLayer.Commands.Restaurant
{
    public class CreateRestaurantCommand
    {
        public string Name { get; set; }
        public string OpeningHours { get; set; }
        public int NumberOfTables { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string phonenumber { get; set; }
    }
}
