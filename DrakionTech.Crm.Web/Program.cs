using DrakionTech.Crm.Business;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Mapping;
using DrakionTech.Crm.Business.Options;
using DrakionTech.Crm.Business.Services;
using DrakionTech.Crm.Data;
using DrakionTech.Crm.Web.Components;
using DrakionTech.Crm.Data.Repositories;
using static GoogleDriveService;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using DrakionTech.Crm.Business.Services.Email;
using DrakionTech.Crm.Business.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Services;
using DrakionTech.Crm.Web.Services;
// BUILDER
var builder = WebApplication.CreateBuilder(args);

// CAPA DE DATOS
builder.Services.AddCrmData(builder.Configuration);

// CAPA DE NEGOCIO
builder.Services.AddCrmBusiness();
builder.Services.AddAutoMapper(typeof(CrmMappingProfile));
builder.Services.AddScoped<IAuthService, AuthService>();

// AUTENTICACI�N Y AUTORIZACI�N
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
        options.CallbackPath = "/signin-google";
    });
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserContext, HttpCurrentUserContext>();

// EMAIL
builder.Services.Configure<EmailSettings>(
builder.Configuration.GetSection("Email"));
builder.Services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
builder.Services.AddScoped<IEmailTemplateRenderer, EmailTemplateRenderer>();
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
builder.Services.AddScoped<IEmailService, EmailService>();


// WHATSAPP
builder.Services.Configure<WhatsAppOptions>(
builder.Configuration.GetSection("WhatsApp"));
builder.Services.AddHttpClient<IWhatsAppNotificationService, WhatsAppNotificationService>();

// EMPLEADOS
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

//AREAS
builder.Services.AddScoped<IAreaService, AreaService>();

// Proyectos
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();
builder.Services.AddScoped<IEmpleadoProyectoAsignacionRepository, EmpleadoProyectoAsignacionRepository>();
builder.Services.AddScoped<IEmpleadoProyectoAsignacionService, EmpleadoProyectoAsignacionService>();

//MARKETING
builder.Services.AddScoped<IPublicacionMarketingRepository, PublicacionMarketingRepository>();
builder.Services.AddScoped<IPublicacionMarketingService, PublicacionMarketingService>();

//Roles
builder.Services.AddScoped<IRolUsuarioService, RolUsuarioService>();

//Especialidades
builder.Services.AddScoped<IEspecialidadService, EspecialidadService>();

//USUARIOS
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Azure / Google
builder.Services.AddScoped<AzureBlobService>();
builder.Services.AddScoped<GoogleAuthService>();
builder.Services.AddScoped<GoogleEventoReadService>();
builder.Services.AddScoped<GoogleDriveService>();

// SERVICIOS UI
builder.Services.AddScoped<IMensajesService, MensajesService>();

// BLAZOR 
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// BUILD
var app = builder.Build();

// MIDDLEWARE PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ENDPOINTS DE AUTENTICACION

app.MapPost("/account/login", async (
    HttpContext ctx, IAccountService accountService, IAuthSessionService sessionService) =>
{
    var form = await ctx.Request.ReadFormAsync();
    var email = form["email"].ToString();
    var password = form["password"].ToString();

    var (resultado, user) = await accountService.LoginAsync(email, password);

    if (resultado != LoginErrorEnum.Ninguno)
        return Results.Redirect($"/login?error={resultado}");

    await sessionService.SignInAsync(ctx, user!.Email, user!.Id, $"{user!.Nombre} {user!.Apellido}");
    return Results.Redirect("/");
}).DisableAntiforgery();


app.MapPost("/account/logout", async (HttpContext ctx, IAuthSessionService sessionService) =>
{
    await sessionService.SignOutAsync(ctx);
    return Results.Redirect("/login");
}).DisableAntiforgery();


app.MapPost("/account/registro-inicial", async (
    HttpContext ctx, IAccountService accountService) =>
{
    var form = await ctx.Request.ReadFormAsync();

    var resultado = await accountService.RegistroInicialAsync(
        form["nombre"].ToString().Trim(),
        form["apellido"].ToString().Trim(),
        form["email"].ToString().Trim(),
        form["password"].ToString(),
        form["confirmar"].ToString()
    );

    return resultado switch
    {
        RegistroResultadoEnum.Bloqueado => Results.Redirect("/login"),
        RegistroResultadoEnum.Ok => Results.Redirect("/login?mensaje=cuenta-creada"),
        _ => Results.Redirect($"/registro-inicial?error={resultado}")
    };
}).DisableAntiforgery();


app.MapGet("/account/google-login", (HttpContext ctx) =>
{
    var props = new AuthenticationProperties { RedirectUri = "/account/google-callback" };
    return Results.Challenge(props, ["Google"]);
});


app.MapGet("/account/google-callback", async (
    HttpContext ctx, IAccountService accountService, IAuthSessionService sessionService) =>
{
    var result = await ctx.AuthenticateAsync("Google");

    if (!result.Succeeded)
        return Results.Redirect("/login?error=google");

    var email = result.Principal?.FindFirst(ClaimTypes.Email)?.Value;
    var (resultado, user) = await accountService.GoogleCallbackAsync(email);

    if (resultado != GoogleCallbackResultadoEnum.Ok)
        return Results.Redirect($"/login?error={resultado}");

    await sessionService.SignInAsync(ctx, user!.Email, user!.Id, $"{user!.Nombre} {user!.Apellido}");
    return Results.Redirect("/");
});

app.Run();
