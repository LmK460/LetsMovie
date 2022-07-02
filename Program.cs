using API.Service;
using Domain.Interfaces;
using Infra.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(x => new ApiClientFactory
                                        (builder.Configuration["ApiConfigurations:AuthBaseUrl"])
); ;
builder.Services.AddTransient(x => new MovieApiClientFactory
                                        (builder.Configuration["ApiConfigurations:MovieBaseUrl"],
                                        builder.Configuration["ApiConfigurations:MovieApiKey"])
);

builder.Services.AddTransient<IDatabaseConnectionFactory>(x => new DatabaseConnectionFactory
                                        (builder.Configuration.GetConnectionString("PostGreesConnection"))
);




builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<RattingService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<RattingService>();

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
