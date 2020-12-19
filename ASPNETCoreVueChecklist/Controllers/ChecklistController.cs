using ASPNETCoreVueChecklist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNETCoreVueChecklist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ChecklistController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<int> Create(ChecklistItem item)
        {
            _dbContext.ChecklistItems.Add(item);
            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        [HttpGet]
        public async Task<IEnumerable<ChecklistItem>> Get()
        {
            var items = await _dbContext.ChecklistItems.ToListAsync();

            return items;
        }

        [HttpGet("{id}")]
        public async Task<ChecklistItem> Get(int id)
        {
            var item = await _dbContext.ChecklistItems.FirstOrDefaultAsync(item => item.Id == id);

            return item;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, ChecklistItem item)
        {
            var existingItem = await _dbContext.ChecklistItems.FirstOrDefaultAsync(i => i.Id == id);
            existingItem.Text = item.Text;
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.ChecklistItems.FirstOrDefaultAsync(item => item.Id == id);
            _dbContext.ChecklistItems.Remove(item);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
