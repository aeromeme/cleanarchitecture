using Aplication.Ports;
using Domain.Entities;

namespace MyAppHC.Api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ItemQuery
    {
        public async Task<Item?> GetItem( int id, [Service] IService itemService)
        {
            return await itemService.getItemById(id);
        }
    }
}
