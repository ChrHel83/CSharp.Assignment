using Business.Models;
using System.Security.Cryptography;

namespace Presentation.ConsoleApp.Main.Tests.Models;

public class ContactModel_Tests
{
    [Fact]
    public void ContactModel_ShouldCreateGIUD_WhenInstansiation()
    {
        //arrange
        ContactModel contact = new();
        //act  
        var result = contact.Id;
        //assert
        Assert.IsType<Guid>(result);
    }

    [Fact]
    public void ContactModel_
}
