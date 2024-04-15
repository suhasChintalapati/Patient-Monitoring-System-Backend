using PatientVitalsServices;
using PatientVitalsRepo;
using Microsoft.Azure.Cosmos;
using CommonResources.Models;
using DoctorServices;
using DoctorRepo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPatientVitalsService,PatientVitalsService>();
builder.Services.AddScoped<IPatientVitalsRepo,PatientVitalRepo>();
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IDoctorRepo,DoctorsRepo>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuring Cosmos db
IConfiguration Cosmosconfiguration = builder.Configuration.GetSection("CosmosDbSettings");
CosmosDbConfiguration config = new CosmosDbConfiguration
{
    Endpoint = Cosmosconfiguration["Endpoint"],
    Key = Cosmosconfiguration["Key"],
    DatabaseId = Cosmosconfiguration["DatabaseId"]
};
builder.Services.AddSingleton<string>((provider) =>
{
    return config.DatabaseId;
});

builder.Services.AddSingleton<CosmosClient>((serviceProvider) =>
{
    
    return new CosmosClient(
        config.Endpoint,
        config.Key,
        new CosmosClientOptions()
        {
            SerializerOptions = new CosmosSerializationOptions()
            {
                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
            }
        }
        );
    //var cosmosClient = new CosmosClient(
    //            config.Endpoint,
    //            config.Key,
    //            new CosmosClientOptions()
    //            {
    //                SerializerOptions = new CosmosSerializationOptions()
    //                {
    //                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
    //                }
    //            }
    //        );
    //return cosmosClient;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
