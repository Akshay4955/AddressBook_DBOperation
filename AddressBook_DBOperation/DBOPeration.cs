using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;

namespace AddressBook_DBOperation;

public class DBOPeration
{
    private string connectionString;
    private SqlConnection connection;

    public DBOPeration(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void AddContact(Contact contact)
    {
        connection = new SqlConnection(connectionString);

        connection.Open();
        SqlCommand insertCommand = new SqlCommand("spAddNewContact", connection);
        insertCommand.CommandType = System.Data.CommandType.StoredProcedure;

        insertCommand.Parameters.AddWithValue("@firstName", contact.FirstName);
        insertCommand.Parameters.AddWithValue("@lastName", contact.LastName);
        insertCommand.Parameters.AddWithValue("@address", contact.Address);
        insertCommand.Parameters.AddWithValue("@phoneNumber", contact.PhoneNumber);
        insertCommand.Parameters.AddWithValue("@email", contact.Email);
        insertCommand.Parameters.AddWithValue("@city", contact.City);
        insertCommand.Parameters.AddWithValue("@state", contact.State);
        insertCommand.Parameters.AddWithValue("@zip", contact.Zipcode);

        insertCommand.ExecuteNonQuery();

        connection.Close();
    }

    public void UpdateContact(string data, int id)
    {
        connection = new SqlConnection(connectionString);

        connection.Open();
        string updateQuery = @"update address set city = @newCityName where addressId = @Id";
        SqlCommand updateCommand = new SqlCommand(updateQuery,connection);
        updateCommand.Parameters.AddWithValue("@newCityName", data);
        updateCommand.Parameters.AddWithValue("@Id", id);

        updateCommand.ExecuteNonQuery();

        connection.Close();
    }

    public void ReadContact()
    {
        connection = new SqlConnection(connectionString);

        connection.Open();
        string readQuery = @"select * from contact inner join address on contact.addressId = address.addressId";
        SqlCommand readCommand = new SqlCommand(readQuery,connection);
        SqlDataReader reader = readCommand.ExecuteReader();

        while (reader.Read())
        {
            Contact contact = new Contact();
            contact.FirstName = (string) reader["firstName"];
            contact.LastName = (string)reader["lastName"];
            contact.Address = (string)reader["address"];
            contact.City = (string)reader["city"];
            contact.State = (string)reader["state"];
            contact.Zipcode = reader["zip"].ToString();
            contact.PhoneNumber = (string)reader["phoneNumber"];
            contact.Email = (string)reader["email"];

            Console.WriteLine(contact);
        }

        connection.Close();
    }

    public void DeleteContact(int id)
    {
        connection = new SqlConnection (connectionString);
        connection.Open();
        string deleteQuery = @"delete contact where contactId = @Id";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
        deleteCommand.Parameters.AddWithValue("@Id", id);
        deleteCommand.ExecuteNonQuery();
        connection.Close();
    }
}
