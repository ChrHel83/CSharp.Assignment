﻿using Business.Models;
using Business.Services;
using System;

namespace Presentation.ConsoleApp.Main.Dialogs;

public class MenuDialogs
{
    private readonly ContactService _contactService = new();

    public void ShowMainMenu()
    {
        var isRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine("-------- KONTAKTLISTA --------");
            Console.WriteLine(" 1. Lägg till kontakt");
            Console.WriteLine(" 2. Visa alla kontakter");
            Console.WriteLine(" 3. Redigera kontakt");
            Console.WriteLine(" Q. Avsluta applikationen");
            Console.WriteLine("*******************************");
            Console.Write(" Menyval: ");

            var option = Console.ReadLine()!;

            Console.Clear();

            switch (option.ToLower())
            {
                case "1":
                ShowAddContact();
                break;

                case "2":
                ShowAllContacts();
                break;
                
                case "3":
                ShowEditContact();
                break;

                case "q":
                    Console.Clear();
                    OutputDialog("Tryck på någon tangent för att avsluta applikationen");
                    isRunning = false;
                    break;

                default:
                    OutputDialog("Felaktigt val. Försök igen");
                    break;
            }

        } while (isRunning);
    }
    public void ShowAddContact()
    {
        var contact = new ContactModel();
        Console.WriteLine("****** Lägg till kontakt ******");
        Console.Write(" Ange Förnamn: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write(" Ange Efternamn:");
        contact.LastName = Console.ReadLine()!;
        Console.Write(" Ange epostadress: ");
        contact.Email = Console.ReadLine()!;
        Console.Write(" Ange telefonnummer: ");
        contact.Phone = Console.ReadLine()!;
        Console.Write(" Ange gatuadress: ");
        contact.StreetAddress = Console.ReadLine()!;
        Console.Write(" Ange postnummer: ");
        contact.ZIPCode = Console.ReadLine()!;
        Console.Write(" Ange stad: ");
        contact.City = Console.ReadLine()!;

        _contactService.CreateContact(contact);
        _contactService.UpdateContactList();
        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn...");
        Console.ReadKey();
    }

    public void ShowAllContacts()
    {
        bool hasError;
        var contacts = _contactService.GetContactList(out hasError);

        Console.Clear();
        Console.WriteLine("**** Visa alla kontakter ****");
        Console.WriteLine("");
        if (hasError)
        {
            OutputDialog("Något gick fel. Försök igen senare");
            return;
        }

        if(!contacts.Any())
        {
            OutputDialog("Inga kontakter i listan. Tryck valfri tangent för att gå tillbaka");
            return;
        }

        foreach (var contact in contacts)
        {
            Console.WriteLine(contact.Id);
            Console.Write($"{contact.FirstName} {contact.LastName}");
            Console.Write("   ");
            Console.Write(contact.Email);
            Console.Write("   ");
            Console.Write(contact.Phone);
            Console.Write("   ");
            Console.Write(contact.StreetAddress);
            Console.Write(", ");
            Console.Write(contact.ZIPCode);
            Console.Write(" ");
            Console.WriteLine(contact.City);
            Console.WriteLine(new string('-', 100));
        }


        Console.ReadKey();
    }

    public void ShowEditContact()
    {
        Console.WriteLine("Redigera kontakter");
        Console.ReadKey();
    }
    public void OutputDialog(string msg)
    {
        Console.WriteLine(msg);
        Console.ReadKey();
    }
}
