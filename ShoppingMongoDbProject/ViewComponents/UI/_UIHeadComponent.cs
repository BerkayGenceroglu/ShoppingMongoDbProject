using Microsoft.AspNetCore.Mvc;

namespace MongoDbShopping.ViewComponents.UI
{
    public class _UIHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
