namespace CarSharingAdminService.Models
{
    public interface IDataProvider
    {
        //Cars CRUD
        void CreateCar(Car car);

        List<Car> GetAllCars();

        Car GetCar(int id);

        void UpdateCar(Car car);

        void DeleteCar(int id);

        //Users CRUD
        void CreateUser(User user);

        List<User> GetAllUsers();

        User GetUser(int id);

        void UpdateUser(User user);

        void DeleteUser(int id);

        //Rides CRUD
        void CreateRide(Ride application);

        List<Ride> GetAllRides();

        Ride GetRide(int id);

        void UpdateRide(Ride application);

        void DeleteRide(int id);

    }
}
