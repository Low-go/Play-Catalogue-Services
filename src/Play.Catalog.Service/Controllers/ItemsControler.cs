using System.Collections.Generic;
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

        };
    }
}