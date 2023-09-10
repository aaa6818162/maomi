using Maomi.Web.Core;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 1������ע��
builder.Services.AddMaomiSwaggerGen(
    setupMaomiSwaggerAction: null,
    setupSwaggerAction: null,
    setupApiVersionAction: null,
    setupApiExplorerAction: o =>
    {
        // ��ȡ�����ð汾������ url ��ַ��
        o.SubstituteApiVersionInUrl = true;
        // swagger ҳ��Ĭ������İ汾��
        o.DefaultApiVersion = new ApiVersion(1, 0);
        // ��ʾ�İ汾�����ʽ
        o.GroupNameFormat = "'v'VVV";
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // 2�����������м��
    app.UseMaomiSwagger();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
