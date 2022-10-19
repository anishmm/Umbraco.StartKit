using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.StartKit.Core.Service;

namespace Umbraco.StartKit.Core.Composer
{
    public class RegisterServiceComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddTransient<ISearchService, SearchService>();
        }
    }
}
