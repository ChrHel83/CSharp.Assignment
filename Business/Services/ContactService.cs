using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class ContactService
{
    private readonly FileService _fileService = new();
    private List<ContactModel> _contactList = [];

    public void CreateContact(ContactModel model)
    {
        _contactList.Add(model);

        //var json = JsonSerializer.Serialize(_contactList);
        //_fileService.SaveContentToFile(json);

        //UpdateContactList();
    }

    public void UpdateContactList()
    {
        var json = JsonSerializer.Serialize(_contactList);
        _fileService.SaveContentToFile(json);
    }

    public IEnumerable<ContactModel> GetContactList(out bool hasError)
    {
        hasError = false;
        var json = _fileService.GetContentFromFile();

        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                _contactList = JsonSerializer.Deserialize<List<ContactModel>>(json) ?? [];
            }
            catch
            {
                hasError = true;
            }
        }
        return _contactList;
    }

}
