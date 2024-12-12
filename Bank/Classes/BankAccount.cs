using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace Bank.Classes
{
       
    public enum Status
    {
        Open, //открыт 
        Closed, // закрыт 
        Bankrupt //банкрот

    }
    /// <summary>
    /// int accountNumber, DateT dateOpen, double moneyAccount, DateT depositOpen, int depositPeriod // Срок вклада в месецах, Status status
    /// </summary>
    public class BankAccount
    {

        private int accountNumber; // номер счета
        private DateTime dateOpen; // Дата открытия счета
        private double moneyAccount; //Сумма на счету 
        private DateTime depositOpen; // Дата открытия вклада
        private int depositPeriod; // Срок вклада в месецах
        private Status status;//Статус 

        public double MoneyAccount
        {
            get { return this.moneyAccount; }
            set { this.moneyAccount = value; }
        }

        /// <summary>
        /// Считает день закрытия счета
        /// </summary>
        /// <returns></returns>
        private DateTime DepositClose()  // Дата окончания
        {
            DateTime close;
            close = this.depositOpen.AddMonths(this.depositPeriod);
            return close;
        }
        /// <summary>
        /// Смена статусо от количества денег на счете
        /// </summary>
        private void СhangeStatus()  // Изменение статуса
        {
            if (this.moneyAccount > 0)
                status = Status.Open;
            if (this.moneyAccount == 0)
                status = Status.Closed;
            if (this.moneyAccount < 0)
                status = Status.Bankrupt;  
        }
        /// <summary>
        /// inputOutput true - положить false - снять
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputOutput"></param>
        public bool InputMani(double input, bool inputOutput) // Внесение снятие 
        {
            if (inputOutput)
            {
                this.moneyAccount += input;
                this.СhangeStatus();
                return true;
            }
            else
            {
                if( this.moneyAccount >= input)
                {
                    this.moneyAccount -= input;
                    this.СhangeStatus();
                    return true;
                }
                else
                MessageBox.Show("Не достаточно средств для перевода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public int AccauntN()
        {
            return this.accountNumber;
        }
        /// <summary>
        /// Перевод с в дургой банк
        /// </summary>
        /// <param name="otherAccoune"></param>
        /// <param name="summa"></param>
        public bool Transfer(BankAccount otherAccoune, double summa)
        { 

            if(this.InputMani(summa, false))
            {
                otherAccoune.InputMani(summa, true);
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Временный результат 
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public String Sresult ()
        {
            string result;
             
            result = ( "Номер счета " + this.accountNumber + Environment.NewLine
                + "Дата открытия счета " + this.dateOpen.ToString("dd MMMM, yyyy") + Environment.NewLine
                + "Дата открытия вклада " + this.depositOpen.ToString("dd MMMM, yyyy") + Environment.NewLine
                + "Срок вклада " + this.depositPeriod + " Месецев" + Environment.NewLine
                + "Сумма на счету " + this.moneyAccount + " ₽" + Environment.NewLine
                + "Статус " + this.status );

            return result;
        }

        public static BankAccount operator +(BankAccount first, BankAccount second)
        {
            first.InputMani(second.moneyAccount, true);
            second.InputMani(second.moneyAccount, false);

            return first;
        }

        public static BankAccount operator %(BankAccount first, double percent)
        {
            percent = percent / 100;

            first.moneyAccount *= percent;

            return first;
        }

        public static BankAccount operator ++(BankAccount bankAccount)
        {
            bankAccount.moneyAccount *= 0.3; //0.3 Процента в месяц

            return bankAccount;
        }

        public static bool operator ==(BankAccount first, BankAccount second)
        {
            if (first.moneyAccount == second.moneyAccount ) 
                return true; 
            return false;
        }

        public static bool operator !=(BankAccount first, BankAccount second)
        {
            if (first.moneyAccount == second.moneyAccount)
                return false;
            return true;
        }
        public static BankAccount operator -(BankAccount bankAccount, double minus)
        {
            if (bankAccount.moneyAccount >= minus)
            {
                bankAccount.moneyAccount -= minus; 
            }
            else
            {
                MessageBox.Show("Не достаточно средств для перевода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return bankAccount;
            }
            return bankAccount;
        }

        public static BankAccount operator +(BankAccount bankAccount, double plas)
        {
            
                bankAccount.moneyAccount += plas; 

            return bankAccount;
        }
        public BankAccount()
        {
            this.accountNumber = 0;
            this.dateOpen = DateTime.Now;
            this.moneyAccount = 0;
            this.depositPeriod = 0;
            this.status = Status.Closed;
        }
        /// <summary>
        /// int accountNumber, DateT dateOpen, double moneyAccount, DateT depositOpen, int depositPeriod // Срок вклада в месецах, Status status
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="dateOpen"></param>
        /// <param name="moneyAccount"></param>
        /// <param name="depositOpen"></param>
        /// <param name="depositPeriod"></param>
        /// <param name="status"></param>
        public BankAccount(int accountNumber, DateTime dateOpen, double moneyAccount, DateTime depositOpen, int depositPeriod, Status status)
        {
            this.accountNumber = accountNumber;
            this.dateOpen = dateOpen;
            this.moneyAccount = moneyAccount;
            this.depositOpen = depositOpen;
            this.depositPeriod = depositPeriod;
            this.status = status;
        }
    }
}
