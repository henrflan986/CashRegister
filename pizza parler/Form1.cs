using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace pizza_parler

{
    public partial class Form1 : Form
    {
      
        double taxRate;
        double priceBaseBalls = 6;
        double priceFootBalls = 20;
        double priceGolfBalls = 7;

        //get inputs
        double numberOfBaseballs;
        double numberOfFootballs;
        double numberOfGolfBalls;


        //calcuations
        double subTotal;
        double taxAmount;
        double netPay;

        double enterMoney;

       
        double change;

       

        public Form1()
        {

            InitializeComponent();
        }

     



        private void caluclatingNumbers_Click(object sender, EventArgs e)
        {
            try
            {
                taxRate = 0.2;

                numberOfBaseballs = Convert.ToDouble(numberOfBaseballsInput.Text);
                numberOfFootballs = Convert.ToDouble(numberOfFootballsInput.Text);
                numberOfGolfBalls = Convert.ToDouble(numberOfGolfBallsInput.Text);


                //calcuations
                subTotal = priceBaseBalls * numberOfBaseballs + priceFootBalls * numberOfFootballs + priceGolfBalls * numberOfGolfBalls;
                taxAmount = subTotal * taxRate;
                netPay = subTotal- taxAmount;

                //output
                subTotalOutput.Text = $"{subTotal.ToString("C")}";
                allTaxOutput.Text = $"{taxAmount.ToString("C")}";
                afterTaxOutput.Text = $"{netPay.ToString("C")}";
            }
            catch
            {
                subTotalOutput.Text = "";
                allTax.Text = "";
                afterTax.Text = "ERROR!!!!";
            }
        }

        private void calculatingTheChange_Click(object sender, EventArgs e)
        {
            enterMoney = Convert.ToDouble(enterMoneyInput.Text);  
            

            change = enterMoney - netPay;

            totalChange.Text = $"{change}";

            if (change < 0)
            {
                totalChange.Text = "ERROR";
                BackColor = Color.Red;
                SoundPlayer player = new SoundPlayer(Properties.Resources.wrongSound);
                player.Play();
            }
            else 
            {
             BackColor = Color.Green;
               
            }

        }

  

        private void receiptButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.printingSound);
            player.Play();
            receiptLabel.Text = "                                    Ball Store\n\n";
            receiptLabel.Refresh();
            Thread.Sleep(1000);
            receiptLabel.Text += $"BaseBall cost: {priceBaseBalls * numberOfBaseballs} \n";
            receiptLabel.Refresh();
            Thread.Sleep(1000);
            receiptLabel.Text += $"Football cost:  {priceFootBalls * numberOfFootballs} \n";
            receiptLabel.Refresh();
            Thread.Sleep(1000);
            receiptLabel.Text += $"Golf Ball cost:  {priceGolfBalls * numberOfGolfBalls}\n";
            receiptLabel.Refresh();
            Thread.Sleep(1000);
            receiptLabel.Text += $"Total Price: {subTotal - taxAmount} \n";
            receiptLabel.Refresh();
            Thread.Sleep(1000);
            receiptLabel.Text += $"Change: {change} \n";
        }

        private void startNewOrder_Click(object sender, EventArgs e)
        {
            numberOfBaseballsInput.Text = "";
            numberOfFootballsInput.Text = "";
            numberOfGolfBallsInput.Text = "";
            subTotalOutput.Text = "";
            allTaxOutput.Text = "";
            afterTaxOutput.Text = "";
            enterMoneyInput.Text = "";
            totalChange.Text = "";
            receiptLabel.Text = "";
            BackColor = Color.White;
        }
    }
}
