using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kanban.Data;
using Kanban.Models;

namespace Kanban.Controllers
{
    public class CardsController : Controller
    {
        private readonly KanbanContext _context;

        public CardsController(KanbanContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Card.ToListAsync());
        }
        
        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("[controller]/containers/{containerId}/cards/create")]
        public async Task<IActionResult> Create(int containerId, [FromBody] CardDto card)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            if (!await ContainerExistsAsync(containerId))
                return NotFound();

            _context.Card.Add(new Card
            {
                Title = card.Title,
                Description = card.Description,
                ContainerId = containerId,
                
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("[controller]/containers/{containerId}/cards/edit/{cardId}")]
        public async Task<IActionResult> Edit(int containerId, int cardId, [FromBody] CardDto card)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbCard = await _context.Card.
                FirstOrDefaultAsync(c => c.Id == cardId && c.ContainerId == containerId);

            if (dbCard == null)
                return NotFound();
            
            dbCard.Title = card.Title;
            dbCard.Description = card.Description;
            
            await _context.SaveChangesAsync();
                
            return Ok();
        }

        // POST: Cards/Delete/5
        [HttpPost]
        [Route("[controller]/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _context.Card.FindAsync(id);
            if (card != null)
                _context.Card.Remove(card);

            await _context.SaveChangesAsync();
            return Ok();
        }

        private Task<bool> CardExistsAsync(int id)
        {
            return _context.Card.AnyAsync(e => e.Id == id);
        }
        
        private Task<bool> ContainerExistsAsync(int id)
        {
            return _context.Container.AnyAsync(e => e.Id == id);
        }
    }
}
