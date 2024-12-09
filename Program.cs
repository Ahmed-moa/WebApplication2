using Microsoft.EntityFrameworkCore;
using WebApplication2.DAL.Database;
using WebApplication2.BL.Interface;
using WebApplication2.BL.Repository;
using Microsoft.AspNetCore.Identity;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // إضافة الـ DbContext للـ DI container
        builder.Services.AddDbContext<Dbcontainer>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // إعداد الـ Identity
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<Dbcontainer>();

        // إضافة إعدادات Identity
        builder.Services.Configure<IdentityOptions>(options =>
        {
            // إعدادات كلمات المرور
            options.Password.RequireDigit = false; // عدم اشتراط وجود رقم
            options.Password.RequiredLength = 6; // الحد الأدنى لطول كلمة المرور
            options.Password.RequireNonAlphanumeric = false; // عدم اشتراط وجود رموز خاصة
            options.Password.RequireUppercase = false; // عدم اشتراط وجود أحرف كبيرة
            options.Password.RequireLowercase = false; // عدم اشتراط وجود أحرف صغيرة

            // إعدادات القفل (Lockout)
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // وقت القفل عند المحاولات الخاطئة
            options.Lockout.MaxFailedAccessAttempts = 5; // عدد المحاولات المسموح بها

            // إعدادات المستخدم
            options.User.RequireUniqueEmail = true; // اشتراط بريد إلكتروني فريد
        });

        // تسجيل الـ Repository في الـ DI container
        builder.Services.AddScoped<IProductRep, ProductRep>();

        // إضافة الخدمات الخاصة بـ MVC
        builder.Services.AddControllersWithViews();

        // بناء التطبيق
        var app = builder.Build();

        // إعدادات البيئة
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        // إعداد التوجيه (Routing)
        app.UseRouting();

        // إضافة خدمات الـ Identity (مصادقة المستخدمين)
        app.UseAuthentication();
        app.UseAuthorization();

        // إعداد المسار الافتراضي
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Registration}/{id?}");

        // تشغيل التطبيق
        app.Run();
    }
}
