using AgricultureManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult List()
        {
            var productList1 = new ProductViewModel()
            {
                ProductId = "001",
                ProductName = "蓬萊濕穀"
            };

            var productList2 = new ProductViewModel()
            {
                ProductId = "002",
                ProductName = "秈稻濕穀"
            };

            var productList3 = new ProductViewModel()
            {
                ProductId = "003",
                ProductName = "長糯濕穀"
            };

            var productList4 = new ProductViewModel()
            {
                ProductId = "004",
                ProductName = "圓糯濕穀"
            };
            List<ProductViewModel> products = new List<ProductViewModel>();
            products.Add(productList1);
            products.Add(productList2);
            products.Add(productList3);
            products.Add(productList4);

            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //var productViewModel = new ProductViewModel()
            //{
            //    ProductName = 
            //};

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string id, EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id))
            {

            }

            return View();
        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            //var productViewModel = new ProductViewModel()
            //{
            //    ProductName = 
            //};

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id))
            {

            }

            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            return RedirectToAction("List", "Product");
        }
    }
}