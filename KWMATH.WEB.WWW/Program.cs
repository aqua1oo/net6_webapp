using KWMATH.WEB.WWW.Models;
using KWMATH.WEB.WWW.Data;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using KWMATH.WEB.WWW;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//db connection 설정
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//cookie 설정
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/";        
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//log4net 설정 >> *nuget pakage 추가 후 반드시 log4net.config 마우스 오른쪽 클릭 > 속성 > 출력 디렉터리로 복사 > 항상 복사
XmlConfigurator.Configure(new FileInfo("log4net.config"));

var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//exception 발생시 custom page로 이동
app.UseExceptionHandler("/Exception/Error");
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == ExceptionConstant.EXCEPTION_STATUSCODE_NOTFOUND)
    {
        context.Request.Path = "/Exception/Error";
        await next();
    }
});
//page에 exception 정보 노출
//app.UseDeveloperExceptionPage();
app.UseHsts();
//}

app.UseStaticFiles();
app.UseRouting();

//인증 설정
app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();