using Bogus;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var faker = new Faker<Product>()
            // Generate fake data for each property
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => float.Parse(f.Commerce.Price(min: 7, max: 1045340)))
            .RuleFor(p => p.ExpireDate, f => f.Date.Future(2))  // Expires within the next 2 years
            .RuleFor(p => p.Inventory, f => f.Random.Int(0, 100));  // Random inventory between 0 and 100

        List<Product> products = faker.Generate(new Random().Next(5, 100));

        return Ok(products);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id > 5000)
            id = 5000;
        if (id < 1)
            id = 1;

        var faker = new Faker<Product>()
            // Generate fake data for each property
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => float.Parse(f.Commerce.Price(min: 7, max: 1045340)))
            .RuleFor(p => p.ExpireDate, f => f.Date.Future(2))  // Expires within the next 2 years
            .RuleFor(p => p.Inventory, f => f.Random.Int(0, 100));  // Random inventory between 0 and 100

        List<Product> products = faker.Generate(5000);
        var product = products.Where(_ => _.Id == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}