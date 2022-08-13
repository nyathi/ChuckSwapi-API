using ChuckNorris_API.Services;
using ChuckNorris_API.Services.chuck;
using ChuckNorris_API.Services.Search;
using ChuckNorris_API.Services.Swapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registers the service
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IJokesService, JokesService>();
builder.Services.AddScoped<IAPIContantDefination, APIContantDefination>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

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
