using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Common
{
    public static class PagingExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int take)
        {
            page = page < 1 ? 1 : page;
            take = take < 1 ? 10 : take;

            var total = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * take)
                .Take(take)
                .ToListAsync();

            return new DataCollection<T>
            {
                Items = items,
                Total = total,
                Page = page,
                PageSize = take,
                Pages = (int)Math.Ceiling(
                    total / (double)take)
            };
        }
    }
}

