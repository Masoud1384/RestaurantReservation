using System.Globalization;

namespace DataAccessLayer.Models
{
    public class Address
    {
        public string address { get; set; }
        public string city { get; set; }
        public string phonenumber{ get; set; }

        public Address(string address, string city, string phonenumber)
        {
            this.address = address;
            this.city = city;
            this.phonenumber = phonenumber;
        }
    }
}
