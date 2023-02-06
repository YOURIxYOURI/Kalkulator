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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> symbols = new List<string>();
        public bool check = false;
        public bool check2 = true;
        public string task = "";
        public double equal = .0;

        public MainWindow()
        {
            InitializeComponent();
            symbols.AddRange(new string[] { "+", "-", "=", "x", "/", "CE", "C" });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).Content.ToString();

            if (check && !symbols.Contains(data))
            {
                if(screen.Text != "Er" || screen.Text != "")
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
                        case "+":
                            equal += Convert.ToDouble(screen.Text);
                            break;
                        case "-":
                            equal -= Convert.ToDouble(screen.Text);
                            break;
                        case "x":
                            equal *= Convert.ToDouble(screen.Text);
                            break;
                        case "/":
                            if (screen.Text != "0")
                                equal /= Convert.ToDouble(screen.Text);
                            else
                            {
                                screen.Text = "Er";
                                check = true;
                                return;
                            }
                            break;
                    }
                    check2 = false;
                    screen.Text = equal.ToString();
                }
                else if(task != "" && !check2)
                {
                    switch (data)
                    {
                        case "C":
                            check = false;
                            check2 = true;
                            task = "";
                            equal = .0;
                            screen.Text = "";
                            return;
                            break;
                        case "CE":
                            screen.Text = "";
                            return;
                            break;
                    }
                }
                task = data;
                check = true;
            }       
            else
            {
                screen.Text += data;
                check2 = true;
            }
        }
    }
}
