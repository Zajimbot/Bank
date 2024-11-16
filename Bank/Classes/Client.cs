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
        private String name;
        private String surname;
        private String middleName;
        private int passportNumber;
        private DateTime birthВate;

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
