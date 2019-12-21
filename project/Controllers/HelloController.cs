using Microsoft.AspNetCore.Mvc;

namespace stable.Controllers {
	public class HelloController : Controller {
		public IActionResult Index () {
			return View ();
		}

		// public string Index()
		// {
		//    return "Hello from controller";
		// }
	}
}