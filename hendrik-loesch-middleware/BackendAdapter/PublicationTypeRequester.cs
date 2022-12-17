using hendrik_loesch_api;
using Newtonsoft.Json;

namespace hendrik_loesch_middleware.BackendAdapter;

public class PublicationTypeRequester : IPublicationTypeRequester
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<PublicationType[]> GetPublicationTypesAsync()
        {
            string responseBody = await client.GetStringAsync("https://hendrik-loesch.firebaseio.com/publicationTypes.json");

            if(responseBody != null)
            {
                PublicationType[] publicationTypes = JsonConvert.DeserializeObject<PublicationType[]>(responseBody);
                return publicationTypes;
            }
                
            return new List<PublicationType>().ToArray();

        }
    }