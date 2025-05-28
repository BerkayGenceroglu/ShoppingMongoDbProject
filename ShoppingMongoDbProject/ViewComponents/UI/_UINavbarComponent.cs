using Microsoft.AspNetCore.Mvc;

namespace MongoDbShopping.ViewComponents.UI
{
    public class _UINavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
