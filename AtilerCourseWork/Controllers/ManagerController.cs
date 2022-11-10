using AtilerCourseWork.Data;
using AtilerCourseWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AtilerCourseWork.Controllers
{
    public class ManagerController : Controller
    {

        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManagerController(UserManager<Worker> userManager,
                                SignInManager<Worker> signInManager, 
                                ApplicationDbContext context,
                                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListClient()
        {
           return View(_context.clients.ToList());
        }
        public ActionResult ListOrder()
        {
            var orders = _context.orders.
                Include(c => c.Client).
                Include(w => w.worker)
                .Include(p => p.Product).ToList();
            return View(orders);
        }
        public ActionResult ListWorker()
        {
            var worker = _context.workers.ToList();
            return View(worker);
        }
        
        public ActionResult ListRole()
        {
            var role = _roleManager.Roles.ToList();
            return View(role);
        } 

        public ActionResult ListSuppliers()
        {
            var suppliers = _context.suppliers.ToList();
            return View(suppliers);
        }

        [HttpGet]
        public ActionResult AddSuppliers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSuppliers(Suppliers suppliers)
        {
            _context.suppliers.Add(suppliers);
            _context.SaveChanges();
            return View("../Home/Index");
        }

        [HttpGet]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            try
            {
                _context.clients.Add(client);
                _context.SaveChanges();
                return View("../Home/Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddOrder()
        {
            ViewBag.Worker = new SelectList(_userManager.Users, "Id", "Name");
            ViewBag.Client = new SelectList(_context.clients, "ClientId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            ViewBag.Client = new SelectList(_context.clients, "ClientId", "Name");
            ViewBag.Worker = new SelectList(_userManager.Users, "Id", "Name");
            try
            {
                _context.Add(order);
                _context.SaveChanges();
                return View("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditWorker(string ?id)
        {

            Worker worker = _context.workers.Find(id);

            if (worker == null)
            {
                return View();
            }
            return View(worker);
        }
        public ActionResult ClientEdit(int? id)
        {

            Client client = _context.clients.Find(id);

            if (client == null)
            {
                return View();
            }
            return View(client);
        }
        public ActionResult SuppliersEdit(int? id)
        {

            Suppliers suppliers = _context.suppliers.Find(id);

            if (suppliers == null)
            {
                return View();
            }
            return View(suppliers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientEdit(Client client)
        {
            try
            {
                _context.Entry(client).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ListClient");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuppliersEdit(Suppliers suppliers)
        {
            try
            {
                _context.Entry(suppliers).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ListSuppliers");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ChangeStatus(int? id)
        {
            Order order = _context.orders
                .Include(p => p.Product)
                .Include(c => c.Client)
                .Include(w => w.worker)
                .FirstOrDefault(o => o.OrderId == id);
            ViewBag.Worker = new SelectList(_userManager.Users, "Id", "Name");
            ViewBag.Client = new SelectList(_context.clients, "ClientId", "Name");
            return View(order);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeStatus(Order order)
        {
            ViewBag.Worker = new SelectList(_userManager.Users, "Id", "Name");
            ViewBag.Client = new SelectList(_context.clients, "ClientId", "Name");
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("ListOrder");
            
        }

        // GET: ManagerController/Delete/5
        public ActionResult DeleteSuppliersAsync(int? id)
        {
            Suppliers suppliers = _context.suppliers.Find(id);
            return View(suppliers);
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSuppliersAsync(Suppliers suppliers, int? id)
        {
            _context.Entry(suppliers).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction("ListSuppliers");
        }
    }
}
