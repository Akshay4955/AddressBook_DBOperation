﻿using System.Collections.Generic;
using System.Data.SqlClient;
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
}