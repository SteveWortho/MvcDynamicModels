using System;
using System.Web.Mvc;
using DynamicModel.Models;

namespace DynamicModel.Binders
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class DynamicModelBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new DynamicModelBinder();
        }
    }

    public class DynamicModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var currentModel = controllerContext.HttpContext.Request.Form["CurrentModel"];
            if (currentModel == "CompanyModel")
            {
                Type customModel = typeof(CompanyModel);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, customModel);
            }

            if (currentModel == "UserModel")
            {
                Type customModel = typeof(UserModel);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, customModel);
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}