namespace AddressBook_DBOperation;

internal class Program
{
    static void Main(string[] args)
    {
        List<Contact> contacts = new List<Contact>
        {
            new Contact("John", "Doe", "123 Main Street", "Cityville", "Stateville", "12345", "555-1234", "john.doe@example.com"),
            new Contact("Jane", "Smith", "456 Elm Street", "Townsville", "Stateville", "67890", "555-5678", "jane.smith@example.com"),
            new Contact("Michael", "Johnson", "789 Oak Avenue", "Villageville", "Stateville", "24680", "555-9123", "michael.johnson@example.com"),
            new Contact("Emily", "Davis", "987 Pine Drive", "Hamletville", "Stateville", "13579", "555-3456", "emily.davis@example.com"),
            new Contact("Robert", "Brown", "321 Cedar Lane", "Suburbville", "Stateville", "86420", "555-7890", "robert.brown@example.com"),
            new Contact("Sophia", "Miller", "654 Maple Court", "Ruraltown", "Stateville", "97531", "555-2345", "sophia.miller@example.com"),
            new Contact("William", "Wilson", "135 Cherry Road", "Countryside", "Stateville", "01357", "555-6789", "william.wilson@example.com"),
            new Contact("Olivia", "Anderson", "864 Walnut Street", "Metropolis", "Stateville", "79531", "555-9012", "olivia.anderson@example.com"),
            new Contact("James", "Taylor", "579 Birch Avenue", "Township", "Stateville", "31679", "555-3456", "james.taylor@example.com"),
            new Contact("Emma", "Clark", "302 Pine Lane", "Hometown", "Stateville", "54231", "555-7890", "emma.clark@example.com")
        };

        DBOPeration dBOPeration = new DBOPeration(@"Data Source = LAPTOP-9639UT7T; Database = addressbook_service_ADO; Integrated Security = True;");

        /*foreach(Contact contact in contacts)
        {
            dBOPeration.AddContact(contact);
        }*/

        dBOPeration.UpdateContact("Chinchwad", 3);
    }
}