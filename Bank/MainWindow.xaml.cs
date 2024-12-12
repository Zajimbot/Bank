using Bank.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<BankAccount> bankAccountsL = new List<BankAccount>();
        List<Client> clients = new List<Client>();
        List<Transaction> transactionsL = new List<Transaction>();


        private String Result(Client user, BankAccount account)
        {
            string result;

            result = user.Sresult();
            result += account.Sresult();

            return result;
        }

        public void OutListBankAccounts()
        {
            ListR.Clear();

            foreach(var tuple in bankAccountsL.Zip(clients, (item1, item2) => (item1, item2)))
            {

                ListR.Text += tuple.item2.Sresult() ;
                ListR.Text += tuple.item1.Sresult() + Environment.NewLine + "***********************" + Environment.NewLine;
            }
            TransactionsList.Text = String.Empty;

            foreach (var tuple in transactionsL)
            {
                TransactionsList.Text += tuple.Sresult() + Environment.NewLine + "***********************" + Environment.NewLine; ;
            }

        }

        private void AddComboBox(Client user, BankAccount account)
        {
            ComboList.Items.Add(user.FI() + Environment.NewLine + "Accaunt namber " + account.AccauntN());
            ComboListOUT.Items.Add(user.FI() + Environment.NewLine + "Accaunt namber " + account.AccauntN());
            ComboListIN.Items.Add(user.FI() + Environment.NewLine + "Accaunt namber " + account.AccauntN());
            ComboListTrans.Items.Add(user.FI() + Environment.NewLine + "Accaunt namber " + account.AccauntN());
            ComboListSort.Items.Add(user.FI() + Environment.NewLine + "Accaunt namber " + account.AccauntN());
        }
       
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
           

            int accountNumber;
            double moneyAccount;
            int depositPeriod;
            DateTime birthDate;
            int passportSeries;
            int papassportNumber;
           
            DateTime dateOpen;
            DateTime depositOpen;
            Status status;
              
            try //Проверки 
            {
                accountNumber = Convert.ToInt32(AccountNumber.Text);
                moneyAccount = Convert.ToDouble(MoneyAccount.Text);
                depositPeriod = Convert.ToInt32(DepositPeriod.Text);
                birthDate = Convert.ToDateTime(Вirth.Text);
                passportSeries = Convert.ToInt32(PassportSeries.Text);
                papassportNumber = Convert.ToInt32(PassportNumber.Text);

                if (accountNumber < 0 || depositPeriod < 0 )
                {
                    MessageBox.Show("Некоторые данные не могут быть меньше 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if(passportSeries < 1000 || passportSeries > 9999 || papassportNumber < 100000 || papassportNumber > 999999)
                {
                    MessageBox.Show("Паспортные данные введены не коректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                foreach (var item in bankAccountsL)
                {
                    if (accountNumber == item.AccauntN())
                    {
                        MessageBox.Show("Номер акаунта не может совподать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string name = Name.Text;
            string surname = Surname.Text;
            string middleName = MiddleName.Text;
            dateOpen = DateTime.Now; // Обьявления Текущей даты и статуса ниже 
            depositOpen = DateTime.Now;
            status = Status.Open;
            BankAccount account1 = new BankAccount(accountNumber, dateOpen, moneyAccount, depositOpen, depositPeriod, status); //два конструктора 

            Client user1 = new Client(name, surname, middleName, passportSeries, papassportNumber, birthDate);

            String result; //Переменная в котрой записывается временный результат 

            result = Result(user1, account1);

            bankAccountsL.Add(account1);
            clients.Add(user1);

            AddComboBox(user1, account1);
            
            User1TB.Text = result;

            OutListBankAccounts();
            
        }
        private void TransferB_Click(object sender, RoutedEventArgs e)
        {
            double summa;
            if (ComboListOUT.SelectedIndex == -1)
            {
                MessageBox.Show("Комбобокс пустой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ComboListIN.SelectedIndex == -1)
            {
                MessageBox.Show("Комбобокс пустой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(ComboListOUT.SelectedIndex == ComboListIN.SelectedIndex)
            {
                MessageBox.Show("Нельзя выбрать одинаковые счета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int input;
            int output;
            try
            {
                summa = Convert.ToDouble(Transfer1TB.Text);
                input = ComboListIN.SelectedIndex;

                output = ComboListOUT.SelectedIndex;

                if (summa < 0)
                {
                    MessageBox.Show("Сумма для перевода не может быть отрицательной", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    //Transaction transaction = new Transaction(NamingOperation.Transfer, TransactStatus.NotCompleted,summa, bankAccountsL[input].AccauntN());  //Ненадо
                    //Transaction transaction2 = new Transaction(NamingOperation.Refill, TransactStatus.NotCompleted, summa, bankAccountsL[output].AccauntN());
                    //OutListBankAccounts();
                    return;
                }

            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           

            if(bankAccountsL[output].Transfer(bankAccountsL[input], summa))
            {
                Transaction transaction = new Transaction(NamingOperation.Refill, TransactStatus.Completed, summa, bankAccountsL[input].AccauntN());
                transactionsL.Add(transaction);
                Transaction transaction2 = new Transaction(NamingOperation.Transfer, TransactStatus.Completed, summa, bankAccountsL[output].AccauntN());
                transactionsL.Add(transaction2);
            }
            else
            {
                Transaction transaction = new Transaction(NamingOperation.Refill, TransactStatus.NotCompleted, summa, bankAccountsL[input].AccauntN());
                transactionsL.Add(transaction);
                Transaction transaction2 = new Transaction(NamingOperation.Transfer, TransactStatus.NotCompleted, summa, bankAccountsL[output].AccauntN());
                transactionsL.Add(transaction2);
            }
           

            OutListBankAccounts();
        }

        private void ButtonListR_Click(object sender, RoutedEventArgs e)
        {
            if (ComboList.SelectedIndex == -1)
            {
                MessageBox.Show("Комбобокс пустой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int index = ComboList.SelectedIndex;
            TextNowUser.Text += clients[index].Sresult() + Environment.NewLine;
            TextNowUser.Text = bankAccountsL[index].Sresult();
        }

        private void ManiTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (ComboListTrans.SelectedIndex == -1)
            {
                MessageBox.Show("Комбобокс пустой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int index = ComboListTrans.SelectedIndex;

            double summa;
            Transaction transaction;
            try
            {

                if (TopAccountText.Text != "" && WithdrawMoney.Text != "")
                {
                    MessageBox.Show("Нельзя одновременно пополнить и снять деньги со счета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (TopAccountText.Text == "" && WithdrawMoney.Text == "")
                {
                    MessageBox.Show("Поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (TopAccountText.Text != "")
                {
                    summa = Convert.ToDouble(TopAccountText.Text);
                    transaction = new Transaction(NamingOperation.Refill, TransactStatus.Completed, summa, bankAccountsL[index].AccauntN());
                    transactionsL.Add(transaction);
                }
                else
                {
                    summa = Convert.ToDouble(WithdrawMoney.Text);
                    if(summa <= bankAccountsL[index].MoneyAccount)
                    {
                        summa = summa * (-1);
                        transaction = new Transaction(NamingOperation.Withdrawal, TransactStatus.Completed, summa * -1, bankAccountsL[index].AccauntN());
                        transactionsL.Add(transaction);
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        transaction = new Transaction(NamingOperation.Withdrawal, TransactStatus.NotCompleted, summa * -1, bankAccountsL[index].AccauntN());
                        transactionsL.Add(transaction);
                        OutListBankAccounts();
                        return;
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            bankAccountsL[index] += summa;
            
            OutListBankAccounts();
        }

        private void TransuctSort_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = e.Source as Button;

            TransactionsList.Text = string.Empty;

            int day = 0;

            if (DayAdd.Text != "")
            {
                
                try
                {
                    day = Convert.ToInt32(DayAdd.Text);

                    if (day <= 0)
                    {
                        MessageBox.Show("Количество дней не может быть меньше 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
          

           

            if (button.Name == "All")
            {

                foreach (Transaction transaction in transactionsL)
                {
                    TransactionsList.Text += transaction.Sresult() + Environment.NewLine + "***********************" + Environment.NewLine;
                }
            }
            else 
            {
                string transact;
                int accaunNum;

                if(ComboListSortTransact.SelectedIndex == -1 || ComboListSort.SelectedIndex == -1)
                {
                    MessageBox.Show("Комбобокс пустой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }

                transact = Convert.ToString(ComboListSortTransact.SelectionBoxItem);

                accaunNum = bankAccountsL[ComboListSort.SelectedIndex].AccauntN();

                foreach (Transaction transaction in transactionsL) // Для проверки можно перевести время на пк
                {
                    if (Convert.ToString(transaction.Operation) == transact && transaction.AccauntNumberT == accaunNum )
                    {
                        if(day != 0)
                        {
                            if (transaction.DateT > DateTime.Now.AddDays(-day))
                                TransactionsList.Text += transaction.Sresult() + Environment.NewLine + "***********************" + Environment.NewLine;
                        }
                        else
                        {
                            TransactionsList.Text += transaction.Sresult() + Environment.NewLine + "***********************" + Environment.NewLine;
                        }
                    }
                }
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            
            transactionsL.RemoveAll(x => x.TransactStatus == TransactStatus.NotCompleted);
            TransactionsList.Text = string.Empty;
            foreach (Transaction transaction in transactionsL)
            {
                TransactionsList.Text += transaction.Sresult() + Environment.NewLine + "***********************" + Environment.NewLine;
            }
        }
    }
}
