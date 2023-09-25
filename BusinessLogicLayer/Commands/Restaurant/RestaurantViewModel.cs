namespace BusinessLogicLayer.Commands.Restaurant
{
    public class RestaurantViewModel : CreateRestaurantCommand
    {
        public int id { get; set; }

        public List<ApiLink> links { get; set; }
    }
}
