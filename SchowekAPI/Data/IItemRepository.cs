using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchowekAPI.Models;

namespace SchowekAPI.Data
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItems();
        Task<Item> GetItem(int itemId);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<Item> DeleteItem(int itemId);
    }
}