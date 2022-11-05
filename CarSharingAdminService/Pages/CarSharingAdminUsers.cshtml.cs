using CarSharingAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarSharingAdminService.Pages
{
    public class CarSharingAdminUsersModel : PageModel
    {
        private static IDataProvider dataProvider = new PlugDataRovider();
        public List<User>? users = null;
        [BindProperty]
        public User? newUser { get; set; } = new();
        public void OnGet()
        {
            newUser = null;
            users = dataProvider.GetAllUsers();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (newUser != null) dataProvider.CreateUser(newUser);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            dataProvider.DeleteUser(id);
            return RedirectToAction("Get");
        }
        public void OnPostView(int id)
        {
            users = dataProvider.GetAllUsers();
            newUser = dataProvider.GetUser(id);
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid || newUser is null)
            {
                return Page();
            }
            dataProvider.UpdateUser(newUser);
            return RedirectToAction("Get");
        }
    }
}
