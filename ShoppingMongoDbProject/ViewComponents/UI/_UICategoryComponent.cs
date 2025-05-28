using Microsoft.AspNetCore.Mvc;
using MongoDbShopping.Services.CategoryServices;

namespace MongoDbShopping.ViewComponents.UI
{
    public class _UICategoryComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _UICategoryComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}