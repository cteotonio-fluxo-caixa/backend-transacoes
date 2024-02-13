using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using Transacoes.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Serviço de Transações", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .WriteTo.Console();
        // Adicione outras configurações do Serilog aqui, como escrever para arquivos, etc.
        //.WriteTo.Http(
        //            requestUri: "http://seu-splunk-host:8088",
        //            textFormatter: new Serilog.Formatting.Compact.RenderedCompactJsonFormatter(),
        //            queueLimitBytes: 1024)
        //        .MinimumLevel.Information()
        //        .Enrich.FromLogContext();

});


builder.Services.AddTransacaoApplication();
builder.Services.AddDbContext(configuration: builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Serviço de Transação v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
