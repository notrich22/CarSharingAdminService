namespace CarSharingAdminService.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int OdometerInKilometers { get; set; }
        public override string ToString() { return $"{this.Id}) Name: {this.Brand} {this.Model}; Mileage: {this.OdometerInKilometers};"; }

    }
}
