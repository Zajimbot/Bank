using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    public enum TransactStatus
    {
        Completed, //Выполнено 
        NotCompleted, // Не выполнено 
    }

    public enum NamingOperation
    {
        Withdrawal, // Снятие
        Refill, //Пополнение 
        Transfer // Перевод
    }

    internal class Transaction
    {
        private NamingOperation operation;
        private TransactStatus transactStatus;
        private double summa;
        private int accauntNumber;
        private DateTime dateTime;

        public NamingOperation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public String Sresult ()
        {
            string result;

            result = "Наименование операции " + operation + Environment.NewLine
                + "Сумма " + summa + Environment.NewLine
                + "Статус операции " + transactStatus + Environment.NewLine
                + "Номер акаунта " + accauntNumber + Environment.NewLine 
                + "Дата " + dateTime;

            return result;
        }

        public Transaction(NamingOperation operation, TransactStatus transactStatus, double summa, int accauntNumber)
        {
            this.operation = operation;
            this.transactStatus = transactStatus;
            this.summa = summa;
            this.accauntNumber = accauntNumber;
            this.dateTime = DateTime.Now; 
        }
    }
}
