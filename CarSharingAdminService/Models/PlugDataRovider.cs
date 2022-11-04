namespace CarSharingAdminService.Models
{
    public class PlugDataRovider : IDataProvider
    {
        private static int _carID = 3;
        private static int _userID = 3;
        private static int _rideID = 3;

        private static List<Car> Cars =
            new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Brand="Nissan",
                    Model="Silvia S15",
                    OdometerInKilometers=93769

                },
                new Car()
                {
                    Id = 2,
                    Brand="Lada",
                    Model="Granta Sport",
                    OdometerInKilometers=49964
                },
            };

        private static List<User> Users =
            new List<User>()
            {
                new User()
                {
                    Id = 1,
                    UserName="Aleksandr Vasilyev",
                    DateOfBirth= new DateTime(2004, 8, 26),
                    DrivingExperienceInYears=1

                },
                new User()
                {
                    Id = 2,
                    UserName="Mihail Davydov",
                    DateOfBirth= new DateTime(2003, 7, 13),
                    DrivingExperienceInYears=2

                },
            };

        private static List<Ride> Rides =
            new List<Ride>()
            {
                new Ride()
                {
                    Id = 1,
                    User=Users[1],
                    Car=Cars[1],
                    DistanceInKilometers=20,
                    RideStart= new DateTime(2022, 8, 26, 23, 13, 50),
                    RideEnd= new DateTime(2022, 8, 27, 1, 13, 50)
                },
                new Ride()
                {
                    Id = 2,
                    User=Users[2],
                    Car=Cars[2],
                    DistanceInKilometers=20,
                    RideStart= new DateTime(2022, 8, 26, 23, 13, 50),
                    RideEnd= new DateTime(2022, 8, 27, 1, 13, 50)
                },
            };
        public PlugDataRovider(){}
        public void CreateCar(Car car) {
            car.Id = _carID++;
            Cars.Add(car);
        }

        public List<Car> GetAllCars() { 
            return Cars;
        }

        public Car GetCar(int id){
            return Cars[id];
        }

        public void UpdateCar(Car car){
            var Car = GetCar(car.Id);
            Car.Brand = car.Brand;
            Car.Model = car.Model;
            Car.OdometerInKilometers = car.OdometerInKilometers;
        }

        public void DeleteCar(int id){
            Cars.Remove(GetCar(id));
        }

        //Users CRUD
        public void CreateUser(User user){
            user.Id = _userID++;
            Users.Add(user);
        }

        public List<User> GetAllUsers(){
            return Users;
        }

        public User GetUser(int id){
            return Users[id];
        }

        public void UpdateUser(User user){
            var User = GetUser(user.Id);
            User.UserName = user.UserName;
            User.DateOfBirth = user.DateOfBirth;
            User.DrivingExperienceInYears = user.DrivingExperienceInYears;
        }

        public void DeleteUser(int id){
            Users.Remove(GetUser(id));
        }

        //Rides CRUD
        public void CreateRide(Ride ride){
            ride.Id = _rideID++;
            Rides.Add(ride);
        }

        public List<Ride> GetAllRides(){
            return Rides;
        }

        public Ride GetRide(int id){
            return Rides[id];
        }

        public void UpdateRide(Ride ride){
            var Ride = GetRide(ride.Id);
            Ride.RideStart = ride.RideStart;
            Ride.Car = ride.Car;
            Ride.RideEnd = ride.RideEnd;
            Ride.User = ride.User;
            Ride.DistanceInKilometers = ride.DistanceInKilometers;
        }

        public void DeleteRide(int id){
            Rides.Remove(GetRide(id));
        }
    }
}
