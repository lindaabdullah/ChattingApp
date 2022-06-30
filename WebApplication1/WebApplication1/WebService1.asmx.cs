using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Services;
using WebApplication1.Models;


namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Model1 db = new Model1();
        
        // methods to show tables
        //------------------------------------------------
        [WebMethod]
        public List<Employee> AllEmployees()
        {
            return db.Employees.ToList();
        }
        
        [WebMethod]
        public List<LoginLog> AllLoginLogs()
        {
            return db.LoginLogs.ToList();
        }

        [WebMethod]
        public List<LogoutLog> AllLogoutLogs()
        {
            return db.LogoutLogs.ToList();
        }

        [WebMethod]
        public List<Chatting> AllChatting()
        {
            return db.Chattings.ToList();
        }

        //------------------------------------------------
        // methods to add to a table
        //------------------------------------------------

        [WebMethod]
        public void AddToLogoutLogs(string username)
        {
            db.LogoutLogs.Add(new LogoutLog
            {
                Username = username,
                Time = DateTime.Now
            });

            db.SaveChanges();
        }

        [WebMethod]
        public void AddToLogIn(string username)
        {
            db.LoginLogs.Add(new LoginLog
            {
                Username = username,
                Time = DateTime.Now
            });
            db.SaveChanges();
        }

        [WebMethod]
        public void AddEmployee(int ssn, string name, string surname, string username, string password, string email, string address)
        {
            db.Employees.Add(new Employee
            {
                SSN = ssn,
                Name = name,
                Surname = surname,
                Username = username,
                Password = password,
                Email = email,
                Address = address
            });
            db.SaveChanges();
        }

        [WebMethod]
        public void AddToChatting(string from, string to, string date, string msg, string type, string encrypted)
        {
            db.Chattings.Add(new Chatting  // add broad casted message to table in database
            {
                SenderUsername = from,
                RecieverUsername = to,
                DateSent = date,
                Message = msg,
                ChattingType = type,
                Encrypted = encrypted
            });
            db.SaveChanges();
        }
        //------------------------------------------------
    }

}
