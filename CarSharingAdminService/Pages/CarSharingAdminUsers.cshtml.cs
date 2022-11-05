using CarSharingAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarSharingAdminService.Pages
{
    public class CarSharingAdminUsersModel : PageModel
    {
        private static IDataProvider dataProvider = new MSSQLDataProvider();
        public List<User>? users = null;
        [BindProperty]
        public User? newUser { get; set; } = new();
        public void OnGet()
        {
            newUser = null;
            users = dataProvider.GetAllUsersAsync().Result;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (newUser != null) dataProvider.CreateUserAsync(newUser);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            dataProvider.DeleteUserAsync(id);
            return RedirectToAction("Get");
        }
        public void OnPostView(int id)
        {
            users = dataProvider.GetAllUsersAsync().Result;
            newUser = dataProvider.GetUserAsync(id).Result;
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid || newUser is null)
            {
                return Page();
            }
            dataProvider.UpdateUserAsync(newUser);
            return RedirectToAction("Get");
        }
    }
}
