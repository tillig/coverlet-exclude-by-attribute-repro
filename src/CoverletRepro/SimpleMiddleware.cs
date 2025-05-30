namespace CoverletRepro;

public partial class SimpleMiddleware
{
    // The generated logger method doesn't work well with excluding
    // GeneratedCodeAttribute. It doesn't matter if the method is even actually
    // used, it just needs to exist. Comment it out to see coverage; or change
    // Coverage.buildsettings to remove the ExcludeByAttribute node.
    [LoggerMessage(1, LogLevel.Debug, "Request came in.")]
    private partial void LogRequest();

    [SuppressMessage("IDE0052", "IDE0052", Justification = "Logger is called by generated log methods.")]
    private readonly ILogger<SimpleMiddleware> _logger;
    private readonly RequestDelegate _next;

    public SimpleMiddleware(
        ILogger<SimpleMiddleware> logger,
        RequestDelegate next)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await this._next(context);
    }
}
