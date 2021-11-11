using System;
/// <summary>
/// Billy Stockton
/// Program 1
/// This Program allows the user to choose from and execute
/// bank tranactions and check Account Balance
/// </summary>

namespace Program1
{
    public class Account
    {
        /// <summary>
        /// Class Constants/Arrays/Attributes
        /// </summary>
        private const double INT = .05;
        private double[] transValues = new double[0];
        private string[] transTypes = new string[0];
        private double startBal;
        private int arrayLength = 0;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="begBal"></param>
        public Account(double begBal)
        {
            startBal = begBal;
        }
        /// <summary>
        /// This void Method adds a space into both arrays and assigns 
        /// the deposit label and user input value into that space
        /// </summary>
        /// <param name="depAmount"></param>
        public void SetDeposit(double depAmount)
        {
           
            arrayLength++;
            Array.Resize(ref transTypes, arrayLength);
            transTypes[arrayLength - 1] = "Deposit";
            Array.Resize(ref transValues, arrayLength);
            transValues[arrayLength - 1] = depAmount;
        }
        /// <summary>
        /// This void Method adds a space into both arrays and assigns 
        /// the withdrawal label and user input value into that space
        /// </summary>
        /// <param name="withdrawAmount"></param>
        public void SetWithdrawal(double withdrawAmount)
        {
            double w = -1 * withdrawAmount;
            arrayLength++;
            Array.Resize(ref transTypes, arrayLength);
            transTypes[arrayLength - 1] = "Withdrawal";
            Array.Resize(ref transValues, arrayLength);
            transValues[arrayLength - 1] = w;
        }
        /// <summary>
        /// Method to calculate and return current account balance
        /// </summary>
        /// <returns></returns>
        public double GetCurrentBalance()
        {
            double newBalance = startBal;
            for (int i = 0; i < transValues.Length; i++)
            {
                newBalance = newBalance += transValues[i];
            }
            return newBalance;
        }
        /// <summary>
        /// Calculates interest earned to date based on the current account balance
        /// </summary>
        public void AddInterest()
        {
            double interestCalc = GetCurrentBalance() * INT;
            arrayLength++;
            Array.Resize(ref transTypes, arrayLength);
            transTypes[arrayLength - 1] = "Interest";
            Array.Resize(ref transValues, arrayLength);
            transValues[arrayLength - 1] = interestCalc;
        }
        /// <summary>
        /// Returns the Array of Transaction Types
        /// </summary>
        /// <returns></returns>
        public string[] GetTransTypes()
        {
            return transTypes;
        }
        /// <summary>
        /// Returns the Array of Transaction Values
        /// </summary>
        /// <returns></returns>
        public double[] GetTransValues()
        {
            return transValues;
        }
    }
}
