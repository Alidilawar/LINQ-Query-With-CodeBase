using LINQwithASP.NETMVC.Context;
using LINQwithASP.NETMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LINQwithASP.NETMVC.Controllers
{
    public class ProductController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: Product
        public ActionResult Index()
        {   
            var products = db.Products.ToList();
            return View(products);
        }

        //OrderByName
        public ActionResult OrderByName()
        {
            var products = from p in db.Products
                           orderby p.Name ascending
                           select p;
            return View(products);
        }

        //OrderByPrice
        public ActionResult OrderByPrice()
        {
            var products = from p in db.Products
                           orderby p.Price ascending
                           select p;
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Product product = db.Products.Find(id);
            
            if (product == null)
            
                return HttpNotFound();
            
            return View(product);
        }

        // GET: Product/Create
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
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Product prod)
        {
            try
            {
                Product product = new Product();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    product = db.Products.Find(id);
                    if (product == null)
                        return HttpNotFound();

                    db.Products.Remove(product);
                    db.SaveChanges();
                   return RedirectToAction("Index");
                }
                return View(product); 

            }
            catch
            {
                return View();
            }
        }
    }
}
