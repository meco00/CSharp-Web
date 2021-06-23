using MUSACA.Data;
using MUSACA.Data.Models;
using MUSACA.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;

using System.Text;


namespace MUSACA.Controllers
{
   public class ProductsController:Controller
    {
        private readonly ApplicationDbContext data;

        public ProductsController(ApplicationDbContext context)
        {
            this.data = context;
        }

        public ActionResult Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel model)
        {
            if (String.IsNullOrEmpty(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Redirect("/Products/Create");
            }

            if (model.Price < 0.01M)
            {
                return this.Redirect("/Products/Create");
            }

       
            //This project is broken


            return this.Redirect("/Products/All");
        }

        public ActionResult All()
        {
            return this.View();
        }
    }
}
