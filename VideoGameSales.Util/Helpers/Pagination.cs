using System;
using System.Collections.Generic;
using System.Linq;
using VideoGameSales.Core.Pagination;
using VideoGameSales.Domain.ViewModels.Games;

namespace VideoGameSales.Util.Helpers
{
    public class Pagination<T>
    {
        public PageResponse<T> createPaginationUri(PaginationQuery pageQ, IEnumerable<T> response, string nextPage, string lastPage)
        {
            var paginationResponse = new PageResponse<T>
            {
                Data = response,
                Page = pageQ.Page >= 1 ? pageQ.Page : (int?)null,
                PageSize = pageQ.PageSize >= 1 ? pageQ.PageSize : (int?)null,
                NextPage = response.Any() ?  nextPage : null,
                LastPage = lastPage 
            };
            return paginationResponse;

        }
    }
    public class GamesPagination : Pagination<GameViewModel>
    {
        public PageResponse<GameViewModel> pagination(UrlHelpers urlHelper, IEnumerable<GameViewModel> pokemons, PaginationQuery pageQ)
        {
            var nextPage = pageQ.Page >= 1 ? urlHelper.GetAllUri(new PaginationQuery(pageQ.Page + 1,  pageQ.PageSize)).ToString() : null;
            var lastPage = pageQ.Page > 1 ? urlHelper.GetAllUri(new PaginationQuery(pageQ.Page - 1,  pageQ.PageSize)).ToString() : null;
            return createPaginationUri(pageQ,pokemons,nextPage,lastPage);
        }
    }
}
