using Ex2_Controleur_Et_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ex2_Controleur_Et_Test.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //#5
        public IActionResult ListeClients(bool redirect = false)
        {
            // Créer une liste d'objets Client
            List<Client> clients = new List<Client>();
            clients.Add(new Client(1, "Larouche", "John", "john@example.com"));
            clients.Add(new Client(2, "Dubois", "Jeanne", "jeanne@example.com"));
            clients.Add(new Client(3, "Sleigh", "Bob", "bob@example.com"));

            // Sérialiser la liste en format JSON
            string jsonString = JsonSerializer.Serialize(clients);

            //redirection ver bienvenu si l'url est /Client/ListeClients?redirect=true est entrer
            if (redirect)
            {
                // Rediriger vers la méthode Bienvenu
                return RedirectToAction("Bienvenu", "Welcome");
            }
            else
            {
                // Retourner le contenu JSON
                return Content(jsonString, "application/json");
            }
        }
    }
}
//commentaire pas rapport