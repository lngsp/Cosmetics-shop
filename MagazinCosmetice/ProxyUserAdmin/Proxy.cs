/**************************************************************************
 *                                                                        *
 *  File:        Proxy.cs                                                 *
 *  Copyright:   (c) 2022, Alexandra-Catalina Poleac                      *
 *  Description: Aplicatie pentru administrare magazin de cosmetice       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyUserAdmin
{
    /// <summary>
    /// Clasa care se ocupa de autentificarea clientilor
    /// </summary>
    public class Proxy
    {
        private List<User> _clienti;
        private const string Folder = "Clienti\\";

        /// <summary>
        /// Structura cu campurile "Nume" si "Parola" specifice fiecarui cont
        /// </summary>
        public struct User
        {
            public readonly string Username;
            public readonly string Password;

            /// <summary>
            /// Constructorul pentru crearea contului
            /// </summary>
            /// <param name="username">Numele clientului</param>
            /// <param name="password">Parola contului</param>
            public User(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }
        /// <summary>
        /// Constructorul clasei care are rolul de a actualiza lista conturilor din fisier
        /// </summary>
        public Proxy()
        {
            try
            {
                _clienti = new List<User>();
                StreamReader reader = new StreamReader(Folder + "clienti.txt");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] clienti = line.Split(',');
                    User user = new User(clienti[0], clienti[1]);
                    _clienti.Add(user);
                }
                reader.Close();

            }
            catch (Exception exceptie)
            {
                Console.WriteLine(exceptie);
            }

        }

        /// <summary>
        /// Metoda de autentificare
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True in cazul in care numele si parola clientului sunt existente, False in caz contrar</returns>
        public bool Login(string username, string password)
        {
            foreach (User u in _clienti)
            {
                if (u.Username.Equals(username) && u.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
