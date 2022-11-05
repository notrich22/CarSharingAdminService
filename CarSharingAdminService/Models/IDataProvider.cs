namespace CarSharingAdminService.Models
{
    public interface IDataProvider
    {
        //Cars CRUD
        Task CreateCarAsync(Car car);

        Task<List<Car>> GetAllCarsAsync();

        Task<Car> GetCarAsync(int id);

        Task UpdateCarAsync(Car car);

        Task DeleteCarAsync(int id);

        //Users CRUD
        Task CreateUserAsync(User user);

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(int id);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);

        //Rides CRUD
        Task CreateRideAsync(Ride application);

        Task<List<Ride>> GetAllRidesAsync();

        Task<Ride> GetRideAsync(int id);

        Task UpdateRideAsync(Ride application);

        Task DeleteRideAsync(int id);

    }
}
