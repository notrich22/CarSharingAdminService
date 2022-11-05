using Microsoft.EntityFrameworkCore;

namespace CarSharingAdminService.Models
{
	public class MSSQLDataProvider : IDataProvider
	{
        //TODO: REMOVE ASYNC METHODS
        //Car CRUD
		public async Task CreateCarAsync(Car car) {
            using (var context = new CarSharingDBContext())
            {
                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<Car>> GetAllCarsAsync()
        {
            using (var context = new CarSharingDBContext())
            {
                return await context.Cars.ToListAsync();
            }
        }
        public async Task<Car> GetCarAsync(int id)
        {
            using (var context = new CarSharingDBContext())
            {
                return await context.Cars.FirstAsync(car => car.Id == id);
            }
        }
        public async Task UpdateCarAsync(Car car)
        {
            using (var context = new CarSharingDBContext())
            {
                var CarToUpdate = await context.Cars.FirstAsync(Car => Car.Id == car.Id);
                CarToUpdate.Brand = car.Brand;
                CarToUpdate.Model = car.Model;
                CarToUpdate.OdometerInKilometers = car.OdometerInKilometers;
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteCarAsync(int id)
        {
            using (var context = new CarSharingDBContext())
            {
                context.Cars.Remove(await GetCarAsync(id));
                await context.SaveChangesAsync();
            }
        }
        //User CRUD
        public async Task CreateUserAsync(User user)
        {
            using (var context = new CarSharingDBContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            using (var context = new CarSharingDBContext())
            {
                return await context.Users.ToListAsync();
            }
        }
        public async Task<User> GetUserAsync(int id)
        {
            using (var context = new CarSharingDBContext())
            {
                return await context.Users.FirstAsync(user => user.Id == id);
            }
        }
        public async Task UpdateUserAsync(User user)
        {
            using (var context = new CarSharingDBContext())
            {
                var UserToUpdate = await context.Users.FirstAsync(User => User.Id == user.Id);
                UserToUpdate.UserName = user.UserName;
                UserToUpdate.DateOfBirth = user.DateOfBirth;
                UserToUpdate.DrivingExperienceInYears = user.DrivingExperienceInYears;
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteUserAsync(int id)
        {
            using (var context = new CarSharingDBContext())
            {
                context.Users.Remove(await GetUserAsync(id));
                await context.SaveChangesAsync();
            }
        }
        //Ride CRUD
        public async Task CreateRideAsync(Ride ride)
        {
            using (var context = new CarSharingDBContext())
            {
                await context.Rides.AddAsync(ride);
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<Ride>> GetAllRidesAsync()
        {
            using (var context = new CarSharingDBContext())
            {
                return await context.Rides.ToListAsync();
            }
        }
        public async Task<Ride> GetRideAsync(int id)
        {
            using (var context = new CarSharingDBContext())
            {
                return await context.Rides.FirstAsync(ride => ride.Id == id);
            }
        }
        public async Task UpdateRideAsync(Ride ride)
        {
            using (var context = new CarSharingDBContext())
            {
                var RideToUpdate = await context.Rides.FirstAsync(Ride => Ride.Id == ride.Id);
                RideToUpdate.User = ride.User;
                RideToUpdate.Car = ride.Car;
                RideToUpdate.DistanceInKilometers = ride.DistanceInKilometers;
                RideToUpdate.TimeInHours = ride.TimeInHours;
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteRideAsync(int id)
        {
            using (var context = new CarSharingDBContext())
            {
                context.Rides.Remove(await GetRideAsync(id));
                await context.SaveChangesAsync();
            }
        }
    }
}
