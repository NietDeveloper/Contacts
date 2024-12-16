using System.Text.Json;

public class FileHandler
{
    private readonly string filePath = "contacts.txt";

    public List<Contact>? ReadContacts()
    {
        if(!File.Exists(filePath))
        {
             return new List<Contact>();
        }
        string json = File.ReadAllText(filePath);
        return string.IsNullOrEmpty(json)? new List<Contact>() 
                                         : JsonSerializer.Deserialize<List<Contact>>(json);
    }

    public void WriteContacts(List<Contact> contacts)
    {
        string json = JsonSerializer.Serialize(contacts);
        File.WriteAllText(filePath, json);
    }
}