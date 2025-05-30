using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;

namespace CoverletRepro.Tests;

public class SimpleMiddlewareTests
{
    [Fact]
    public void Ctor_NullLogger()
    {
        var next = CreateRequestDelegate();
        Assert.Throws<ArgumentNullException>(() => new SimpleMiddleware(null!, next));
    }

    [Fact]
    public void Ctor_NullNext()
    {
        Assert.Throws<ArgumentNullException>(() => new SimpleMiddleware(new NullLogger<SimpleMiddleware>(), null!));
    }

    private static RequestDelegate CreateRequestDelegate()
    {
        var next = Substitute.For<RequestDelegate>();
        next.Invoke(Arg.Any<HttpContext>()).Returns(Task.CompletedTask);
        return next;
    }
}
