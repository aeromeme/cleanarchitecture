
using Aplication.Ports;
using Domain.Entities;
using HotChocolate;

namespace MyAppHC.Api.Mutations
{
    public class ItemMutation
    {
        public async Task<Item> AddItem(string title, [Service] IService itemService)
        {
            await itemService.addItem(title);
            // Si tu servicio retorna el nuevo Item, puedes devolverlo directamente.
            // Aquí se asume que el nuevo Item tiene el título y está incompleto.
            return new Item(0, title, false); // Ajusta según tu lógica real.
        }
    }
}

