using Maomi.Web.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 1������ע��
builder.Services.AddMaomiSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	// 2�����������м��
	app.UseMaomiSwagger();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
