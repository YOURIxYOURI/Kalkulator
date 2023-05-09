using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        public List<string> symbols = new List<string>();
        public bool check;
        public bool check2;
        public bool equal_click;
        public string task;
        public double equal;

        public MainWindow()
        {
            InitializeComponent();
            equal_click = false;
            task = "";
            equal = .0;
            symbols.AddRange(new string[] { "+", "-", "=", "x", "/", "C", "<-", "n!","x^y","sqrt"});
        }
        public double Factorial(double n)
        {
            double i, fact = 1, number = n;
            for (i = 1; i <= number; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //try
        //{
        //    var data = ((Button)sender).Content.ToString();
        //    if (data == "+/-")
        //    {
        //        double d = Convert.ToDouble(screen.Text);
        //        d *= -1;
        //        screen.Text = d.ToString();
        //    }
        //    else if (data == "C")
        //    {
        //        task = "";
        //        equal = .0;
        //        screen.Text = "";
        //    }
        //    else if (data == "<-")
        //    {
        //        string s = screen.Text;
        //        if (s.Length > 1)
        //            s = s.Substring(0, s.Length - 1);
        //        else
        //            s = "";
        //        screen.Text = s;
        //    }
        //    else
        //    {
        //        screen.Text += data;
        //    }
        //}
        //catch (Exception exc) { MessageBox.Show("U are too dumb to even use a calculator and this is why" + exc.Message, "You dumb", MessageBoxButton.OK, MessageBoxImage.Warning); }
        //}
        {
            try
            {
                var data = ((Button)sender).Content.ToString();

                if (check && !symbols.Contains(data))
                {
                    if (screen.Text != "")
                        equal = Convert.ToDouble(screen.Text);
                    screen.Text = "";
                    check = false;
                }

                if (symbols.Contains(data))
                {

                    if (task != "" && check2)
                    {
                        switch (task)
                        {
                            case "+": equal += Convert.ToDouble(screen.Text); break;
                            case "-": equal -= Convert.ToDouble(screen.Text); break;
                            case "x": equal *= Convert.ToDouble(screen.Text); break;
                            case "/": equal /= Convert.ToDouble(screen.Text); break;
                            case "sqrt": equal = Math.Sqrt(Convert.ToDouble(screen.Text)); break;
                            case "n!": equal = Factorial(Convert.ToDouble(screen.Text)); break;
                            case "x^y": equal = Math.Pow(equal, Convert.ToDouble(screen.Text)); break;
                        }
                        check2 = false;
                        if (task != "C") { screen.Text = equal.ToString(); }
                    }
                    check = true;
                    switch (data)
                    {
                        case "C":
                            check = false;
                            check2 = true;
                            task = "";
                            equal = .0;
                            screen.Text = "";
                            break;
                        case "<-":
                            string s = screen.Text;
                            check = false;
                            check2 = false;
                            if (s.Length > 1)
                                s = s.Substring(0, s.Length - 1);
                            else
                                s = "";
                            screen.Text = s;
                            break;
                    }
                    if (data != "=")
                        task = data;
                    else
                        task = "";

                }
                else
                {
                    if (data == "+/-")
                    {
                        double d = Convert.ToDouble(screen.Text);
                        d *= -1;
                        screen.Text = d.ToString();
                    }
                    else
                    {
                        screen.Text += data;
                        check2 = true;
                    }
                }
            }
            catch (Exception exc) { MessageBox.Show("U are too dumb to even use a calculator and this is why" + exc.Message, "You dumb", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        private void Function_Button(object sender, RoutedEventArgs e)
        {
            
        }

        private void OneParametr_function_button(object sender, RoutedEventArgs e)
        {

        }
    }
}
