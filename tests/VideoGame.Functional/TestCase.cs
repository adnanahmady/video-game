using VideoGame.Api.Core;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional;

public class TestCase : IClassFixture<TestableWebApplicationFactory>
{
    protected HttpClient Client;
    protected HttpClient Guest;
    protected Action<string> Cw;
    protected VideoGameDbContext Context;

    public TestCase(
        TestableWebApplicationFactory factory,
        ITestOutputHelper output
    )
    {
        Client = factory.Authenticate().CreateClient();
        Guest = factory.CreateClient();
        Cw = output.WriteLine;
        Context = factory.GetDbContext<VideoGameDbContext>();
    }
}
