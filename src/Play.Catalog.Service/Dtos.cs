using System;

// A Dto is a class or record used to carry data between parts of a program
// usually between server and client
namespace Play.Catalog.Service.Dtos
{
    // while this may look like a constructor 
    // its a c# feature called a record
    // like a constructor but for data 
    // quick thing that provides me with some features


    // Although these next two records may look similar they are different
    // the first is to retrieve info on the item when returning data dfrom the server, so it includes id
    // the second is to manually create, so only client
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    public record CreateItemDto(string Name, string Description, decimal Price);

    public record UpdateItemDto(string Name, string Description, decimal Price);

}