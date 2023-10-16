using Api.Commands;
using Common.Hosting;

AppDomain.CurrentDomain.UnhandledException += new ProcessUnhandledExceptionCommand().Execute;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
new ConfigureServicesCommand().Execute(builder.Services, builder.Configuration);
WebApplication app = builder.Build();
app.MapGet("/api/v1/titlecase", (string text) => new GetTitleCaseCommand(app.Services.GetRequiredService<ILogger<GetTitleCaseCommand>>()).Execute(text));
app.Run();
new HandleTerminationCommand().Execute();