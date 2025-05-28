using Microsoft.AspNetCore.Mvc;

namespace MongoDbShopping.ViewComponents.UI
{
    public class _UIScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
