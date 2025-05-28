
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MongoDbShopping.Models;
using MongoDbShopping.Services.ProductServices;
using System.Diagnostics;

namespace MongoDbShopping.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DetailComponent(string id)
        {
            return ViewComponent("_UIProductDetailComponent", new { id = id });
        }

        [HttpGet]
        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _FooterPartial(AdminMailViewModel model)
        {
                if (string.IsNullOrEmpty(model.ReceiverMail))
                {
                    ModelState.AddModelError("", "Lütfen geçerli bir e-posta adresi giriniz.");
                    return View(model); // View'a model gönderilmeli
                }

                model.Subject = "Coza Store";
                model.Message = "Coza Store’da Büyük İndirim Fırsatlarını kaçırmamak için takipte kalın.";

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Coza Store Admin", "cozastore@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress("User", model.ReceiverMail));
                mimeMessage.Subject = model.Subject;

                var bodyBuilder = new BodyBuilder { TextBody = model.Message };
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                try
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("cozastore@gmail.com", "your_app_password");
                    client.Send(mimeMessage);
                }
                catch (Exception ex)
                {
                    var errorModel = new ErrorViewModel
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    };
                    return View("Error", errorModel);
                }
                finally
                {
                    client.Disconnect(true);
                }

                return RedirectToAction("Index");
            }
    }
}
