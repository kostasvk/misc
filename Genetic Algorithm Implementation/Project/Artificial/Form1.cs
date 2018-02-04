using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artificial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        
        int B = 7;
        int met = 1;//metrhths gia prwth fora sthn epanalipsi
        string bpath = @"dotb2.jpg ";
        string wpath = @"dotw2.jpg ";

        private int[,] generate(int x)
        {
            //textBox2.Text += "FIRST GENERATION"+"\r\n";
            int[,] pop = new int[x,B];

            for (int i=0;i<x;i++)
            {
                for (int y = 0; y < B; y++ )
                {
                    pop[i,y] = rnd.Next(2);
                    //textBox2.Text += pop[i, y];
                }
                //textBox2.Text += "\r\n";
            }
            return pop;
        }

        private int[] scoring(int[,] x, int y)
        {
            int[] scores = new int[y];
            
            for (int i = 0; i < y; i++)
            {
                for (int z = 0; z < B-1; z++)
                {
                    if (z >= 2 && z < 4)
                    {
                        if (x[i, z] == x[i, z + 1])
                        {
                            scores[i]++;
                            
                        }
                    }
                    else
                    {
                        if (x[i, z] != x[i, z + 1])
                        {
                            scores[i]++;
                            
                        }
                    }
                }
                //textBox2.Text += "scores " + scores[i] + " \r\n";
                   
            
            }
            
            return scores;
        }

     /*  private int[] numofeach(int N)
        {
            int [] oldnew = new int[2];
            if (listBox1.SelectedItem.Equals("100%"))
            {
                oldnew[1] = 0;//old gen atoms
                oldnew[2] = N;//number of pairs for mutation
            }
            else if (listBox1.SelectedItem.Equals("75%"))
            {
                double temp=(1 - s2) / N;
                oldnew[1] =1 ;
            }
            else if (listBox1.SelectedItem.Equals("50%"))
            {

            }
            else if (listBox1.SelectedItem.Equals("25%"))
            {

            }
            return oldnew;
        }*/

        private int[,] selection(int[] scores,int sum,int N)
        {
            
            bool ok=true;//diff parents
            int limit;
            int[,] pairs= new int[(N/2),2];
            int y;
            
            for (int i = 0; i < (N/2); i++)//metraei ton pinaka twn score
            {
                for (int z = 0; z < 2; z++)
                {
                    y = -1;
                   
                    limit = rnd.Next(sum+1);
                    int temp = 0;
                    do
                    {
                        y++;
                        temp += scores[y];
                        ok = true;
                        if(z==1&&y==pairs[i,z-1]&&temp>limit)//if pairs with self
                        {
                            ok = false;
                            temp = 0;
                            limit = rnd.Next(sum+1);
                            y = -1;

                        }
                    } while (temp < limit || !ok);

                    pairs[i, z] = y;
                }
            }
            
            return pairs;
        }//making pairs

        private int testing(int[] x)
        {
            int l = x.Length;
            
            int point = -1;// if -1 return we recouple
            for (int i = 0; i < l; i++)
            {
                if (x[i] == (B-1))
                {
                    
                    point = i;
                    break;

                }
            }
            return point;
        }

       private int[,] crossover(int[] mask, int[,] pop, int[,] pair)
        {
           int N= pair.GetLength(0);
           int [,] newpop= new int[pop.GetLength(0),pop.GetLength(1)];
           int l1, l2,l3,l4;//pointers
           for (int i = 0; i < N; i++)
           {
               int p1 = pair[i, 0];
               int p2 = pair[i, 1];
               for (int z = 0; z < B; z++)
               {
                   if (mask[z] == 1)
                   {
                       newpop[(i*2),z]=pop[p1,z];
                       newpop[(i * 2) + 1, z] = pop[p2, z];
                   }
                   else if (mask[z] == 0)
                   {
                       newpop[(i * 2), z] = pop[p2, z];
                       newpop[(i * 2) + 1, z] = pop[p1, z];
                   }
               }
           }
           //mutation
           int per=(int)(0.2) * N;
           if (per == 0)
           {
               per = 1;
           }
           for (int i = 0; i <per;i++ )
           {
               l1 = rnd.Next(N);
               l2 = rnd.Next(7);
               if (newpop[l1, l2] == 1)
               {
                   newpop[l1, l2] = 0;
               }
               else
               {
                   newpop[l1, l2] = 1;
               }
           
           }
          /* l1 = rnd.Next(N/2);
           l2 = rnd.Next(N/2, N+1);
           l3 = rnd.Next(7);
           
           if (newpop[l1, l3] == 1)
           {
               newpop[l1, l3] = 0;
           }
           else
           {
               newpop[l1, l3] = 1;
           }
           if (newpop[l2, l3] == 1)
           {
               newpop[l2, l3] = 0;
           }
           else
           {
               newpop[l2, l3] = 1;
           }*/

                return newpop;
        }

       private void paint(int[,] pop, int p)
       {
           PictureBox[] boxes = {
  pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7
};
           for (int i = 0; i < 7;i++ )
           {
               if (pop[p, i] == 1)
               {

                   
                   boxes[i].BackgroundImage = Image.FromFile(bpath);
                   boxes[i].BackgroundImageLayout = ImageLayout.Stretch;
                   
                   
               }
           }
       }
       private void repaint()
       {
           PictureBox[] boxes = {
  pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7
};
           for (int i = 0; i < 7; i++)
           {
               boxes[i].BackgroundImage = Image.FromFile(wpath);
               boxes[i].BackgroundImageLayout = ImageLayout.Stretch;
           }
       }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
           int N = Int32.Parse(textBox1.Text);

           repaint();
            int[] temp2 = new int[] {1,1,1,1,0,0,0};//mask
            int l = temp2.Length;
            int[,] npop=null;//dhlwsh metavliths neou plithismou eksw apo to loop
            int f;
            int[] sc=null;
            int[,] pairs;
            
           
           
            do
            {   
                if(met==1)
                {
                    npop = generate(N);//generate () random population generation
                      sc = scoring(npop, N);// scoring() evaluation and scoring of solutions
                      f=testing(sc);
                      textBox3.Text = met.ToString();
                    met++;
                }
                else
                {
                 pairs  =selection(sc,sc.Sum(),N);
                 npop=crossover(temp2,npop,pairs);
                 sc=scoring(npop,N);
                 f=testing(sc);
                 textBox3.Text = met.ToString();
                 met++;
                }
            }while(f==-1);
            paint(npop,f);
            met = 1;
           }

        private void button2_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Input the number of the desirable population and press the button Generate");
           
        }

        
    }
}
