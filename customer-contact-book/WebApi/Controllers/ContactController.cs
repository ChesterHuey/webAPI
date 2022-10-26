using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

public class ContactCotroller : ControllerBase
{
    private readonly ContactService _contactService;
    [HttpPost]
    public Task<IActionResult> Post([FromBody] ContactCreateModel model) {
        var result = await _contactService.Create(model);
        retunr Ok(result);
    }
    public CustomerController(ContactService contactService) {
        _contactService = contactService;
    }
}