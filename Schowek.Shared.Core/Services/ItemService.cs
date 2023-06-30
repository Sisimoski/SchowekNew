using System;
using Schowek.Shared.Core.Interfaces;
using Schowek.Shared.Domain.Models;

namespace Schowek.Shared.Core.Services
{
    public class ItemService : IItemService
	{
        private readonly IItemRepository itemRepository;

		public ItemService(IItemRepository itemRepository)
		{
            this.itemRepository = itemRepository;
		}

        public async Task<Item> AddItemAsync(Item item)
        {
            return await itemRepository.AddItemAsync(item);
        }

        public async Task<Item> DeleteItemAsync(int itemId)
        {
            return await itemRepository.DeleteItemAsync(itemId);
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            return await itemRepository.GetItemAsync(itemId);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemRepository.GetItemsAsync();
        }

        public async Task<Item?> UpdateItemAsync(int itemId, Item item)
        {
            return await itemRepository.UpdateItemAsync(itemId, item);
        }
    }
}

