using System;
using Microsoft.AspNetCore.WebUtilities;
using VideoGameSales.Core.Pagination;

namespace VideoGameSales.Util.Helpers
{
    public class UrlHelpers
    {
        private readonly string _baseUrl;
        public UrlHelpers(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public Uri GetAllUri(PaginationQuery pagination = null)
        {
            var _uri = new Uri(_baseUrl);
            if (pagination == null) return _uri;

            var modifieduri = QueryHelpers.AddQueryString(_baseUrl, "page", pagination.Page.ToString());
            modifieduri = QueryHelpers.AddQueryString(modifieduri, "pageSize", pagination.PageSize.ToString());
            return new Uri(modifieduri);
        }

        public Uri GetUri(string pokemonId)
        {
            return new Uri(_baseUrl + "/get/api/v1/{id}".Replace("{id}", pokemonId));
        }
    }
}
