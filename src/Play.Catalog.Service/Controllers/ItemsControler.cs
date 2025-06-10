using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{

    // https://localhost:5001/items
    // these are attributes, go above what they apply to

    [ApiController]       // tells that this is a webapicontroller
    [Route("items")]      //  sets url route for this controller. Root


    // the : means inherits from a class and it is similar to
    // javas extends
    public class ItemsController : ControllerBase
    {

        // Private this variable is only accessible isnide this class
        // static means it belongs to the class itself, not to an obect 
        // so when something is static it is shared among all instances of every object
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures Poison", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze Sword", "Deals a small amount of Damage", 20, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        // Get /items/ the following would be the captured route {id}
        [HttpGet("{id}")]
        public ItemDto GetById(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return item;
        }

        [HttpPost]
        // receives object, destructures object into the post request
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);


            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
    }
}