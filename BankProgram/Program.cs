using System;
/// <summary>
/// Billy Stockton
/// Program 1
/// This Program allows the user to choose from and execute
/// bank tranactions and check Account Balance
/// </summary>

namespace Program1
{
    class Program
    {
        /// <summary>
        /// Menu Arrays and Constants
        /// </summary>
        public static char[] TRANS_MENU_CHARS = { 'D', 'W', 'C', 'G', 'S', 'Q' };
        public static string[] TRANS_MENU_OPTIONS = { "(D)eposit", "(W)ithdraw", "(C)alculateInterest", "(G)etBalance", "(S)howTransactions", "(Q)uit" };
        public static double START_BAL = 500.0;
        private const int MAX = 50;
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Account custAccount = new Account(START_BAL);
            char selection = TransMenuSelection();
            while (selection != 'Q')
            {
                //Checks to see if array is full
                if (CanAddElements(custAccount.GetTransValues()))
                {
                    //Calls methods based on what transaction is requested
                    switch (selection)
                    {
                        case 'D'://Deposit
                            double transAmount = GetAmount(selection);
                            custAccount.SetDeposit(transAmount);
                            DepositMessage(transAmount);
                            break;

                        case 'W'://Withdrawal
                            transAmount = GetAmount(selection);
                            if (transAmount > custAccount.GetCurrentBalance())//Sufficient funds check
                            {
                                NSFMessage(custAccount.GetCurrentBalance());//Non Sufficient Funds Message
                            }
                            else
                            {
                                custAccount.SetWithdrawal(transAmount);
                                WithdrawMessage(transAmount);
                            }
                            break;

                        case 'C'://Calculate/Add Interest
                            custAccount.AddInterest();
                            InterestMessage(custAccount.GetCurrentBalance());

                            break;

                        case 'G'://Retrieves Account Balance
                            DisplayAccountBalance(custAccount.GetCurrentBalance());
                            break;

                        case 'S'://Shows a list of all transactions
                           DisplayTransactions(custAccount.GetTransTypes(), custAccount.GetTransValues(), custAccount.GetCurrentBalance());
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    MaxTransMessage();
                }

                selection = TransMenuSelection();
            }
        }
        /// <summary>
        /// Void Methods
        /// 1st Method Displays Confirmation of Deposit
        /// </summary>
        /// <param name="transAmount"></param>     
        public static void DepositMessage(double transAmount)
        {
            Console.WriteLine("\nYour Deposit in the amount of " + $"{ transAmount,8:c}" + " has been processed");
        }
        /// <summary>
        /// Method Displays Confirmation of Withdrawal
        /// </summary>
        /// <param name="transAmount"></param>
        public static void WithdrawMessage(double transAmount)
        {
            Console.WriteLine("\nYour Withdrawal in the amount of " + $"{ transAmount,8:c}" + " has been processed");
        }
        /// <summary>
        /// Method Displays Non Sufficient Funds error for requested withdrawal
        /// </summary>
        /// <param name="accountBalance"></param>
        public static void NSFMessage(double accountBalance)
        {
            DisplayAccountBalance(accountBalance);
            Console.WriteLine("Insufficient funds to make this withdrawal");
            Console.WriteLine("Please try another transaction or Quit");
        }
        /// <summary>
        /// Method confirms interest has been added and gives updated account balance
        /// </summary>
        /// <param name="accountBalance"></param>
        public static void InterestMessage(double accountBalance)
        {
            Console.WriteLine("\nFive percent Interest has been added to your balance");
            Console.WriteLine("Your Updated Account Balance with interest is " + $"{ accountBalance,8:c}");
        }
        /// <summary>
        /// Method gives error message when 50 transactions are reached
        /// </summary>
        public static void MaxTransMessage()
        {
            Console.WriteLine("\nYou have reached the maximum number of transactions at this time");
            Console.WriteLine("Must choose quit and try again later ");
        }
        /// <summary>
        /// Method displays current account balance when requested
        /// </summary>
        /// <param name="accountBalance"></param>
        public static void DisplayAccountBalance(double accountBalance)
        {
            Console.WriteLine("\nYour current account balance is " + $"{ accountBalance,8:c}");
        }
        /// <summary>
        /// Method Displays a list of all transactions
        /// </summary>
        /// <param name="transTypes"></param>
        /// <param name="transValues"></param>
        /// <param name="accountBalance"></param>
        public static void DisplayTransactions(string[] transTypes, double[] transValues, double accountBalance)
        {
            Console.WriteLine("Start Balance" + $"\t{START_BAL,9:c}");
            for (int i = 0; i < transValues.Length; i++)
            {
                Console.WriteLine(transTypes[i] + " " + $"\t{transValues[i],9:c}");
            }
            Console.WriteLine("Current Balance" + $"\t{accountBalance,9:c}");
        }
        /// <summary>
        /// Method Displays the Transaction Menu 
        /// </summary>
        public static void TransMenu()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n" + "TRANSACTION MENU");
            for (int i = 0; i < TRANS_MENU_CHARS.Length; i++)
            {
                Console.WriteLine("\n" + "   " + TRANS_MENU_OPTIONS[i]);
            }
            Console.WriteLine("\n" + "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        /// <summary>
        /// VR Methods
        /// 1st Method checks to see if array is full
        /// </summary>
        /// <param name="transValues"></param>
        /// <returns></returns>
        public static bool CanAddElements(double[] transValues)
        {
            if (transValues.Length >= MAX)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Validation for Transaction Menu selection
        /// </summary>
        /// <returns></returns>
        public static char TransMenuSelection()
        {
            TransMenu();
            Console.WriteLine("\n" + "Please Choose a Transaction ");
            char c = Console.ReadLine().ToUpper()[0];
            while (c != 'D' && c != 'W' && c != 'C' && c != 'G' && c != 'S' && c != 'Q')
            {
                Console.WriteLine("That was an invalid selection, please try again");
                TransMenu();
                c = Console.ReadLine().ToUpper()[0];
            }
            return c;
        }
        /// <summary>
        /// Method retrieves and returns amount for Deposit
        /// or withdrawal from customer input
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        public static double GetAmount(char selection)
        {
            if (selection == 'D')
            {
                Console.WriteLine("What is the Deposit Amount? ");
            }
            else
            {
                Console.WriteLine("What is the Withdrawal Amount? ");
            }
            String s = Console.ReadLine();
            double amount = Double.Parse(s);
            return amount;
        }

    }
}
