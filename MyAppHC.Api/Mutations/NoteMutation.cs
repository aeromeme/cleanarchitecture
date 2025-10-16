using Aplication.Ports;
using Domain.Entities;

namespace MyAppHC.Api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class NoteMutation
    {
        public async Task<Note> AddNote(Note input, [Service] ICommonService<Note> noteService)
        {
            await noteService.AddEntity(input);
            return input;
        }
    }
}
