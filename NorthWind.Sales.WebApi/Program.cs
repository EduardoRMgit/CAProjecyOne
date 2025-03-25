using NorthWind.Sales.Backend.DataContext.EFCore.Options;
using NorthWind.Sales.Backend.IoC;
using NorthWind.Sales.Backend.SmtpGateway.Options;
using NorthWind.Sales.WebApi;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSalesServices(dbOptions =>
        builder.Configuration.GetSection(DBOptions.SectionKey).Bind(dbOptions),
        smtpOptions =>
        {
            builder.Configuration.GetSection(SmtpOptions.SectionKey).Bind(smtpOptions);
        }
        );


// que es el Cors?
// cuando una web api, expone funcionalidad, pudiera recibir perticiones remotas.
// el navegador web, tiene un esquema de seguridad, que solo permite la comunicación al cliente que se ejecuta en el browser.
// el browser proteje a los endpoints de las web apis.

// el browser pide permiso de la web api para poder consumirlo, si la web api no autoriza, el explorador no devuelve 
// al código cliente, tiene que emitir la respuesta, si permite o no permite
// Controlas lo que son permisos, defines los servicios
// Cross origen source shared => el compartir recursos de origenes cruzados
// ¿Qué es un origen cruzado?, tienes microsoft.Com, y luego tienes un cliente en Northwind.com, son dominios diferentes
// entonces es de origen cruzado, quiero permitir, clientes de otros dominios me puedan consumir
// puedes configurar ¿ qué origines?, okey, qué métodos permito? solo quiero gets, pots, put, delete?

// también encabezados, cosas que recibes, en nuestro ejemplo, permetimos todos los origines, encabezados y todos los métodos. solo permito de mi propio dominio
// si son clientes de mi propio dominio, es el mismo origen, por lo que no aplica cors.

// Entonces hay un origen cruzado, tiene el puerto incluso, y el nombre del host. Es el servicio.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.AllowAnyMethod();
        config.AllowAnyOrigin();
        config.AllowAnyHeader();
    });
});


var app = builder.Build();

// configura el middleware al pipeline que cachara las exepciones
// un delegado con manejo de exepción, pero no queremos nada
app.UseExceptionHandler(builder => { });

// este middleware, la atrapa, a continuación, detecta quienes son los manejadores de exepción registrado
// los del dependency container,

// el middleware de manejador de execepción global, que sea el primero en registrar
// porque cualquiere de los middlewares pudiera fallar

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapSalesEndpoints();
app.UseCors();

app.Run();
