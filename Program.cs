class Program
{
    static void Main(string[] args)
    {
        var logginBroker = new LogginBroker();
        var fileHandler = new FileHandler();
        var contactService = new ContactService(fileHandler , logginBroker);

        while(true)
        {
            System.Console.WriteLine("\nChoose an option:");
            System.Console.WriteLine("1. Add Contact");
            System.Console.WriteLine("2. Delete Contact");
            System.Console.WriteLine("3. Update Contact");
            System.Console.WriteLine("4. View all Contact");
            System.Console.WriteLine("5. Search Contact");
            System.Console.WriteLine("6. Exit");

            var choise = Console.ReadLine();
            switch(choise)
            {
                case "1":
                System.Console.Write("Enter Name: ");
                var name = Console.ReadLine();
                System.Console.Write("Enter Phone: ");
                var phonNumber = Console.ReadLine();
                System.Console.Write("Enter Email: ");
                var email = Console.ReadLine();
                Contact newContact = new Contact
                {
                    Name = name,
                    PhoneNumber = phonNumber,
                    Email = email
                };
                contactService.AddContact(newContact);
                break;
                case "2":
                System.Console.Write("Enter the ID of the contact you want to delete: ");
                int contactId = int.Parse(Console.ReadLine());
                contactService.DeleteContact(contactId);
                break;
                case "3":
                System.Console.Write("Enter the ID of the contact you want to Edit: ");
                int contactId1 = int.Parse(Console.ReadLine());
                System.Console.Write("Enter new Name: ");
                string? newName = Console.ReadLine();
                System.Console.Write("Enter new Phone: ");
                string? newPhonNumber = Console.ReadLine();
                System.Console.Write("Enter new Email: ");
                string? newEmail = Console.ReadLine();
                contactService.UpdateContact(contactId1,newName,newPhonNumber,newEmail);
                break;
                case "4":
                contactService.AllViewContact();
                break;
                case "5":
                System.Console.Write("Enter contact name:");
                string? nameSearch = Console.ReadLine();
                contactService.SearchContact(nameSearch);
                break;
                case "6":
                return;
            }
        }
    }
}