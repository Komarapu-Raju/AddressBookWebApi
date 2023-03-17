using Microsoft.EntityFrameworkCore;
using AddressBookWebApi.Infrastructure.EFCore.DBContexts;
using AddressBookWebApi.DTO.Profiles;
using AddressBookWebApi.Services.Contacts.Interfaces;
using AddressBookWebApi.Services.Contacts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContactServices, ContactServices>();

builder.Services.AddAutoMapper(typeof(ContactMapper).Assembly);

builder.Services.AddDbContext<AddressBookDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection"), b => b.MigrationsAssembly("AddressBookWebApi"));
});

//builder.Services.AddSingleton<IContactServices, ContactServices>();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowAllHeaders", options =>
    {
        options.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeaders");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
