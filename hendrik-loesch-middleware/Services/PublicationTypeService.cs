using Grpc.Core;
using hendrik_loesch_api;

namespace hendrik_loesch_middleware;

public class TypeService : PublicationTypeService.PublicationTypeServiceBase
{
    public override Task<PublicationTypeCollection> GetAll(PublicationTypesRequest request, ServerCallContext context)
    {
        var collection = new PublicationTypeCollection();
        collection.Types_.Add(new PublicationType(){ Name = "Meiner"});
        collection.Types_.Add(new PublicationType(){ Name = "Noch einer"});

        return base.GetAll(request, context);
    }
}