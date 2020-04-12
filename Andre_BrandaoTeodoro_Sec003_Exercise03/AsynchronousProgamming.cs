using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andre_BrandaoTeodoro_Sec003_Exercise03
{
    public partial class AsynchronousProgamming : Form
    {
        public AsynchronousProgamming()
        {
            InitializeComponent();
        }
        private async void calculateButton_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "";
            // try catch block to handle exceptions
            try
            {

                // Update ResultLabel to show intermediate state while system process the request
                AppendText("Starting Task to calculate Calculating Factorial(46)");
                // create Task to perform Factorial(46) calculation in a thread
                Task<TimeData> task1 = Task.Run(() => StartFactorial(46));
                // Update ResultLabel to show intermediate state while system process the request
                AppendText("Starting Task to calculate Calculating Fibonacci(45)");
                // create Task to perform Fibonacci(46) calculation in a thread
                Task<TimeData> task2 = Task.Run(() => StartFibonacci(45));
                // Update ResultLabel to show intermediate state while system process the request
                AppendText("Starting Task to calculate Rolling Dice(6000000)");
                // create Task to perform Fibonacci(46) calculation in a thread
                Task<TimeData> task3 = Task.Run(() => StartRollDice(6000000));
                // wait for task execution to proceed with the execution
                await Task.WhenAll(task1, task2, task3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #region Factorial
        TimeData StartFactorial(int n)
        {
            // create a TimeData object to store start/end times
            var result = new TimeData();
            try
            {
                // Update ResultLabel to show intermediate state while system process the request
                AppendText($"Calculating Factorial({n})");
                result.StartTime = DateTime.Now;
                //Calculate 
                BigInteger factorialValue = Factorial(n);
                result.EndTime = DateTime.Now;
                // Update ResultLabel to show result
                AppendText($"Factorial({n}) = {factorialValue}");
                double minutes = (result.EndTime - result.StartTime).TotalMinutes;
                // Update ResultLabel to show finished state while system process the request
                AppendText($"Factorial calculation time = {minutes:F6} minutes\r\n");
                return result;
            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
        }
        // recursive function to calculate factorial
        private BigInteger Factorial(BigInteger num)
        {
            try
            {
                if (num == 0)
                {
                    return 1;
                }
                return num * Factorial(num - 1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }
        #endregion

        #region Fibonacci
        TimeData StartFibonacci(int n)
        {
            // create a TimeData object to store start/end times
            var result = new TimeData();
            try
            {
                // Update ResultLabel to show intermediate state while system process the request
                AppendText($"Calculating Fibonacci({n})");
                result.StartTime = DateTime.Now;
                long fibonacciValue = Fibonacci(n);
                result.EndTime = DateTime.Now;
                // Update ResultLabel to show result
                AppendText($"Fibonacci({n}) = {fibonacciValue}");
                double minutes = (result.EndTime - result.StartTime).TotalMinutes;
                // Update ResultLabel to show finished state while system process the request
                AppendText($"Fibonacci calculation time = {minutes:F6} minutes\r\n");
                return result;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
        }
        // Recursively calculates Fibonacci numbers
        public long Fibonacci(long n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
        #endregion
        #region Roll Dice
        Random r = new Random();
        TimeData StartRollDice(int n)
        {
            // create a TimeData object to store start/end times
            var result = new TimeData();
            try
            {
                // Update ResultLabel to show intermediate state while system process the request
                AppendText($"Calculating RollDice({n})");
                result.StartTime = DateTime.Now;
                int[] resultArray = new int[5];
                int min = 0;
                int max = 5;
                for (int i = 0; i < n; i++)
                {
                    int roll = RollDice(min, max);
                    resultArray[roll] = resultArray[roll] + 1;
                }
                result.EndTime = DateTime.Now;
                int maxValue = resultArray.Max();
                int maxIndex = resultArray.ToList().IndexOf(maxValue);
                // Update ResultLabel to show result
                AppendText($"RollDice({n}) = face {maxIndex+1} was rolled {maxValue.ToString()}");
                double minutes = (result.EndTime - result.StartTime).TotalMinutes;
                // Update ResultLabel to show finished state while system process the request
                AppendText($"RollDice calculation time = {minutes:F6} minutes\r\n");
                return result;
            } catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result;
                }
        }
        private int RollDice(int min, int max)
        {
            return r.Next(min, max);
        }
        #endregion
        #region AppendText
        public void AppendText(String text)
        {
            if (InvokeRequired) // not GUI thread, so add to GUI thread
            {
                Invoke(new MethodInvoker(() => AppendText(text)));
            }
            else // GUI thread so append text
            {
                resultTextBox.AppendText(text + "\r\n");
            }
        }
        #endregion
    }
}
