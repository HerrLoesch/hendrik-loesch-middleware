using Grpc.Core;
using hendrik_loesch_api;

namespace hendrik_loesch_middleware;

public class TypeService : PublicationTypeService.PublicationTypeServiceBase
{
    private readonly ILogger<TypeService> logger;

    public TypeService(ILogger<TypeService> logger)
    {
        this.logger = logger;
    }

    public override Task<PublicationTypeCollection> GetAll(PublicationTypesRequest request, ServerCallContext context)
    {
        this.logger.LogInformation($"Publication types are requested: {request.ToString()}");
        
        var collection = new PublicationTypeCollection();
        collection.Types_.Add(new PublicationType(){ Name = "Meiner"});
        collection.Types_.Add(new PublicationType(){ Name = "Noch einer"});

        return base.GetAll(request, context);
    }
}