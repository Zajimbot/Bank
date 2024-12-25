using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    /// <summary>
    /// string name, string surname, string middleName, int passportNumber, DateT birthВate
    /// </summary>
    [Serializable]
    internal class Client
    {
        private String name;
        private String surname;
        private String middleName;
        private int passportSeries;
        private int passportNumber;
        private DateTime birthDate; //Дата рождения 

        [DataMember]
        public String Name { get { return name; } }
        [DataMember]
        public String Surname { get { return surname; } }
        [DataMember]
        public String MiddleName { get { return middleName; } }
        [DataMember]
        public int PassportSeries { get { return passportSeries; } }
        [DataMember]
        public int PassportNumber { get { return passportNumber; } }
        [DataMember]
        public DateTime BirthDate { get {  return birthDate; } }

        /// <summary>
        /// Временный результат
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public String Sresult() 
        {
            string result;

            result = ("ФИО " + this.surname + " " + this.name + " " + this.middleName + " " + Environment.NewLine
                + "Паспортные данные " + this.passportSeries + " " + this.passportNumber + Environment.NewLine
                + "Дата рождения " + this.birthDate.ToString("dd MMMM, yyyy") + Environment.NewLine);

            return result;
        }

        public String FI()
        {
            string result;

            result = this.surname + " " + this.name;

            return result;
        }

        public Client()
        {
            this.name = "";
            this.surname = "";
            this.middleName = "";
            this.passportSeries = 0;
            this.passportNumber = 0;
            this.birthDate = DateTime.Now;
        }

       
        /// <summary>
        /// string name, string surname, string middleName, int passportNumber, DateT birthВate
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
            this.passportNumber = passportNumber;
            this.birthDate = birthDate;
        }
    }
    
}
