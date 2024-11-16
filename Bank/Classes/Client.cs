using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    /// <summary>
    /// string name, string surname, string middleName, int passportNumber, DateTime birthВate
    /// </summary>
    internal class Client
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String middleName { get; set; }
        public int passportNumber { get; set; }
        public DateTime birthВate { get; set; }
        public Client()
        {
            this.name = "";
            this.surname = "";
            this.middleName = "";
            this.passportNumber = 0;
            this.birthВate = DateTime.Now;
        }

        /// <summary>
        /// string name, string surname, string middleName, int passportNumber, DateTime birthВate
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="middleName"></param>
        /// <param name="passportNumber"></param>
        /// <param name="birthВate"></param>
        public Client(string name, string surname, string middleName, int passportNumber, DateTime birthВate)
        {
            this.name = name;
            this.surname = surname;
            this.middleName = middleName;
            this.passportNumber = passportNumber;
            this.birthВate = birthВate;
        }
    }
    
}
