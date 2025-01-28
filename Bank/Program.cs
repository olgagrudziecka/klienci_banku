using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        //tworzenie listy klientów banku
        var users = new List<User>();
        users.Add(new User("1", "Olga", "Grudziecka", 1000));
        users.Add(new User("2", "Szymon", "Dziuba", 1500));
        users.Add(new User("3", "Philip", "Duki", 2000));

        //wyświetlanie listy klientów banku 
        foreach (var user in users)
        {
            Console.WriteLine($"Imię: {user.FirstName} Nazwisko: {user.LastName} | saldo: {user.Balance} PLN");
        }

        //pobranie od użytkowanika numeru klienta
        Console.Write("Podaj swój numer klienta:");
        var userNumber = Console.ReadLine();

        //sprawdzanie czy wybrany użytkownik istnieje
        var selectedUser = users.FirstOrDefault(c => c.Id == userNumber);
        if (selectedUser != null)
        {
            Console.WriteLine($"Wybrałeś: {selectedUser.FirstName} {selectedUser.LastName} | saldo: {selectedUser.Balance}");
            Console.WriteLine("Podaj numer klienta, do którego chcesz wykonać przelew:");

            //pobranie od użytkownika numeru klienta, do którego chce wysłać przelew
            var recipientNumber = Console.ReadLine();
            var paymentUser = users.FirstOrDefault(c => c.Id == recipientNumber);
            if (paymentUser != null) //sprawdzanie czy użytkownik istnieje
            {
                //pobranie od użytkownika kwoty, którą chce przelać
                Console.WriteLine("Podaj kwotę przelewu: ");
                var text = Console.ReadLine();
                var czyDalosieZamienic = decimal.TryParse(text, out decimal result); //zamiana wpisanej przez użytkownika wartości na decimal
                if (czyDalosieZamienic)
                {
                    //sprawdzenie, czy użytkownik ma wystarczającą ilość pieniędzy na koncie
                    if (result <= selectedUser.Balance)
                    {
                        //obliczenie nowego salda klientów
                        selectedUser.Balance = selectedUser.Balance - result;
                        paymentUser.Balance = paymentUser.Balance + result;

                        Console.WriteLine($"Przelew wykonano! Nowe saldo:");
                        Console.WriteLine($"{selectedUser.FirstName} {selectedUser.LastName} | saldo: {selectedUser.Balance} PLN");
                        Console.WriteLine($"{paymentUser.FirstName} {paymentUser.LastName} | saldo: {paymentUser.Balance} PLN");
                    }
                    else
                    {
                        Console.WriteLine("Twoje saldo jest zbyt niskie, aby wykonać przelew!");
                    }
                }
                else
                {
                    Console.WriteLine("Podana kwota jest nieprawidłowa!");
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono klienta o podanym numerze.");
            }
        }
        else
        {
            Console.WriteLine("Nie znaleziono użytkownika o podanym numerze klienta.");
        }

        
        Console.ReadLine();
    }
}