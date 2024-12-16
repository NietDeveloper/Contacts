public class ContactService
{
    private readonly FileHandler fileHandler;
    private readonly LogginBroker logginBroker;

    public ContactService(FileHandler fileHandler , LogginBroker logginBroker)
    {
        this.fileHandler = fileHandler;
        this.logginBroker = logginBroker;
    }

    public void AddContact(Contact contact)
    {
        try
        {
            var contacts = fileHandler.ReadContacts();
            contact.Id = contacts.Count > 0 ? contacts.Max(c => c.Id) + 1 : 1;
            contacts.Add(contact);
            fileHandler.WriteContacts(contacts);
            logginBroker.LogInfo("Contact added successfully.");
        }
        catch(Exception exception)
        {
            logginBroker.LogException(exception);
        }
    }

    public void DeleteContact(int id)
    {
        try
        {
            var contacts = fileHandler.ReadContacts();
            var contactToDelete = contacts.FirstOrDefault(c => c.Id == id);
            if(contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                fileHandler.WriteContacts(contacts);
                logginBroker.LogInfo($"Contact with ID {id} deleted successfully.");
                System.Console.WriteLine($"Contact with ID {id} deleted successfully.");
            }
            else
            {
                logginBroker.LogWarning($"Contact with ID = {id} not found!");
                System.Console.WriteLine($"Contact with ID = {id} not found!");
            }
        }
        catch(Exception e)
        {
            logginBroker.LogError($"Error deleting contact:{e.Message}");
            System.Console.WriteLine($"Error deleting contact:{e.Message}");
        }
    }

    public void UpdateContact(int contactId1, string? newName, string? newPhonNumber, string? newEmail)
    {
        try
        {
            var contacts = fileHandler.ReadContacts();
            var contactToUpdate = contacts.FirstOrDefault(c => c.Id == contactId1);
            if(contactToUpdate != null)
            {
                contactToUpdate.Name = newName;
                contactToUpdate.PhoneNumber = newPhonNumber;
                contactToUpdate.Email = newEmail;
                fileHandler.WriteContacts(contacts);
                logginBroker.LogInfo($"Contact with ID :{contactId1} updated successfully!");
                System.Console.WriteLine($"Contact with ID :{contactId1} updated successfully!");
            }
            else
            {
                logginBroker.LogWarning($"Contact with ID {contactId1} not found!");
                System.Console.WriteLine($"Contact with ID {contactId1} not found!");
            }
        }
        catch(Exception e)
        {
            logginBroker.LogError($"ERROR updating contact: {e.Message}");
            System.Console.WriteLine($"ERROR updating contact: {e.Message}");
        }
    }

    public void AllViewContact()
    {
        try
        {
            var contacts = fileHandler.ReadContacts();
            if(contacts.Count == 0)
            {
                System.Console.WriteLine("No contacts found!");
                logginBroker.LogWarning("No contacts found in the file");
                return;
            }
            System.Console.WriteLine("ALL CONTACTS:");
            foreach(var contact in contacts)
            {
                System.Console.WriteLine($"Id:{contact.Id}, Name:{contact.Name}, Phone Number:{contact.PhoneNumber}, Email:{contact.Email}");
            }
            logginBroker.LogInfo("Displayed all contacts successfully.");
        }
        catch(Exception e)
        {
            logginBroker.LogError($"Error:{e.Message}");
            System.Console.WriteLine("An error occurred while displaying contacts!");
        }
    }

    public void SearchContact(string nameSearch)
    {
        try
        {
            var contacts = fileHandler.ReadContacts();
            if(contacts.Count == 0)
            {
                System.Console.WriteLine("Contact not found!");
                logginBroker.LogWarning("No contacts found in the file.");
            }

            var contactSearching = contacts.Where(c => c.Name == nameSearch);
            foreach(var contact in contactSearching)
            {
                System.Console.WriteLine($"Id:{contact.Id}, Name:{contact.Name}, Phone:{contact.PhoneNumber}, Email:{contact.Email}");
            } 
        }
        catch(Exception e)
        {
            logginBroker.LogError($"Error:{e.Message}");
            System.Console.WriteLine("An error occurred while searching for the contact!");
        }
    }
}