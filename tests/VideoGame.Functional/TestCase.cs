using VideoGame.Api.Core;
using VideoGame.Functional.Support;

using Xunit.Abstractions;

namespace VideoGame.Functional;

public class TestCase : IClassFixture<TestableWebApplicationFactory>
{
    protected Action<string> Dump;
    protected readonly VideoGameDbContext Context;

    protected readonly HttpClient Guest;
    protected readonly HttpClient Client;
    protected readonly HttpClient AdminClient;
    protected TestCase(
        TestableWebApplicationFactory factory,
        ITestOutputHelper output)
    {
        Guest = factory.CreateClient();
        Client = factory.Authenticate("User").CreateClient();
        AdminClient = factory.Authenticate("Admin").CreateClient();
        Dump = output.WriteLine;
        Context = factory.GetDbContext<VideoGameDbContext>();
    }
}
