using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Calculator
{
    public class dierg
    {
        public double pr(double a, double b, int c)
        {
            if (c == 1)
            { a = a + b; }
            else if (c == 2)
            { a = a - b; }
            else if (c == 3)
            { a = a * b; }
            else if (c == 4)
            {
                if (b == 0)
                {
                    MessageBox.Show("ΔΕΝ ΓΙΝΕΤΑΙ ΔΙΑΙΡΕΣΗ ΜΕ ΤΟ 0");
                }
                else
                {
                    a = a / b;
                }
            }
            else if (c == 7)
            { 
                double temp = a;
                for (int i = 0; i < b-1; i++)
                {
                    
                    a = a *temp;
                }
            }
            else if (c == 9)
            {
                if (a > 0)
                {
                    a = Math.Log(a, b);
                }
                else
                {
                    MessageBox.Show("Ο ΑΡΙΘΜΟΣ ΠΡΕΠΕΙ ΝΑ ΕΙΝΑΙ ΜΕΓΑΛΥΤΕΡΟΣ ΤΟΥ 0");
                }
            }
            return a;
        }
        public double pr2(double a, int c)
        {
            if (c == 5)
            {
                
                a = Math.Sqrt(a);
            }
            else if (c == 6)
            {
                if (a > 0)
                {
                    a = Math.Log10(a);
                }
                else
                {
                    MessageBox.Show("Ο ΑΡΙΘΜΟΣ ΠΡΕΠΕΙ ΝΑ ΕΙΝΑΙ ΜΕΓΑΛΥΤΕΡΟΣ ΤΟΥ 0");
                }
            }
            else if (c == 8)
            {
                if (a > 0)
                {
                    a = Math.Log(a);
                }
                else
                {
                    MessageBox.Show("Ο ΑΡΙΘΜΟΣ ΠΡΕΠΕΙ ΝΑ ΕΙΝΑΙ ΜΕΓΑΛΥΤΕΡΟΣ ΤΟΥ 0");
                }
            }
            else if (c == 10)
            {
              double  x = Math.PI*a / 180;
              a = Math.Sin(x);
            }
            else if (c == 11)
            {
                double x = Math.PI * a / 180;
                a = Math.Cos(x);
            }
            else if (c == 12)
            {
                double x = Math.PI * a / 180;
                a = Math.Tan(x);
            }
            return a;
        }
    }
}
