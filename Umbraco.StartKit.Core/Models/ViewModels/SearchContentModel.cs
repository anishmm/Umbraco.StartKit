using System.Collections.Generic;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;


namespace Umbraco.StartKit.Core.Models.ViewModels
{
    public class SearchContentModel : ContentModel
    {
        public SearchContentModel(IPublishedContent content) : base(content)
        {
            if (!string.IsNullOrWhiteSpace(content.Value<string>("docTypeAliases")))
            {
                DocTypeAliases = content.Value<string>("docTypeAliases")!.Split(',');
            }

            if (!string.IsNullOrWhiteSpace(content.Value<string>("searchAliases")))
            {
                SearchAliases = content.Value<string>("searchAliases")!.Split(',');
            }
            else
            {
                SearchAliases = new[] { "pageTitle", "Name", "pageBody" };
            }

        }
        public string[] DocTypeAliases { get; set; }
        public string[] SearchAliases { get; set; }
        public SearchViewModel viewModel { get; set; }
    }

    public class SearchViewModel
    {
        public string Query { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int totalItemCount { get; set; }
        public IEnumerable<IPublishedContent> results { get; set; }
    }
}
