using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
       
    public enum StatusS
    {
        open, //открыт 
        сlosed, // закрыт 
        bankrupt //банкрот

    }
    /// <summary>
    /// int accountNumber, DateTime dateOpen, double moneyAccount, DateTime depositOpen, int depositPeriod, StatusS status
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
            close = this.depositOpen.AddDays(this.depositPeriod);
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
            }
            else
            {
                if( this.moneyAccount > input)
                this.moneyAccount -= input;
            }
        }
        /// <summary>
        /// Перевод с в дургой банк
        /// </summary>
        /// <param name="otherAccoune"></param>
        /// <param name="summa"></param>
        public void transfer(BankAccount otherAccoune, double summa)
        {
            if(this.moneyAccount > summa)
            {
                otherAccoune.moneyAccount += summa;
                this.moneyAccount -= summa;
            }
            else
            {
                //денег не достаточно для перевода позже отражу в интерфейсе
            }
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
        /// int accountNumber, DateTime dateOpen, double moneyAccount, DateTime depositOpen, int depositPeriod, StatusS status
        /// </summary>
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
