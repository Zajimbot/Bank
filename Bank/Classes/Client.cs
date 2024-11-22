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
        private int passportSeries;
        public int PassportNumber;
        private DateTime birthDate; //Дата рождения 

        /// <summary>
        /// Временный результат
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public String Sresult() 
        {
            string result;

            result = ("ФИО " + this.surname + " " + this.name + " " + this.middleName + " " + Environment.NewLine
                + "Паспортные данные " + this.passportSeries + " " + this.PassportNumber + Environment.NewLine
                + "Дата рождения " + this.birthDate.ToString("dd MMMM, yyyy") + Environment.NewLine);

            return result;
        }

        public Client()
        {
            this.name = "";
            this.surname = "";
            this.middleName = "";
            this.passportSeries = 0;
            this.PassportNumber = 0;
            this.birthDate = DateTime.Now;
        }

        /// <summary>
        /// string name, string surname, string middleName, int passportNumber, DateTime birthВate
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="middleName"></param>
        /// <param name="passportNumber"></param>
        /// <param name="birthВate"></param>
        public Client(string name, string surname, string middleName, int passportSeries, int passportNumber, DateTime birthDate)
        {
            this.name = name;
            this.surname = surname;
            this.middleName = middleName;
            this.passportSeries = passportSeries;
            this.PassportNumber = passportNumber;
            this.birthDate = birthDate;
        }
    }
    
}
