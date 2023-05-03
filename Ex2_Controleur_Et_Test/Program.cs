var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "WelcomeDefault",
        pattern: "",
        defaults: new { controller = "Welcome", action = "WelcomeDefault" }//Welcome est le nom du contr�leur et WelcomeDefault est le nom de la m�thode d'action dans le contr�leur
    );

    endpoints.MapControllerRoute(
        name: "WelcomeName",
        pattern: "Welcome/{prenom}/{nom}",
        defaults: new { controller = "Welcome", action = "WelcomeName" }//Welcome est le nom du contr�leur et WelcomeName est le nom de la m�thode d'action dans le contr�leur
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();

//Dans cet exemple, nous avons utilis� la m�thode UseEndpoints() pour ajouter les routes.
//Nous avons ajout� deux routes suppl�mentaires pour la page d'accueil par d�faut et la page WelcomeName.
//La premi�re route correspond � la page d'accueil par d�faut, qui utilise le contr�leur Welcome et
//la m�thode d'action WelcomeDefault. La deuxi�me route correspond � la page WelcomeName et utilise
//le contr�leur Welcome et la m�thode d'action WelcomeName avec les param�tres prenom et nom.
//Notez que l'ordre de la d�finition des routes est important. Les routes doivent �tre d�finies de mani�re
//� ce que la route la plus sp�cifique soit d�finie en premier et la route la moins sp�cifique soit d�finie
//en dernier. Cela permet � ASP.NET Core de d�terminer la meilleure correspondance pour chaque URL.

