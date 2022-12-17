using hendrik_loesch_api;

public interface IPublicationTypeRequester
{
    Task<PublicationType[]> GetPublicationTypesAsync();
}