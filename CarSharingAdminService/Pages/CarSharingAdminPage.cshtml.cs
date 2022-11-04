using CarSharingAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarSharingAdminService.Pages
{
    public class CarSharingAdminPageModel : PageModel
    {
        private static IDataProvider dataProvider = new PlugDataRovider();
        public List<User>? users = null;
        public List<Ride>? rides = null;
        public List<Car>? cars = null;
        public string Checked { get; set; }
        public void OnGet()
        {
            users = dataProvider.GetAllUsers();
            rides = dataProvider.GetAllRides();
            cars = dataProvider.GetAllCars();
        }
        public void OnPostDelete()
        {

        }
    }
}
