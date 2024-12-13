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
        private int accauntNumberT;
        private DateTime dateT;

        public NamingOperation Operation
        {
            get { return operation; }
        }

        public TransactStatus TransactStatus
        {
            get { return transactStatus; }
        }
        public int AccauntNumberT
        { 
            get { return accauntNumberT; }
        }
        public DateTime DateT
        {
            get { return dateT; }
        }

        public String Sresult ()
        {
            string result;

            result = "Наименование операции " + operation + Environment.NewLine
                + "Сумма " + String.Format("{0:.##}", summa) + Environment.NewLine
                + "Статус операции " + transactStatus + Environment.NewLine
                + "Номер акаунта " + accauntNumberT + Environment.NewLine 
                + "Дата " + dateT;

            return result;
        }

        public Transaction(NamingOperation operation, TransactStatus transactStatus, double summa, int accauntNumber)
        {
            this.operation = operation;
            this.transactStatus = transactStatus;
            this.summa = summa;
            this.accauntNumberT = accauntNumber;
            this.dateT = DateTime.Now; 
        }
    }
}
