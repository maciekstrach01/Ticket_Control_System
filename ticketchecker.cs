using System;
using System.Collections.Generic;
using Myticket;

namespace Myticketchecker
{
class TicketChecker
{
    private List<Ticket> tickets;

    public TicketChecker()
    {
        tickets = new List<Ticket>();
    }

    public void AddTicket(string ticketCode)
    {
        int id;
        if (!int.TryParse(ticketCode, out id))
        {
            Console.WriteLine("Incorrect ticket code. Ticket code should be a number.");
            return;
        }

        Ticket existingTicket = tickets.Find(t => t.TicketId == id);
        if (existingTicket != null)
        {
            Console.WriteLine("A ticket with the given code already exists.");
            return;
        }

        Ticket newTicket = new Ticket();
        newTicket.TicketId = id;

        Console.Write("Client name: ");
        newTicket.FirstName = Console.ReadLine();

        Console.Write("Client surname: ");
        newTicket.LastName = Console.ReadLine();

        Console.Write("Ticket description: ");
        newTicket.Description = Console.ReadLine();

        tickets.Add(newTicket);
        Console.WriteLine("The ticket has been added.");
    }

    public bool CheckTicket(string ticketCode)
    {
        int id;
        if (!int.TryParse(ticketCode, out id))
        {
            Console.WriteLine("Incorrect ticket code. Ticket code should be a number.");
            return false;
        }

        Ticket ticket = tickets.Find(t => t.TicketId == id);
        if (ticket != null)
        {
            Console.WriteLine("The ticket with the given code has already been used.");
            return false;
        }

        Console.WriteLine("A ticket with the given code is valid.");
        return true;
    }

    public void ClearTickets()
    {
        tickets.Clear();
        Console.WriteLine("The list of checked tickets has been cleared.");
    }

    public void DisplayAllTickets()
    {
        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets to display.");
            return;
        }

        Console.WriteLine("All tickets:");
        foreach (Ticket ticket in tickets)
        {
            Console.WriteLine($"ID: {ticket.TicketId}");
            Console.WriteLine($"Client name: {ticket.FirstName}");
            Console.WriteLine($"Client surname: {ticket.LastName}");
            Console.WriteLine($"Ticket description: {ticket.Description}");
            Console.WriteLine();
        }
    }
}
}