using DirectScale.Disco.Extension.Api;

namespace Demo.Api
{
    public class Endpoint3 : ApiEndpoint<Endpoint3Request>
    {
        public Endpoint3(IRequestParsingService parsingService) : base("demo/end3", parsingService)
        {

        }

        public override IApiResponse Post(Endpoint3Request request)
        {
            var clientId = System.Environment.GetEnvironmentVariable("client");

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourceName = "Demo.Html.htmlpage.html";
            using (System.IO.Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                string data = reader.ReadToEnd();

                return new Ok(new { data });
            }
        }
    }
}
