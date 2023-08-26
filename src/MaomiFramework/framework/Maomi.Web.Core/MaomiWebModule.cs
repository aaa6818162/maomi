﻿using Maomi.I18n;
using Maomi.Module;
using Maomi.Web.Core.Filters;

namespace Maomi.Web.Core
{
    public class MaomiWebModule : IModule
    {
        public void ConfigureServices(ServiceContext context)
        {
            // i18n 服务
            context.Services.AddI18n("zh-CN");
            context.Services.AddI18nResource(options =>
            {
                options.AddJson<MaomiWebModule>("i18n");
            });

            // 添加控制器
            context.Services.AddControllers(options =>
            {
                options.Filters.Add<MaomiActionFilter>();
                options.Filters.AddService<MaomiActionFilter>();
            })
                .AddI18nDataAnnotation();
        }
    }
}
