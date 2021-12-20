using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO_Example.DAL;
using ADO_Example.Models;

namespace ADO_Example.Controllers
{
    public class ProductController : Controller
    {
        Product_DAL _productDAL = new Product_DAL();

        // GET: Product
        public ActionResult Index()
        {
            try
            {
                var productList = _productDAL.GetAllProducts();

                if (productList.Count == 0)
                {
                    TempData["InfoMessage"] = "Currently products not available in the Database.";
                }
                return View(productList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }            
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var productList = _productDAL.GetProductsByID(id).FirstOrDefault();

                if (productList == null)
                {
                    TempData["ErrorMessage"] = "Product details not available with the product Id : " + id;
                    return RedirectToAction("Index");
                }
                return View(productList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                int id = 0;

                if (ModelState.IsValid)
                {
                    id = _productDAL.InsertProducts(product);

                    if (id > 0)
                    {
                        TempData["SuccessMessage"] = "Product details saved successfully.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to insert the product.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var productList = _productDAL.GetProductsByID(id).FirstOrDefault();

                if (productList == null)
                {
                    TempData["ErrorMessage"] = "Product details not available with the product Id : " + id;
                    return RedirectToAction("Index");
                }
                return View(productList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Product/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult UpdateProducts(Product product)
        {
            try
            {
                int id = 0;

                if (ModelState.IsValid)
                {
                    id = _productDAL.UpdateProducts(product);

                    if (id > 0)
                    {
                        TempData["SuccessMessage"] = "Product details updated successfully.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to update the product.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var productList = _productDAL.GetProductsByID(id).FirstOrDefault();

                if (productList == null)
                {
                    TempData["ErrorMessage"] = "Product details not available with the product Id : " + id;
                    return RedirectToAction("Index");
                }
                return View(productList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Product/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                int productid = 0;

                if (ModelState.IsValid)
                {
                    productid = _productDAL.DeleteProducts(id);

                    if (productid > 0)
                    {
                        TempData["SuccessMessage"] = "Product deleted successfully.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to delete the product.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
