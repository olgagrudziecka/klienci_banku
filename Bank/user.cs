using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//utworzenie klasy użytkownika banku 
public class User
{
    //
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Balance { get; set; }

    //utworzenie konstruktora użytkownika banku
    public User(string id, string firstName, string lastName, decimal balance)
    {
        //parametry konstruktora
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }
}
    
