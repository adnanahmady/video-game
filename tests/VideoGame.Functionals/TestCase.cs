using VideoGame.Api.Core;
using VideoGame.Functionals.Support;

using Xunit.Abstractions;

namespace VideoGame.Functionals;

public class TestCase : IClassFixture<TestableWebApplicationFactory>
{
    protected HttpClient Client;
    protected Action<string> Cw;
    protected VideoGameDbContext Context;

    public TestCase(
        TestableWebApplicationFactory factory,
        ITestOutputHelper output
    )
    {
        Client = factory.CreateClient();
        Cw = output.WriteLine;
        Context = factory.GetDbContext<VideoGameDbContext>();
    }
}
