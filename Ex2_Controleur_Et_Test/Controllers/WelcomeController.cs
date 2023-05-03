using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;


namespace Ex2_Controleur_Et_Test.Controllers
{
    public class WelcomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WelcomeDefault()//Je doit mettre le Welcome dans l'url en premier pour appeler les autres methode d'action
        {
            return Content("Bienvenue dans ma nouvelle application");//Ex: https://localhost:7129/Welcome/Bienvenu pour appeler public IActionResult Bienvenu()
        }

        public IActionResult WelcomeName(string prenom, string nom)
        {
            return Content("Salut " + prenom + " " + nom + "! Bienvenue dans ma nouvelle application!");
        }

        //#1
        public IActionResult Bienvenu()
        {
            return Content("<h2>Bienvenue dans mon site web</h2>", "text/html");
        }

        //#2
        public ContentResult WelcomeHtml()
        {
            string message = "<h2>Bienvenue dans mon site web</h2>" + "</h3>ContentResultStyle</h3>";//La méthode Content prend deux paramètres : le contenu à afficher et le type de contenu. 
            return Content(message, "text/html");
        }
      
        //#3
        public IActionResult WelcomeMessage2()//Ne fonctionne pas car il manque une vue?
        {
            return View();
        }



        //#4
        public WelcomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // ... autres méthodes d'action ...

        public IActionResult DownloadPDF()//Probleme de navigateur qui telecharge le fichier au lieu de l'afficher seulement dans le navigateur?
        {
            string fileName = "TFP_MRP.pdf";
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "PDF", fileName);

            var fileContent = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/pdf";

            Response.Headers.Add("Content-Disposition", "inline");
            Response.Headers.Add("Content-Type", contentType);
            return File(fileContent, contentType, fileName);
        }



    }
}
