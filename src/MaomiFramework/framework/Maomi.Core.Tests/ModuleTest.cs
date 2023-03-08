using Maomi.Core.Tests.Module1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maomi.Core.Tests
{
	// ѭ������ģ��
	// �Զ�����ע��
	public class ModuleTest
	{
		// �������ӵ�ģ�������ע��
		[Fact]
		public void Check_Module_Inject()
		{
			var ioc = new ServiceCollection();
			var congiguration = new ConfigurationBuilder()
				.AddInMemoryCollection(new Dictionary<string, string?>()).Build();
			ioc.AddScoped<IConfiguration>(s => congiguration);
			ioc.AddSingleton<IHostService, HostService>();
			RecordInfo recordInfo = new RecordInfo();
			ioc.AddSingleton(recordInfo);

			ioc.AddModule<DModule>();
			var list = recordInfo.List;
			Assert.Equal(typeof(AModule).Name, list[0]);
			Assert.Equal(typeof(BModule).Name, list[1]);
			Assert.Equal(typeof(CModule).Name, list[2]);
			Assert.Equal(typeof(DModule).Name, list[3]);

			var services = ioc.BuildServiceProvider();
			var s1 = services.GetService<ParentService>();
			Assert.Null(s1);
			var sa = services.GetRequiredService<IA>();
			var sb = services.GetRequiredService<IB>();
			var sc = services.GetRequiredService<IC>();
			Assert.NotNull(sa);
			Assert.NotNull(sb);
			Assert.NotNull(sc);
		}

		// ѭ������ģ����
		[Fact]
		public void Check_Loop_Dependency_Module()
		{
			var ioc = new ServiceCollection();
			try
			{
				ioc.AddModule<DModule>();
				Assert.True(false);
			}
			catch
			{
				Assert.True(true);
			}
		}
	}
}