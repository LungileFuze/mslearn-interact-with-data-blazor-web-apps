using BlazingPizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Controllers;

[Route("specials")]
[ApiController]

public class SpecialController : Controller
{
    private readonly PizzaStoreContext _storeContext;

    public SpecialController(PizzaStoreContext pizzaStoreContext)
    {
        _storeContext = pizzaStoreContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        return (await _storeContext.Specials.ToListAsync()).OrderBy(s => s.BasePrice).ToList();
    }
}