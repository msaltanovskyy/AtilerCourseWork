using AtilerCourseWork.Data;
using AtilerCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AtilerCourseWork.Controllers
{
    public class MasterController : Controller
    {

        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public MasterController(UserManager<Worker> userManager,
                                SignInManager<Worker> signInManager,
                                ApplicationDbContext context,
                                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListFitting()
        {
            return View(_context.fittings.Where(a => a.Order.workerId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList());
        }

        public async Task<ActionResult> ListOrderMasterAsync()
        {
            var orders = await _context.orders.Include(p => p.Product).Include(w => w.worker).Where(a => a.worker.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync();
            var orders1 = orders;
            return View(orders1);
        }

        public ActionResult ListMeasure()
        {
            var measure = _context.measures.Include(c=>c.Client).ToList();
            return View(measure);
        }

        [HttpGet]
        public ActionResult AddMeasure()
        {
            ViewBag.ClientId = new SelectList(_context.clients, "ClientId", "Surname");
            return View();
        }

        [HttpPost]
        public ActionResult AddMeasure(Measure measure)
        {
            try
            {
                ViewBag.ClientId = new SelectList(_context.clients, "ClientId", "Surname");
                _context.Add(measure);
                _context.SaveChanges();
                return View("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult AddFitting()
        {
            ViewBag.OrderId = new SelectList(_context.orders.Where(a => a.worker.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value), "OrderId", "OrderId");
            return View();
        }
        [HttpPost]
        public ActionResult AddFitting(Fitting fitting)
        {
            try
            {
                ViewBag.OrderId = new SelectList(_context.orders, "OrderId", "OrderId");
                _context.Add(fitting);
                _context.SaveChanges();
                return View("../Home/Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListMaterialProduct()
        {
            
            return View(_context.productMaterials
                .Include(p => p.product)
                .Include(m => m.material)
                .ToList());
        }
        [HttpGet]
        public ActionResult AddProductMaterial()
        {
            ViewBag.OrderId = new SelectList(_context.products, "ProductId", "ProductId");
            return View();
        }
        [HttpPost]
        public ActionResult AddProductMaterial(ProductMaterial productMaterial)
        {
            ViewBag.OrderId = new SelectList(_context.products, "ProductId", "ProductId");
            _context.Add(productMaterial);
            _context.SaveChanges();
            return View("../Home/Index");
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
            return RedirectToAction("ListOrderMaster");

        }

        public async Task<ActionResult> DeleteFitting(int? id)
        {
            var suppliers = await _context.fittings.Include(o => o.Order)
             .FirstOrDefaultAsync(m => m.FittingId == id);
            return View(suppliers);
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteFitting(Fitting fittings, int? id)
        {
            _context.Entry(fittings).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction("ListFitting");
        }
    }
}
