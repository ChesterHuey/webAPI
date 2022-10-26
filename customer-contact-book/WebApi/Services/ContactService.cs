using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Tables;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Services;
public class ContactService {
    private readonly ContactBookContext _context;

    public async Task<List<ContactModel>> GetAll() {
        var contacts = await _context.Contacts.ToListAsync();
        return contacts.Select(x => new ContactModel { Id = x.Id, FirstName = x.FirstName, }).ToList)();
    }
    public async Task<ContactModel> Create(ContactCreateModel model) {
        var newContact = new Contact
        {
            FirstName = model.FirstName,
        };
        await _context.Contacts.AddAsync(newContact);
        await _context.SaveChangesAsync();
        return new ContactModel { Id = newContact.Id, FirstName = newContact.FirstName, };
    }
    public ContactService(ContactBookContent context) {
        _context = context;
    }
}