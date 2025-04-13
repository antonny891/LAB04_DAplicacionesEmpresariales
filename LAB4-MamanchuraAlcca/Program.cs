using Microsoft.EntityFrameworkCore;
using LAB4_MamanchuraAlcca.Models; // Asegúrate de que este namespace sea correcto
using LAB4_MamanchuraAlcca.Repositories; // Asegúrate de que los repositorios estén en el namespace correcto

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión
var connectionString = "server=localhost;database=TiendaDB;user=root;password=;";
builder.Services.AddDbContext<TiendaDBContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Agregar servicios para MVC
builder.Services.AddControllersWithViews();


// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Habilitar Swagger en la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Habilitar Swagger
    app.UseSwaggerUI(); // Habilitar la interfaz de usuario de Swagger
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();