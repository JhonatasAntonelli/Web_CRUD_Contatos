using Microsoft.AspNetCore.Mvc;

namespace Web_CRUD_Contatos.Controllers
{
    public class ModalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
