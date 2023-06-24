using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<SoatVeDbContext>(options => options.UseInMemoryDatabase("SoatVeDb"));
builder.Services.AddDbContext<SoatVeDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SoatVeConnectionStrings")));

builder.Services.AddTransient<ICTRepository,CTRepository>();
builder.Services.AddTransient<IVeRepository, VeRepository>();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<ITinTucRepository, TinTucRepository>();
builder.Services.AddTransient<IDiaDiemRepository, DiaDiemRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();






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
