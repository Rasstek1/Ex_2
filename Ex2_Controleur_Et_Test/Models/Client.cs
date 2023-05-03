namespace Ex2_Controleur_Et_Test.Models
{
    //#5
    public class Client
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Courriel { get; set; }

        public Client(int numero, string nom, string prenom, string courriel)
        {
            Numero = numero;
            Nom = nom;
            Prenom = prenom;
            Courriel = courriel;
        }
    }
}
