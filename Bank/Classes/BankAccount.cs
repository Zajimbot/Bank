using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Bank.Classes
{
       
    public enum StatusS
    {
        open, //открыт 
        сlosed, // закрыт 
        bankrupt //банкрот

    }
    /// <summary>
    /// int accountNumber, DateTime dateOpen, double moneyAccount, DateTime depositOpen, int depositPeriod // Срок вклада в месецах, StatusS status
    /// </summary>
    public class BankAccount
    {

        private int accountNumber; // номер счета
        private DateTime dateOpen; // Дата открытия счета
        private double moneyAccount; //Сумма на счету 
        private DateTime depositOpen; // Дата открытия вклада
        private int depositPeriod; // Срок вклада в месецах
        private StatusS status;//Статус 

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
                status = StatusS.open;
            if (this.moneyAccount == 0)
                status = StatusS.сlosed;
            if (this.moneyAccount < 0)
                status = StatusS.bankrupt;  
        }
        /// <summary>
        /// inputOutput true - положить false - снять
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputOutput"></param>
        public void InputMani(double input, bool inputOutput) // Внесение снятие 
        {
            if (inputOutput)
            {
                this.moneyAccount += input;
                this.СhangeStatus();
            }
            else
            {
                if( this.moneyAccount >= input)
                {
                    this.moneyAccount -= input;
                    this.СhangeStatus();

                }
                else
                MessageBox.Show("Не достаточно средств для перевода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
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
        public void transfer(BankAccount otherAccoune, double summa)
        { 
            this.InputMani(summa, false);
            otherAccoune.InputMani(summa, true);
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


        public BankAccount()
        {
            this.accountNumber = 0;
            this.dateOpen = DateTime.Now;
            this.moneyAccount = 0;
            this.depositPeriod = 0;
            this.status = StatusS.сlosed;
        }
        /// <summary>
        /// int accountNumber, DateTime dateOpen, double moneyAccount, DateTime depositOpen, int depositPeriod // Срок вклада в месецах, StatusS status
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="dateOpen"></param>
        /// <param name="moneyAccount"></param>
        /// <param name="depositOpen"></param>
        /// <param name="depositPeriod"></param>
        /// <param name="status"></param>
        public BankAccount(int accountNumber, DateTime dateOpen, double moneyAccount, DateTime depositOpen, int depositPeriod, StatusS status)
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
