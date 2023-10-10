using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Myticketchecker;
using Myticket;

class Program
{
    static bool IsAlphabetic(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }

    static string GetValidName(string prompt)
    {
        string name;
        do
        {
            Console.Write(prompt);
            name = Console.ReadLine();
        } while (!IsAlphabetic(name));

        return name;
    }
    
    static void Main(string[] args)
    {
        try{
        TicketChecker ticketChecker = new TicketChecker();

        while (true)
        {
            Console.WriteLine("1. Add ticket");
            Console.WriteLine("2. Check your ticket");
            Console.WriteLine("3. Display all tickets");
            Console.WriteLine("4. Clear the list of tickets");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Select the option: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Incorrect choice. Give a number from 1 to 5.");
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                try{
                    Console.Write("Enter ticket code: ");
                    string ticketCode = Console.ReadLine();
                    ticketChecker.AddTicket(ticketCode);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("The ticket code you entered is incorrect. Please try again. " + ex.Message);
                }
                    break;
                case 2:
                try{
                    Console.Write("Enter ticket code: ");
                    string ticketCode = Console.ReadLine();
                    ticketChecker.CheckTicket(ticketCode);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("The ticket code you entered is incorrect. Please try again. " + ex.Message);
                }
                    break;
                case 3:
                    ticketChecker.DisplayAllTickets();
                    break;
                case 4:
                    ticketChecker.ClearTickets();
                    break;
                case 5:
                    return;
            }

            Console.WriteLine();
        }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
