using System;
using System.Web.Mvc;
using DynamicModel.Models;
using DynamicModel.Binders;

namespace DynamicModel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomPartial(CustomModels model)
        {
            switch (model)
            {
                case CustomModels.CompanyModel:
                    var companyModel = new CompanyModel
                    {
                        CurrentModel = CustomModels.CompanyModel,
                        CreatedBy = "Anna",
                        CreatedDate = DateTime.Now,
                        CompanyName = "Bobs Building Company"
                    };
                    return PartialView(companyModel);

                case CustomModels.UserModel:
                    var userModel = new UserModel
                    {
                        CurrentModel = CustomModels.UserModel,
                        CreatedBy = "Ronald",
                        CreatedDate = DateTime.Now,
                        Firstname = "Sue"
                    };
                    return PartialView(userModel);
            }

            return Content("No such custom view.");
        }

        [HttpPost]
        public ActionResult SubmitPartial([DynamicModelBinder] dynamic model)
        {
            // Our model.ToString() serialises it from the baseModel class
           var serialisedString = model.ToString();
            // do something .. echo it back for demo
           return Content(serialisedString);
        }

    }
}