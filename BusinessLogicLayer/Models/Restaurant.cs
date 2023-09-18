namespace RestaurantReservation
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Cuisine { get; set; }
        public string OpeningHours { get; set; }
        public int NumberOfTables { get; set; }
    }
}
