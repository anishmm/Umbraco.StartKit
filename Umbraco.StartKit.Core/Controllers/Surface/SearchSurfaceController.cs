using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.StartKit.Core.Models.ViewModels;
using Umbraco.StartKit.Core.Service;

namespace Umbraco.StartKit.Core.Controllers.Surface
{
    public class SearchController : RenderController
    {
        private IPublishedValueFallback _publishedValueFallback;
        private ISearchService _searchService;

        public SearchController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedValueFallback publishedValueFallback,
                ISearchService searchService) :
                base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _publishedValueFallback = publishedValueFallback;
            _searchService = searchService;


           // DocTypeAliases = new[] { "blog", "page", "caseStudy" };

        }

        public override IActionResult Index()
        {
            var query = Request.Query["q"].ToString();
 

            var sampleTypedContent = new SearchContentModel(CurrentPage);

            if (string.IsNullOrWhiteSpace(query))
            {
                return CurrentTemplate(sampleTypedContent);
            }
            if (!int.TryParse(Request.Query["page"].ToString(), out var Page))
            {
                Page = 1;
            }

            var viewModel = new SearchViewModel()
            {
                Query = query,
                Page = Page,
                PageSize = 10,
                totalItemCount = 0
            };

            viewModel.results = _searchService.QueryUmbraco(viewModel.Query, Page, out var totalItemCount, sampleTypedContent.DocTypeAliases, sampleTypedContent.SearchAliases, viewModel.PageSize);
            viewModel.totalItemCount = (int)totalItemCount;

            sampleTypedContent.viewModel = viewModel;



            return CurrentTemplate(sampleTypedContent);
        }
    }
}
