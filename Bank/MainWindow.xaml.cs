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

        BankAccount account1 = null, account2 = null;
        Client user1 = null, user2 = null;

        private String Result(Client user, BankAccount account)
        {
            string result;

            result = user.Sresult();
            result += account.Sresult();

            return result;
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;

            int accountNumber;
            double moneyAccount;
            int depositPeriod;
            DateTime birthDate;
            int passportSeries;
            int papassportNumber;
           
            DateTime dateOpen;
            DateTime depositOpen;
            StatusS status;
           
            if (Convert.ToString(button.Name) == "Registration1")
            {
              
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
                    if (user2 != null)
                    {
                        if (user2.PassportNumber == papassportNumber)
                        {

                            MessageBox.Show("Номер паспорта не может совподать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    if (account2 != null)
                    {
                        if (account2.AccountNumber == accountNumber)
                        {
                            MessageBox.Show("Номер паспорта не может совподать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                status = StatusS.open;
                account1 = new BankAccount(accountNumber, dateOpen, moneyAccount, depositOpen, depositPeriod, status); //два конструктора 

                user1 = new Client(name, surname, middleName, passportSeries, papassportNumber, birthDate);

                String result; //Переменная в котрой записывается временный результат 

                result = Result(user1, account1);
                
                User1TB.Text = result;
                button.IsEnabled = false;
            }
            else
            {
                try //Проверки 
                {
                    accountNumber = Convert.ToInt32(AccountNumber2.Text);
                    moneyAccount = Convert.ToDouble(MoneyAccount2.Text);
                    depositPeriod = Convert.ToInt32(DepositPeriod2.Text);
                    birthDate = Convert.ToDateTime(Вirth2.Text);
                    passportSeries = Convert.ToInt32(PassportSeries2.Text);
                    papassportNumber = Convert.ToInt32(PassportNumber2.Text);

                    if (accountNumber < 0 || depositPeriod < 0)
                    {
                        MessageBox.Show("Некоторые данные не могут быть меньше 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (passportSeries < 1000 || passportSeries > 9999 || papassportNumber < 100000 || papassportNumber > 999999)
                    {
                        MessageBox.Show("Паспортные данные введены не коректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (user1 != null)
                    {
                        if (user1.PassportNumber == papassportNumber)
                        {

                            MessageBox.Show("Номера паспорта не могут совподать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    if (account1 != null) 
                    {
                        if (account1.AccountNumber == accountNumber)
                        {
                            MessageBox.Show("Номера аккаунта не могут совподать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string name = Name2.Text;
                string surname = Surname2.Text;
                string middleName = MiddleName2.Text;
                dateOpen = DateTime.Now; // Обьявления Текущей даты и статуса ниже 
                depositOpen = DateTime.Now;
                status = StatusS.open;

              
                account2 = new BankAccount(accountNumber, dateOpen, moneyAccount, depositOpen, depositPeriod, status); //два конструктора 
               
                user2 = new Client(name, surname, middleName, passportSeries, papassportNumber, birthDate);

                String result; //Переменная в котрой записывается временный результат 

                result = Result(user2, account2);

                User2TB.Text = result;
                button.IsEnabled = false;
            }
            if(account1 != null && account2 != null)
            {
                Transfer1B.IsEnabled = true;
                Transfer2B.IsEnabled = true;
            }
            
        }
        private void TransferB_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            double summa;
            if (Convert.ToString(button.Name) == "Transfer1B")
            {
                try
                {
                    summa = Convert.ToDouble(Transfer1TB.Text);
                    if (summa < 0)
                    {
                        MessageBox.Show("Сумма для перевода не может быть отрицательной", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                account1.transfer(account2, summa);
            }
            else
            {
                try
                {
                    summa = Convert.ToDouble(Transfer2TB.Text);
                    if (summa < 0)
                    {
                        MessageBox.Show("Сумма для перевода не может быть отрицательной", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                account2.transfer(account1, summa);
            }
            String result;
            result = Result(user1, account1);
            User1TB.Text = result;

            result=Result(user2, account2);
            User2TB.Text = result;
        }
    }
}
