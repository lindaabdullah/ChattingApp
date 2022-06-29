using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SuperUser.localhost1.WebService1 ws = new localhost1.WebService1();

            var command = Console.ReadLine();
            if (command == "show employees\n")
            {
                var ListOfEmployees = ws.AllEmployees();
                foreach (var emp in ListOfEmployees)
                {
                    Console.WriteLine($"Employee: SSN: {emp.SSN}, name: {emp.Name}, surname: {emp.Surname}, username: {emp.Username}, surname: {emp.Password}, email: {emp.Email}, address: {emp.Address}");
                }

            } 
        }
    }
}
