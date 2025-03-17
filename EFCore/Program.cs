using ExperienceAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Tilføj DbContext med SQL Server forbindelse
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    Console.WriteLine("🔄 Checking database...");
    
    
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    
    Console.WriteLine("✅ Database recreated. Seeding data...");
    
    DbSeeder.Seed(context);

    Console.WriteLine("✅ Seeding completed!");
}

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
