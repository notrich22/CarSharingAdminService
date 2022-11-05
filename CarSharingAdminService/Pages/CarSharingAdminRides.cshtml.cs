using CarSharingAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarSharingAdminService.Pages
{
    public class CarSharingAdminRidesModel : PageModel
    {
        private static IDataProvider dataProvider = new MSSQLDataProvider();
        public List<Ride>? rides = null;
        [BindProperty]
        public Ride? newRide { get; set; } = new();
        [BindProperty]
        public int? newUserId { get; set; } = new();
        [BindProperty]
        public int? newCarId { get; set; } = new();
        public void OnGet()
        {
            newRide = null;
            newCarId = null;
            rides = dataProvider.GetAllRidesAsync().Result;

        }
        public IActionResult OnPost()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            if (newRide != null) {
                newRide.User = dataProvider.GetAllUsersAsync().Result.First(obj => obj.Id == newUserId);
                newRide.Car = dataProvider.GetAllCarsAsync().Result.First(obj => obj.Id == newCarId);
                dataProvider.CreateRideAsync(newRide); 
            }
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            dataProvider.DeleteRideAsync(id);
            return RedirectToAction("Get");
        }
        public void OnPostView(int id)
        {
            rides = dataProvider.GetAllRidesAsync().Result;
            newRide = dataProvider.GetRideAsync(id).Result;
            newUserId = newRide.User.Id;
            newCarId = newRide.Car.Id;
        }

        public IActionResult OnPostEdit()
        {
            if (newRide is null) //!ModelState.IsValid || 
            {
                return Page();
            }
            //TO DO
            newRide.User = dataProvider.GetAllUsersAsync().Result.First(obj => obj.Id == newUserId);
            newRide.Car = dataProvider.GetAllCarsAsync().Result.First(obj => obj.Id == newCarId);
            dataProvider.UpdateRideAsync(newRide);
            return RedirectToAction("Get");
        }
    }
}
