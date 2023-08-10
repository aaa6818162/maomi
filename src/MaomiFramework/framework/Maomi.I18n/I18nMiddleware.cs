﻿using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Maomi.I18n
{
	/// <summary>
	/// i18n 中间件，从请求中提取用户指定的语言
	/// </summary>
	public class I18nMiddleware : IMiddleware
	{
		private readonly CultureInfo _defaultCulture;
		public I18nMiddleware(CultureInfo defaultCulture)
		{
			_defaultCulture = defaultCulture;
		}
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
            CultureInfo culture;
			var requestCultureFeature = context.Features.Get<IRequestCultureFeature>();
			var requestCulture = requestCultureFeature?.RequestCulture;
			if (requestCulture != null)
				culture = requestCulture.Culture;
			else culture = _defaultCulture;
			var option = context.RequestServices.GetRequiredService<I18nContext>();
			option.Culture = culture;
			await next(context);
		}
	}
}
