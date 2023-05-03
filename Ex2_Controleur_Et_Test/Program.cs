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
        defaults: new { controller = "Welcome", action = "WelcomeDefault" }//Welcome est le nom du contrôleur et WelcomeDefault est le nom de la méthode d'action dans le contrôleur
    );

    endpoints.MapControllerRoute(
        name: "WelcomeName",
        pattern: "Welcome/{prenom}/{nom}",
        defaults: new { controller = "Welcome", action = "WelcomeName" }//Welcome est le nom du contrôleur et WelcomeName est le nom de la méthode d'action dans le contrôleur
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();

//Dans cet exemple, nous avons utilisé la méthode UseEndpoints() pour ajouter les routes.
//Nous avons ajouté deux routes supplémentaires pour la page d'accueil par défaut et la page WelcomeName.
//La première route correspond à la page d'accueil par défaut, qui utilise le contrôleur Welcome et
//la méthode d'action WelcomeDefault. La deuxième route correspond à la page WelcomeName et utilise
//le contrôleur Welcome et la méthode d'action WelcomeName avec les paramètres prenom et nom.
//Notez que l'ordre de la définition des routes est important. Les routes doivent être définies de manière
//à ce que la route la plus spécifique soit définie en premier et la route la moins spécifique soit définie
//en dernier. Cela permet à ASP.NET Core de déterminer la meilleure correspondance pour chaque URL.

