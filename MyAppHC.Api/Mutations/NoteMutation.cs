using Aplication.DTO;
using Aplication.Ports;
using Domain.Entities;
using FluentValidation;

namespace MyAppHC.Api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class NoteMutation
    {
        public async Task<Note> AddNote(CreateNoteDto input,
            [Service] ICommonService<Note> noteService,
            [Service] IValidator<CreateNoteDto> validator)
        {
            var validationResult = await validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
            .Select(e => ErrorBuilder.New()
                .SetMessage(e.ErrorMessage)
                .Build())
            .ToList();
                throw new GraphQLException(errors);
            }
            var note = new Note(0, input.ItemId, input.Message);
            await noteService.AddEntity(note);
            return note;
        }
    }
}
