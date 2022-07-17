using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.Repository.Abstracts;
using NoteAPI.Repository.Concretes;
using NoteAPI.Service.Abstract;
using NoteAPI.Service.Concretes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotesRepository, NotesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<INotesService, NotesService>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddDbContext<DataContext>(options => //appsettings.json dosyas�nda bulunan database imizle ba�lant�m�z�n link i DefaultConnection a atan�yor, burada UseSqlServer methodu ile ba�lant�y� kuruyoruz.
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
