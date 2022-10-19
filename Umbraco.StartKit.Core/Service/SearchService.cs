using Examine;
using Examine.Search;
using Lucene.Net.Analysis.Core;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using static Umbraco.Cms.Core.Constants;


namespace Umbraco.StartKit.Core.Service
{
    public interface ISearchService
    {
        IEnumerable<IPublishedContent> QueryUmbraco(string searchTerm, int pageNumber, out long totalItemCount, string[] docTypeAliases, string[] searchAliases, int pageSize = 10);
    }

    public class SearchService : ISearchService
    {
        private IExamineManager _examineManager;
        private ILogger<SearchService> _logger;
        private IUmbracoContextAccessor _context;
        private IContentService _contentService;

        public SearchService(
            IExamineManager examineManager,
            ILogger<SearchService> logger,
            IUmbracoContextAccessor context,
            IContentService contentService)
        {
            _examineManager = examineManager;
            _logger = logger;
            _context = context;
            _contentService = contentService;
        }


        public IEnumerable<IPublishedContent> QueryUmbraco(string searchTerm, int pageIndex, out long totalItemCount, string[] docTypeAliases, string[] searchAliases, int pageSize = 10)
        {
            IEnumerable<IPublishedContent> results = null;
            searchTerm = searchTerm.Trim();

            try
            {
                if (_examineManager.TryGetIndex(UmbracoIndexes.ExternalIndexName, out var index))
                {
                    var searcher = index.Searcher;


                    var criteria = searcher.CreateQuery();
                    /*

                    var examineQuery = criteria
                        .NodeTypeAlias("page").Or()
                        .NodeTypeAlias("blog").Or()
                        .NodeTypeAlias("casestudy").And()
                        .GroupedNot(new string[] { "umbracoNaviHide", "hideFromSearch" }, new string[] { "1" });

                    */

                    IBooleanOperation examineQuery;
                    if (docTypeAliases != null)
                    {
                        examineQuery = criteria
                            .GroupedOr(new string[] { "__NodeTypeAlias" }, docTypeAliases)
                            .And()
                            .GroupedNot(new string[] { "umbracoNaviHide", "hideFromSearch" }, new string[] { "1" });
                    }
                    else
                    {
                        examineQuery = criteria
                            .GroupedNot(new string[] { "umbracoNaviHide", "hideFromSearch" }, new string[] { "1" });
                    }



                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        if (searchTerm.Contains(" "))
                        {
                            string[] terms = searchTerm.Split(' ');
                            examineQuery.And().GroupedOr(searchAliases, terms);
                        }
                        else
                        {
                            examineQuery.And().GroupedOr(searchAliases, searchTerm.MultipleCharacterWildcard());
                        }
                    }
                    examineQuery.OrderByDescending(new SortableField[] { new SortableField("publishedOn") });


                    int skip = pageIndex > 1 ? (pageIndex - 1) * pageSize : 0;

                    var queryOptions = new QueryOptions(skip, pageSize);


                    ISearchResults searchResult = examineQuery.Execute(queryOptions);
                    var sortedResults = searchResult.OrderByDescending(x => x.Score);
                    results = sortedResults.Select(x => GetUmbracoObject(int.Parse(x.Id)));
                    totalItemCount = Convert.ToInt32(searchResult.TotalItemCount);
                    return results;


                }
            }
            catch (Exception e)
            {
            }
            totalItemCount = 0;
            return results;
        }

        private IPublishedContent GetUmbracoObject(int id)
        {
            var cache = _context.GetRequiredUmbracoContext();
            return cache.Content.GetById(id);

        }
    }

}
