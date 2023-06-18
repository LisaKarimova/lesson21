using Telegram.Bot;
using Telegram.Bot.Polling;


{
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHostedService<Botbackgroundservices>();

        builder.Services.AddTransient<IUpdateHandler, UpdateHandler>();
        builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>(
             p => new TelegramBotClient(builder.Configuration.GetValue("BotApiKey", string.Empty)));
        builder.Build().Run();
        builder.Build().Run();
    }