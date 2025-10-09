using EFTest.Data;
using EFTest.Repository.CoursesRepository;
using EFTest.Repository.StudentsRepository;
using EFTest.Repository.StudentsCoursesRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using EFTest.Repository.CoursesModulesRepository;
using EFTest.Repository.ModulesRepository;
using EFTest.Repository.StudentsModulesRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Adicionando o contexto
builder.Services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    )
                );

// Cria uma instancia da classe toda vez que usar a interface
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
builder.Services.AddScoped<IStudentModuleRepository, StudentModuleRepository>();
builder.Services.AddScoped<ICourseModuleRepository, CourseModuleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

CreateDbIfNotExists(app);

app.Run();

static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<SchoolContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB");
        }
    }
}