using System.Net;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace CountriesAPI
{
    internal class Program
    {
        public static string dataPath = Path.Combine(Environment.CurrentDirectory, @"countries.json");
        public static string dataPathOnline = "https://gist.githubusercontent.com/tmrk/3ba1cc679e9f655143593524a203b7e2/raw/3e67c8cf3fdcb685f1407002be158499d95966e6/countries.json";

        static List<Country> Countries(bool loadFromLocal = false)
        {
            string json = "";
            if (loadFromLocal && File.Exists(dataPath)) json = File.ReadAllText(dataPath);
            else json = new WebClient().DownloadString(dataPathOnline);
            return JsonSerializer.Deserialize<List<Country>>(json);
        }

        public static List<Country> countries = Countries();
    }
}



