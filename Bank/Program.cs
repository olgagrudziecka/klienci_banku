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
        users.Add(new User("3", "Philip", "Duki", 2137));
        users.Add(new User("4", "Horacy", "Nowak", 1000000));
        users.Add(new User("5", "Adama", "Kowal", 1908));
        users.Add(new User("6", "Tomasz", "Problem", 3485));
        users.Add(new User("7", "Zawisza", "Czarny", 8667));
        users.Add(new User("8", "Robert", "Lewandowski", 73891));
        users.Add(new User("9", "Aneta", "Żubr", 7618));
        users.Add(new User("10", "Ola", "Kartka", 4029));

        //wyświetlanie listy klientów banku 
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id} Imię: {user.FirstName} Nazwisko: {user.LastName} | saldo: {user.Balance} PLN");
        }

        //pobranie od użytkowanika numeru klienta
        Console.WriteLine(" ");
        Console.Write("Podaj swój numer klienta:");
        var userNumber = Console.ReadLine();

        //sprawdzanie czy wybrany użytkownik istnieje
        var selectedUser = users.FirstOrDefault(c => c.Id == userNumber);
        if (selectedUser != null)
        {   
            int choice;
            do //stworzenie pętli do-while do kilkurotnych przelewów w jednej sesji
            { 
                Console.WriteLine(" ");
                Console.WriteLine($"Wybrałeś: {selectedUser.FirstName} {selectedUser.LastName} | saldo: {selectedUser.Balance}");
                Console.WriteLine("Podaj numer klienta, do którego chcesz wykonać przelew:");

                //pobranie od użytkownika numeru klienta, do którego chce wysłać przelew
                var recipientNumber = Console.ReadLine();
                var paymentUser = users.FirstOrDefault(c => c.Id == recipientNumber);
                if (paymentUser != null) //sprawdzanie czy użytkownik istnieje
                {
                    //pobranie od użytkownika kwoty, którą chce przelać
                    Console.WriteLine(" ");
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

                            Console.WriteLine(" ");
                            Console.WriteLine($"Przelew wykonano! Nowe saldo:");
                            Console.WriteLine(" ");
                            Console.WriteLine($"{selectedUser.FirstName} {selectedUser.LastName} | saldo: {selectedUser.Balance} PLN");
                            Console.WriteLine($"{paymentUser.FirstName} {paymentUser.LastName} | saldo: {paymentUser.Balance} PLN");
                            Console.WriteLine(" ");

                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Twoje saldo jest zbyt niskie, aby wykonać przelew!");
                            Console.WriteLine(" ");
                        }
                    }   
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Podana kwota jest nieprawidłowa!");
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Nie znaleziono klienta o podanym numerze.");
                    Console.WriteLine(" ");
                }
                //zapytanie o kolejny przelew
                Console.WriteLine("Czy chcesz wykonać kolejny przelew? (1 - Tak, 2 - Nie)");
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2)) //sprawdzenie poprawności wpisanych przez użytkownika danych
                {
                    Console.WriteLine("Niepoprawny wybór. Wciśnij 1, aby kontynuować lub 2, aby zakończyć.");
                }

            } while (choice == 1); //jeśli 1 to wracamy do "do" i robimy kolejny przelew
        }
        else
        {
            Console.WriteLine(" ");
            Console.WriteLine("Nie znaleziono użytkownika o podanym numerze klienta.");
        }
        //pożegnanie klienta
        Console.WriteLine(" ");
        Console.WriteLine("Dziękujemy za skorzystanie z banku!");
        Console.ReadLine();
    }
}