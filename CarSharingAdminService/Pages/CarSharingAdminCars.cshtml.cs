using CarSharingAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarSharingAdminService.Pages
{
    public class CarSharingAdminCarsModel : PageModel
    {
        private static IDataProvider dataProvider = new PlugDataRovider();
        public List<Car>? cars = null;
        [BindProperty]
        public Car? newCar { get; set; } = new();
        public void OnGet()
        {
            newCar = null;
            cars = dataProvider.GetAllCars();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (newCar != null) dataProvider.CreateCar(newCar);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            dataProvider.DeleteCar(id);
            return RedirectToAction("Get");
        }
        public void OnPostView(int id)
        {
            cars = dataProvider.GetAllCars();
            newCar = dataProvider.GetCar(id);
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid || newCar is null)
            {
                return Page();
            }
            dataProvider.UpdateCar(newCar);
            return RedirectToAction("Get");
        }
    }
}
