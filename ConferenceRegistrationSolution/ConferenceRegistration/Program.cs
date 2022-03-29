using ConferenceRegistration;
using ConferenceRegistration.Adapters;
using ConferenceRegistration.Adapters.Mongo;
using ConferenceRegistration.Controllers;
using ConferenceRegistrationApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IOptions Stuff
builder.Services.Configure<ProductsSettings>(builder.Configuration.GetSection(ProductsSettings.SectionName));

//My Domain services

builder.Services.AddScoped<IProductsService, ProductService>();
//Adapters
builder.Services.AddSingleton<MongoProductsAdapter>();

builder.Services.AddHttpClient<MarkupServiceAdapter>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("markupApi"));

}).AddPolicyHandler(HttpPolicies.GetMarkupRetryPolicy());

builder.Services.AddScoped<MarkupServiceAmountPort>();
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
