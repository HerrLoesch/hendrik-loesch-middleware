using NUnit.Framework;
using hendrik_loesch_middleware.BackendAdapter;

namespace hendrik_loesch_middleware.tests;

public class BackEndAdapterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task CheckIfYouCanGetPublicationTypes()
    {
        var sut = new PublicationTypeRequester();       
        var result = await sut.GetPublicationTypesAsync();

        Assert.IsTrue(result.Count() > 0);
    }
}