using MyClinic.Application.Logic;
using MyClinic.Domain.Repositories;
using MyClinic.Persistence.Repositories;
using MediatR;
using Scrutor;
using MyClinic.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentReserverByTime, AppointmentReserverByTime>();
builder.Services.AddScoped<IValidTimeDoctorRepository, ValidTimeDoctorRepository>();
builder.Services.AddScoped<IAppointmentReserver, AppointmentReserver>();
// Add services to the container.

builder.Services.Scan(
        selector => selector
            .FromAssemblies(
                MyClinic.Infrastructure.AssemblyReference.Assembly,
                MyClinic.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(MyClinic.Application.AssemblyReference)));

builder.Services.AddDbContext<MyClinicDbContext>();


builder.Services
    .AddControllers()
    .AddApplicationPart(AssemblyReference.Assembly);




//Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();
