using EDiaristas.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDatabase();
builder.Services.RegisterRepositories();
builder.Services.RegisterMappers();
builder.Services.RegisterServices();
builder.Services.RegisterValidators();
builder.Services.RegisterIdentity();
builder.Services.RegisterSeeds();
builder.Services.RegisterAssemblers();
builder.Services.RegisterPermissions();
builder.Services.RegisterCors();

builder.Services.RegisterControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.RegisterMiddlewares();
app.ExecuteSeeds();
app.UseCors("CorsPolicy");

app.Run();
