namespace DataAccessLayer.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpeningHours { get; set; }
        public int NumberOfTables { get; set; }
        public Address restaurantInformation { get; set; }

        public Restaurant()
        {
            
        }
        public Restaurant(string name, string openingHours, int numberOfTables, Address restaurantInformation)
        {
            Name = name;
            OpeningHours = openingHours;
            NumberOfTables = numberOfTables;
            this.restaurantInformation = restaurantInformation;
        }
    }
}
