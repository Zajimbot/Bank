using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public enum StatusS
    {
        open, //открыт 
        сlosed, // закрыт 
        bankrupt //банкрот

    }

    public class BankAccount
    {

        public int accountNumber { get; set; } // номер счета
        public DateTime dateOpen { get; set; } // Дата открытия счета
        public double moneyAccount { get; set; } //Сумма на счету 
        public DateTime depositOpen { get; set; } // Дата открытия вклада
        public int depositPeriod { get; set; } // Срок вклада в месецах
        public string status { get; set; } //Статус 

        private DateTime DepositClose()  // Дата окончания
        {
            DateTime close;
            close = this.depositOpen.AddDays(this.depositPeriod);
            return close;
        }
        private void СhangeStatus()  // Изменение статуса
        {
            if (this.moneyAccount > 0)
                status = Convert.ToString(StatusS.open);
            if (this.moneyAccount < 0)
                status = Convert.ToString(StatusS.bankrupt);
        }
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
            this.status = Convert.ToString( StatusS.сlosed);
        }
        public BankAccount(int accountNumber, DateTime dateOpen, double moneyAccount, DateTime depositOpen, int depositPeriod, StatusS status)
        {
            this.accountNumber = accountNumber;
            this.dateOpen = dateOpen;
            this.moneyAccount = moneyAccount;
            this.depositOpen = depositOpen;
            this.depositPeriod = depositPeriod;
            this.status = Convert.ToString( status);
        }
    }
}
