namespace CarSharingAdminService.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
        public double DistanceInKilometers { get; set; }
        public double TimeInHours { get; set; }
    }
}
