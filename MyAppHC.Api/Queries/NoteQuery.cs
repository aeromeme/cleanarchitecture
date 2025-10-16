using Aplication.Ports;
using Domain.Entities;

namespace MyAppHC.Api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class NoteQuery
    {
        public async Task<Note?> GetNote(int id, [Service] ICommonService<Note> noteService)
        {
            return await noteService.GetById(id);
        }
    }
}

