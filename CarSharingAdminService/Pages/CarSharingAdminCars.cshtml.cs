using CarSharingAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarSharingAdminService.Pages
{
    public class CarSharingAdminCarsModel : PageModel
    {
        private static IDataProvider dataProvider = new MSSQLDataProvider();
        public List<Car>? cars = null;
        [BindProperty]
        public Car? newCar { get; set; } = new();
        public void OnGet()
        {
            newCar = null;
            cars = dataProvider.GetAllCarsAsync().Result;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (newCar != null) dataProvider.CreateCarAsync(newCar);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            dataProvider.DeleteCarAsync(id);
            return RedirectToAction("Get");
        }
        public void OnPostView(int id)
        {
            cars = dataProvider.GetAllCarsAsync().Result;
            newCar = dataProvider.GetCarAsync(id).Result;
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid || newCar is null)
            {
                return Page();
            }
            dataProvider.UpdateCarAsync(newCar);
            return RedirectToAction("Get");
        }
    }
}
