using CarSharingAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarSharingAdminService.Pages
{
    public class CarSharingAdminRidesModel : PageModel
    {
        private static IDataProvider dataProvider = new PlugDataRovider();
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
            rides = dataProvider.GetAllRides();

        }
        public IActionResult OnPost()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            if (newRide != null) {
                newRide.User = dataProvider.GetAllUsers().First(obj => obj.Id == newUserId);
                newRide.Car = dataProvider.GetAllCars().First(obj => obj.Id == newCarId);
                dataProvider.CreateRide(newRide); 
            }
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            dataProvider.DeleteRide(id);
            return RedirectToAction("Get");
        }
        public void OnPostView(int id)
        {
            rides = dataProvider.GetAllRides();
            newRide = dataProvider.GetRide(id);
            newUserId = newRide.User.Id;
            newCarId = newRide.Car.Id;
        }

        public IActionResult OnPostEdit()
        {
            if (newRide is null) //!ModelState.IsValid || 
            {
                return Page();
            }
            newRide.User = dataProvider.GetAllUsers().First(obj => obj.Id == newUserId);
            newRide.Car = dataProvider.GetAllCars().First(obj => obj.Id == newCarId);
            dataProvider.UpdateRide(newRide);
            return RedirectToAction("Get");
        }
    }
}
