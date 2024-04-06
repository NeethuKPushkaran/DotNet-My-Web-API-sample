using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    //simulated data source (replace this with a database or other datasource)
    private static List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Item1"},
            new Item { Id = 2, Name = "Item2"}
        };

    //GET: api/Items

    [HttpGet]

    public ActionResult<IEnumerable<Item>> Get()
    {
        return Ok(_items);
    }

    //GET: api/Items/5

    [HttpGet("{id}")]

    public ActionResult<Item> GetById(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    //POST: api/Items
    [HttpPost]

    public ActionResult<Item> Post([FromBody] Item newItem)
    {
        if (newItem == null)
        {
            return BadRequest("Invalid Request body.");
        }

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        newItem.Id = _items.Count + 1;
        _items.Add(newItem);

        return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
    }

    //PUT: api/Items/5

    [HttpPut ("{id}")]
    public IActionResult Put(int id, [FromBody] Item updatedItem)
    {
        if (updatedItem == null || id != updatedItem.Id)
        {
            return BadRequest("Invalid request body or mismatched ID's");
        }

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingItem = _items.FirstOrDefault(i => i.Id == id);
        
        if (existingItem == null)
        {
            return NotFound();
        }

        existingItem.Name = updatedItem.Name;

        return NoContent();
    }
}



