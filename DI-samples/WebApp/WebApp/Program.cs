using WebApp.Providers;
using WebApp.Resolvers;
using WebApp.Services;
using WebApp.States;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// inject dictionary: {States} -> {Type}:
var stateTypes = AppDomain.CurrentDomain
    .GetAssemblies()
    .SelectMany(a => a.GetTypes())
    .Where(t => typeof(IState).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

var dict = new Dictionary<State, Type>();

foreach (var t in stateTypes)
{
    var objState = Activator.CreateInstance(t) as IState;

    dict.Add(objState.State, t);
}

builder.Services.AddSingleton(dict);
builder.Services.AddScoped<IResolver, Resolver>();
builder.Services.AddScoped<IService, ConcreteService>();

builder.Services.AddScoped<IProvider, ConcreteProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
