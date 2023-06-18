using Telegram.Bot;
using Telegram.Bot.Polling;
public class Botbackgroundservices : BackgroundService
{
    private readonly ILogger<Botbackgroundservices>logger;
    private readonly ITelegramBotClient botClient;
    public class IUpdateHandler :UpdateHandler
    {
        
    }


    public  Botbackgroundservices(
        ILogger<Botbackgroundservices> logger,
        ITelegramBotClient botClient,
        IUpdateHandler updateHandler)
    
    {
        this.logger = logger;
        this.botClient = botClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await botClient.GetMeAsync(stoppingToken);
        logger.LogInformation("Bot{username} started at {time}", me.Username,DateTime.UtcNow);

        botClient.StartReceiving(
            updateHandler : updateHandler,
            receiverOptions : default,
            cancellationToken : stoppingToken);
    }

}

