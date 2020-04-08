using DirectScale.Disco.Extension.Api;

namespace Demo.Views
{
    public class View2 : ViewEndpoint<View2Model>
    {
        public View2(IHtmlTemplatingService templatingService) : base( Menu.Associates, "View2", "customer/view2" , templatingService)
        {

        }

        public override ViewTemplate<View2Model> GetTemplate(ViewDefinition definition, ApiRequest request)
        {
            return new ViewTemplate<View2Model>
            {
                Html = "<head></head><body><h1>View1 {{PageTitle}}</h1></body>",
                Model = new View2Model
                {
                    PageTitle = "Page Title"
                }
            };
        }
    }
}
