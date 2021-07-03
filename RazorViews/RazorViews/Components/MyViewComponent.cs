using Microsoft.AspNetCore.Mvc;
using RazorViews.Models;
using RazorViews.Services;
using System;


namespace RazorViews.Components
{
    [ViewComponent(Name ="CustomComponent")]
    public class MyViewComponent:ViewComponent
    {
        private ICustomViewData customViewData;

        public MyViewComponent(ICustomViewData customViewData)
        => this.customViewData = customViewData;

        public IViewComponentResult Invoke(string name)
        {
            var data = customViewData.GetViewData();

            var model = new CatViewModel
            {
                Name = name
            };

            this.ViewBag.FromViewComponent = data;


            return View(model);
        }
    }
}
