using CRUD_application_2.Models;
using CRUD_application_2.Services;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserControllerService _userService;

        public UserController()
        {
            _userService = new UserControllerService();
        }

        // GET: User
        public ActionResult Index()
        {
            var userList = _userService.GetAllUsers();
            return View(userList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User updatedUser)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user, updatedUser);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            _userService.DeleteUser(user);

            return RedirectToAction("Index");
        }
    }
}
