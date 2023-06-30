using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Models;
using SoatVe.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<SoatVeDbContext>(options => options.UseInMemoryDatabase("SoatVeDb"));
builder.Services.AddDbContext<SoatVeDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SoatVeConnectionStrings")));


builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<SoatVeDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddTransient<ICTRepository,CTRepository>();
builder.Services.AddTransient<IVeRepository, VeRepository>();
builder.Services.AddTransient<IThongTinRepository, ThongTinRepository>();
builder.Services.AddTransient<ITinTucRepository, TinTucRepository>();
builder.Services.AddTransient<IDiaDiemRepository, DiaDiemRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
builder.Services.AddTransient<RoleManager<IdentityRole>,RoleManager<IdentityRole>>();





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
