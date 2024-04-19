using LuckyAPi.Conection;
using LuckyAPi.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var origenesPermitidos = builder.Configuration.GetValue<string>("origenesPermitidos")!;
builder.Services.AddControllers();
builder.Services.AddSingleton(new Conexion(builder.Configuration.GetConnectionString("conexion")));
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });

    opciones.AddPolicy("libre", configuracion =>
    {
        configuracion.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioService,UsuarioServiceImpl>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoServiceImpl>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
