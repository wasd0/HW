using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexeevHW
{
    class Program
    {
        static void Main()
        {
            ATM atm = new ATM();
            atm.UserInfo("Гребенкин", "Вадим", "Юрьевич");
            atm.AddBalance(100, 1);
            atm.ShowBalance();
            atm.ConvertToDollars(-11);
            atm.ConvertToRubles(1);
            atm.ShowBalance();
            atm.AddBalance(1, 1);
            atm.ConvertToDollars(174);
            atm.ShowBalance();

            Console.ReadKey();
        }
        class ATM
        {
            #region Fields

            private static readonly string adress = "Терминал по адресу: Ул. Пушкина, дом Колотушкина";

            #endregion

            #region Properties

            private static double AtmRubles { get; set; }
            private static double AtmDollars { get; set; }
            private double Rubles { get; set; }
            private double Dollars { get; set; } 
            public string Surname { get; set; }
            public string Name { get; set; }
            public string MiddleName { get; set; }
            #endregion

            #region Constructors

           public ATM()
           {
               Console.WriteLine(adress);
               AtmDollars = 100;
               AtmRubles = 7300;
               Console.WriteLine($"Баланс термиала: {AtmRubles} рублей, {AtmDollars} долларов.");
           }

            #endregion

            #region Methods

            public void UserInfo(string Surname, string Name, string MiddleName)
            {
                Rubles = 0;
                Dollars = 0;
                Console.WriteLine($"Пользоватеь {Surname} {Name} {MiddleName}. На балансе: {Rubles} рублей, {Dollars} долларов.");
            }
            public void ShowBalance()
            {
                Console.WriteLine($"На балансе: {Rubles} рублей, {Dollars} долларов.");
            }
            public void ConvertToDollars(double CountRubles)
            {
                if (CountRubles >= 0)
                {
                    if (Rubles >= 73 && Rubles >= CountRubles)
                    {
                        Rubles -= CountRubles;
                        Console.WriteLine($"{CountRubles} рублей было конвертировано в {CountRubles * 0.014} долларов.");
                        CountRubles *= 0.014;
                        Dollars += CountRubles;
                    }
                    else
                        Console.WriteLine("Ошибка: на балансе недостаточно средств.");
                }
                else
                    Console.WriteLine("Ошибка: введено недопустимое значение.");
            }
            public void ConvertToRubles(double CountDollars)
            {
                if (CountDollars >= 0)
                {
                    if (Dollars >= 0 && Dollars >= CountDollars)
                    {
                        Dollars -= CountDollars;
                        Console.WriteLine($"{CountDollars} долларов было конвертировано в {CountDollars * 73.91} рублей.");
                        CountDollars *= 73.91;
                        Rubles += CountDollars;
                    }
                    else
                        Console.WriteLine("Ошибка: на балансе недостаточно средств.");
                }
                else
                    Console.WriteLine("Ошибка: введено недопустимое значение.");
            }
            public void AddBalance(double AddRubles, double AddDollars)
            {
                if (AddRubles >= 0 && AddDollars >= 0)
                {
                    AtmDollars += AddDollars;
                    AtmRubles += AddRubles;
                    Rubles += AddRubles;
                    Dollars += AddDollars;
                    Console.WriteLine($"Было пополнено {AddRubles} рублей, {AddDollars} долларов.");
                    Console.WriteLine($"Баланс терминала: {AtmRubles} рублей, {AtmDollars} долларов.");
                }
                else
                    Console.WriteLine("Ошибка: введено недопустимое значение.");
            }
            public void TakeBalance(double TakeRubles, double TakeDollars)
            {
                if (TakeRubles >= 0 && TakeDollars >= 0)
                {
                    if (AtmDollars >= TakeDollars && AtmRubles >= TakeRubles)
                    {
                        if (Rubles >= TakeRubles && Dollars >= TakeDollars)
                        {
                            AtmDollars -= TakeDollars;
                            AtmRubles -= TakeRubles;
                            Rubles -= TakeRubles;
                            Dollars -= TakeDollars;
                            Console.WriteLine($"Было снято {TakeRubles} рублей, {TakeDollars} долларов.");
                            Console.WriteLine($"Баланс терминала: {AtmRubles} рублей, {AtmDollars} долларов.");
                        }
                        else
                            Console.WriteLine("Ошибка: недостаточно средств на аккаунте.");
                    }
                    else
                        Console.WriteLine("Ошибка: недостаточно средств в банкомате.");
                }
                else
                    Console.WriteLine("Ошибка: введено недопустимое значение.");

            }
            #endregion
        }
    }
}
