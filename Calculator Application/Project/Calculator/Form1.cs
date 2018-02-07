using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//SXOLIA PERIEXOUN MONO OI PRWTES 4 PRAKSEIS KATHWS OI UPOLOIPES EINAI AKRIVWS TO IDIO .OPOU XREIAZETAI DIEUKRINISH THA UPARXEI
namespace Calculator
{
    public partial class Form1 : Form
    {
        
        int synt;//auth metavlhth pairnei enan arithmo analoga me ton suntelesth(praksh pou epilegoume) o opoios dinetai san orisma sthn sunarthsh pr h pr2 ths dierg opou kanei tis prakseis se ekswterikh taksh
        int y=0 ;//xrhsimopoieitai gia na deixnei th thesh ths upodiastolhs
       
       double  sec=0, res=0;//sthn metavlhth res bainei o prwtos arithmos ths prakshs kai sthn sec anathetetai o deuteros
      public  bool prwto = true,deutero=false,bs=true,trito=false,tetarto=false,pempto=true,ec=false;
                                                                                            //bs, gia to backspace,ama einai true to backspace einai energo
                                                                                            //prwto,einai true mexri na patithei h prwth praksh dhladh grafoume akoma ton prwto arithmo
                                                                                            //deutero,einai true otan grafetai to prwto psifio tou deuterou arithmou gia na svhsei ton prohgoumeno kai meta ginetai false
                                                                                            //trito,einai true otan exei epilexthei praksh,kai h uparksh ths eksuphretei thn allagh prakshs,apenergopoieitai me pathma psifiou 
                                                                                            //tetarto,einai true otan einai energopoihmenh h plhrhs ekdosh kai antistoixa false otan einai h aplh ekdosh
                                                                                            //pemtpo,einai true otan boroume na xrhsimopoihsoume upodiastolh
                                                                                            //ec,gia na svhnei ton prohgoumeno arithmo meta to ison
      dierg a = new dierg();//dhmiourgia antikeimenou apo thn ekswterikh klash pou ektelei tis prakseis
      //sthn dierg uparxoun duo sunarthseis,mia pou asxoleitai me tis prakseis pou exoun dio arithmous (sunarthsh pr) kai me tis prakseis pou exoun enan arithmo opws o loge (sunarthsh pr2)

        public Form1() 
        {                                                         
            InitializeComponent();
            
        }                                                                                          
        


        
        private void button1_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if(ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "1";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "1";
                    
                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "1";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//1

        private void button2_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "2";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "2";

                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "2";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//2

        private void button3_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "3";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "3";

                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "3";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//3

        private void button4_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "4";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "4";

                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "4";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//4

        private void button5_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "5";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "5";

                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "5";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//5

        private void button6_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "6";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "6";

                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "6";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//6

        private void button7_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "7";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "7";

                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "7";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//7

        private void button8_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "8";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "8";

                }
                else//an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "8";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//8

        private void button9_Click(object sender, EventArgs e)
        {
            bs = true;//energopoihsh tou backspace
            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "9";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "9";

                }
                else //an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "9";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }//9

        private void button10_Click(object sender, EventArgs e)//0
        {
            bs = true;//energopoihsh tou backspace

            if (prwto)//an grafoume akoma ton prwto arithmo
            {
                if (ec)
                {
                    textBox1.Clear();
                    ec = false;
                }
                textBox1.Text = textBox1.Text + "0";
            }
            else //an exei epilexthei praksh 
            {
                if (deutero)//an einai to prwto psifio tou deuterou arithmou ths prakshs
                {
                    textBox1.Clear();
                    deutero = false;//apenergopoieitai auth h flag kai otan patithei epomeno psifio gia auto ton arithmo to prohgoumeno keimeno den svinetai
                    textBox1.Text = textBox1.Text + "0";

                }
                else//an den einai to prwto psifio tou deuterou arithmou ths prakshs kai theloume na mh svhsei to prohgoumeno keimeno
                {
                    textBox1.Text = textBox1.Text + "0";
                }
                trito = false;//apenergopoiei thn ikanothta na epilekseis allh praksh ekeinh th stigmh se periptwsh lathous
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0"||textBox1.Text=="") && prwto == true)//an patithei praksh kai to textbox exei keno h mhden KAI h prwto einai true(dld asxoloumaste me ton prwto arithmo)
            {
               
                prwto = false;//to prwto apenergopoieitai wste na plhktrologithei o deuteros arithmos gia thn praksh
                textBox1.Text = "0";
                res = 0;
                synt = 1;
                textBox2.Text = "+";
            }
            else if(textBox1.Text!="0" && textBox1.Text!="")
            {
                if (prwto == true)//an 
                {
                    //edw xrhsimoipoieitai ena try-catch giathn apofugh to Convert.ToDouble na parei to keno kai na prospathisei na to metatrepsei
                    //se periptwsh pou auto sumvei anatithetai sthn metavlhth res h timh mhden
                  try
                    {
                        res = Convert.ToDouble(textBox1.Text);//metatroph String se Double
                    }
                    catch (System.FormatException k)
                   {
                      res = 0;
                   }
                    
                    prwto = false;//apenergopoieitai h  prwto kathws tha asxolithoume me ton deutero arithmo meta thn epilogh prakshs
                    deutero = true;//energopoieitai h deutero gia to prwto psifio tou deuterou arithmou kai to katharisma tou textbox
                    trito = true;//energopoieitai h trito se periptwsh pou theloume na epileksoume allh praksh logw lathous prin to pathma epomenou arithmou
                    pempto = true;
                    synt = 1;
                    textBox2.Text = "+";
                }
                else
                {
                    if (trito)//an logw lathous allaksame praksh
                    {
                        synt = 1;
                        textBox2.Text = "+";
                    }
                    else if (!trito)//an exoume swsth praksh
                    {
                        sec = Convert.ToDouble(textBox1.Text);//anathesh sth metavlhth sec to string afou to metatrepsoume se Double
                        res = a.pr(res, sec, synt);//kaloume thn sunarthsh pr me orismata tous duo arithmous kai ton syntelesth
                        textBox1.Text = Convert.ToString(res);//metatrepoume to apotelesma se string kai to vazoume sto textbox
                        deutero = true;//to deutero ginetai true kathws twra exei kratithei to apotelesma ths prakshs sth metavlhth res kai boroume na kanome prakseis me auto kai me enan kainourgio arithmo ths epiloghs mas
                        bs = false;//to backspace apenergopoieitai
                        pempto = true;
                        synt = 1;
                        textBox2.Text = "+";
                    }
                }

            }
            
        }//prosthesh

        private void button14_Click(object sender, EventArgs e)//afairesh
        {

            if ((textBox1.Text == "0" || textBox1.Text == "") && prwto == true)//an patithei praksh kai to textbox exei keno h mhden KAI h prwto einai true(dld asxoloumaste me ton prwto arithmo)
            {

                prwto = false;//to prwto apenergopoieitai wste na plhktrologithei o deuteros arithmos gia thn praksh
                textBox1.Text = "0";
                res = 0;
                synt = 2;
                textBox2.Text = "-";
            }
            else if (textBox1.Text != "0" && textBox1.Text != "")
            {
                if (prwto == true)
                {
                    //edw xrhsimoipoieitai ena try-catch giathn apofugh to Convert.ToDouble na parei to keno kai na prospathisei na to metatrepsei
                    //se periptwsh pou auto sumvei anatithetai sthn metavlhth res h timh mhden
                    try
                    {
                        res = Convert.ToDouble(textBox1.Text);//metatroph String se Double
                    }
                    catch (System.FormatException k)
                    {
                        res = 0;
                    }

                    prwto = false;//apenergopoieitai h  prwto kathws tha asxolithoume me ton deutero arithmo meta thn epilogh prakshs
                    deutero = true;//energopoieitai h deutero gia to prwto psifio tou deuterou arithmou kai to katharisma tou textbox
                    trito = true;//energopoieitai h trito se periptwsh pou theloume na epileksoume allh praksh logw lathous prin to pathma epomenou arithmou
                    pempto = true;
                    synt = 2;
                    textBox2.Text = "-";
                }
                else
                {
                    if (trito)//an logw lathous allaksame praksh
                    {
                        synt = 2;
                        textBox2.Text = "-";
                    }
                    else if (!trito)//an exoume swsth praksh
                    {
                        sec = Convert.ToDouble(textBox1.Text);//anathesh sth metavlhth sec to string afou to metatrepsoume se Double
                        res = a.pr(res, sec, synt);//kaloume thn sunarthsh pr me orismata tous duo arithmous kai ton syntelesth
                        textBox1.Text = Convert.ToString(res);//metatrepoume to apotelesma se string kai to vazoume sto textbox
                        deutero = true;//to deutero ginetai true kathws twra exei kratithei to apotelesma ths prakshs sth metavlhth res kai boroume na kanome prakseis me auto kai me enan kainourgio arithmo ths epiloghs mas
                        bs = false;//to backspace apenergopoieitai
                        pempto = true;
                        synt = 2;
                        textBox2.Text = "-";
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)//pollaplasiasmos
        {
            if ((textBox1.Text == "0" || textBox1.Text == "") && prwto == true)//an patithei praksh kai to textbox exei keno h mhden KAI h prwto einai true(dld asxoloumaste me ton prwto arithmo)
            {

                prwto = false;//to prwto apenergopoieitai wste na plhktrologithei o deuteros arithmos gia thn praksh
                textBox1.Text = "0";
                res = 0;
                synt = 3;
                textBox2.Text = "*";
            }
            else if (textBox1.Text != "0" && textBox1.Text != "")
            {
                if (prwto == true)
                {
                    //edw xrhsimoipoieitai ena try-catch giathn apofugh to Convert.ToDouble na parei to keno kai na prospathisei na to metatrepsei
                    //se periptwsh pou auto sumvei anatithetai sthn metavlhth res h timh mhden
                    try
                    {
                        res = Convert.ToDouble(textBox1.Text);//metatroph String se Double
                    }
                    catch (System.FormatException k)
                    {
                        res = 0;
                    }

                    prwto = false;//apenergopoieitai h  prwto kathws tha asxolithoume me ton deutero arithmo meta thn epilogh prakshs
                    deutero = true;//energopoieitai h deutero gia to prwto psifio tou deuterou arithmou kai to katharisma tou textbox
                    trito = true;//energopoieitai h trito se periptwsh pou theloume na epileksoume allh praksh logw lathous prin to pathma epomenou arithmou
                    pempto = true;
                    synt = 3;
                    textBox2.Text = "*";
                }
                else
                {
                    if (trito)//an logw lathous allaksame praksh
                    {
                        synt = 3;
                        textBox2.Text = "*";
                    }
                    else if (!trito)//an exoume swsth praksh
                    {
                        sec = Convert.ToDouble(textBox1.Text);//anathesh sth metavlhth sec to string afou to metatrepsoume se Double
                        res = a.pr(res, sec, synt);//kaloume thn sunarthsh pr me orismata tous duo arithmous kai ton syntelesth
                        textBox1.Text = Convert.ToString(res);//metatrepoume to apotelesma se string kai to vazoume sto textbox
                        deutero = true;//to deutero ginetai true kathws twra exei kratithei to apotelesma ths prakshs sth metavlhth res kai boroume na kanome prakseis me auto kai me enan kainourgio arithmo ths epiloghs mas
                        bs = false;//to backspace apenergopoieitai;
                        pempto = true;
                        synt = 3;
                        textBox2.Text = "*";
                    }
                }

            }
        }

        private void button16_Click(object sender, EventArgs e)//diairesh
        {
            if ((textBox1.Text == "0" || textBox1.Text == "") && prwto == true)//an patithei praksh kai to textbox exei keno h mhden KAI h prwto einai true(dld asxoloumaste me ton prwto arithmo)
            {

                prwto = false;//to prwto apenergopoieitai wste na plhktrologithei o deuteros arithmos gia thn praksh
                textBox1.Text = "0";
                res = 0;
                synt = 4;
                textBox2.Text = "/";
            }
            else if (textBox1.Text != "0" && textBox1.Text != "")
            {
                if (prwto == true)
                {
                    //edw xrhsimoipoieitai ena try-catch giathn apofugh to Convert.ToDouble na parei to keno kai na prospathisei na to metatrepsei
                    //se periptwsh pou auto sumvei anatithetai sthn metavlhth res h timh mhden
                    try
                    {
                        res = Convert.ToDouble(textBox1.Text);//metatroph String se Double
                    }
                    catch (System.FormatException k)
                    {
                        res = 0;
                    }

                    prwto = false;//apenergopoieitai h  prwto kathws tha asxolithoume me ton deutero arithmo meta thn epilogh prakshs
                    deutero = true;//energopoieitai h deutero gia to prwto psifio tou deuterou arithmou kai to katharisma tou textbox
                    trito = true;//energopoieitai h trito se periptwsh pou theloume na epileksoume allh praksh logw lathous prin to pathma epomenou arithmou
                    pempto = true;
                    synt = 4;
                    textBox2.Text = "/";
                }
                else
                {
                    if (trito)//an logw lathous allaksame praksh
                    {
                        synt = 4;
                        textBox2.Text = "/";
                    }
                    else if (!trito)//an exoume swsth praksh
                    {
                        sec = Convert.ToDouble(textBox1.Text);//anathesh sth metavlhth sec to string afou to metatrepsoume se Double
                        res = a.pr(res, sec, synt);//kaloume thn sunarthsh pr me orismata tous duo arithmous kai ton syntelesth
                        textBox1.Text = Convert.ToString(res);//metatrepoume to apotelesma se string kai to vazoume sto textbox
                        deutero = true;//to deutero ginetai true kathws twra exei kratithei to apotelesma ths prakshs sth metavlhth res kai boroume na kanome prakseis me auto kai me enan kainourgio arithmo ths epiloghs mas
                        bs = false;//to backspace apenergopoieitai
                        pempto = true;
                        synt = 4;
                        textBox2.Text = "/";
                    }
                }

            }
        }

        private void button20_Click(object sender, EventArgs e)//squareroot
        {
            synt = 5;
            //try catch se periptwsh kenou sto textbox
            try
            {
                res = Convert.ToDouble(textBox1.Text);
            }
            catch (System.FormatException k)
            {
                res = 0;
            }
            res = a.pr2(res, synt);//kaloume thn pr2 kathws einai praksh enos arithmou
            deutero = true;//energopoieitai h deutero gia to prwto psifio tou deuterou arithmou kai to katharisma tou textbox
            pempto = true;
            bs = false;
            textBox1.Text = Convert.ToString(res);
            textBox2.Text = "²√";
        }

        private void button21_Click(object sender, EventArgs e)//log10
        {
            synt = 6;
            try
            {
                res = Convert.ToDouble(textBox1.Text);
            }
            catch (System.FormatException k)
            {
                res = 0;
            }
            res = a.pr2(res, synt);
            deutero = true;//energopoieitai h deutero gia to prwto psifio tou deuterou arithmou kai to katharisma tou textbox
            bs = false;
            pempto = true;
            textBox1.Text = Convert.ToString(res);
            textBox2.Text = "log10";
        }

        private void button22_Click(object sender, EventArgs e)//pow
        {
            if ((textBox1.Text == "0" || textBox1.Text == "") && prwto == true)
            {

                prwto = false;
                textBox1.Text = "0";
                res = 0;
                synt = 7;
                textBox2.Text = "^";
            }
            else if (textBox1.Text != "0" && textBox1.Text != "")
            {
                if (prwto == true)
                {

                    try
                    {
                        res = Convert.ToDouble(textBox1.Text);
                    }
                    catch (System.FormatException k)
                    {
                        res = 0;
                    }

                    prwto = false;
                    deutero = true;
                    trito = true;
                    pempto = true;
                    synt = 7;
                    textBox2.Text = "^";
                }
                else
                {
                    if (trito)
                    {
                        synt = 7;
                        textBox2.Text = "^";
                    }
                    else if (!trito)
                    {
                        sec = Convert.ToDouble(textBox1.Text);
                        res = a.pr(res, sec, synt);
                        textBox1.Text = Convert.ToString(res);
                        deutero = true;
                        bs = false;
                        pempto = true;
                        synt = 7;
                        textBox2.Text = "^";
                    }
                }

            }
        }


        private void button12_Click(object sender, EventArgs e)//clear
        {
            //katharisma keimenou kai ep[anafora metavlhtwn sthn arxikh katastash
            textBox1.Text = "";
            textBox2.Text = "";
            sec= 0; 
            res=0;
            prwto = true;
            deutero = false;
            trito = false;
            tetarto = false;
            pempto = true;
        }

        private void button11_Click(object sender, EventArgs e)//backspace
        {
            if (bs)
            {
                int l = textBox1.Text.Length;
                if (l > 0)
                {
                    textBox1.Text = textBox1.Text.Remove(l - 1);

                     
                        if (l-y-1 <=0)//h  metavlhth l (deixnei to mhkos tou arithmou) meion th thesh ths upodiastolhs meion 1 giati to l den meionetai prin alla anatithetai meta
                        {
                            pempto = true;//an isxuei h sunthiki tote shmainei pws svhsthke h upodiastolh me to backspace ara energopoieitai ksana h upodiastolh
                        }
                    
                }
            }
        }


   /*   private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)//plhktrologio
        {

            if ((e.KeyChar > 47 && e.KeyChar < 58))//an einai arithmos
            {
                String x = Convert.ToString(e.KeyChar);          
                bs = true;
                if (prwto)
                {
                    textBox1.Text = textBox1.Text + x;
                }
                else if (!prwto)
                {
                    if (deutero)
                    {
                        textBox1.Clear();
                        deutero = false;
                        textBox1.Text = textBox1.Text + x;

                    }
                    else if (!deutero)
                    {
                        textBox1.Text = textBox1.Text + x;
                    }
                    trito = false;
                    // String x = Convert.ToString(e.KeyChar);
                    //textBox1.Text = textBox1.Text + x;
                }
            }
            if (e.KeyChar==42||e.KeyChar==43||e.KeyChar==45||e.KeyChar==47)//prakseis
            {
                String x = Convert.ToString(e.KeyChar);
                if ((textBox1.Text == "0" || textBox1.Text == " ") && prwto == true)
                {

                    prwto = false;
                    textBox1.Text = "0";
                    res = 0;
                    if (e.KeyChar == 42)
                    {
                        synt = 3;
                        textBox2.Text = x;
                    }
                    else if (e.KeyChar == 43)
                    {
                        synt = 1;
                        textBox2.Text = x;
                    }
                    else if (e.KeyChar == 45)
                    {
                        synt = 2;
                        textBox2.Text =x;
                    }
                    else if (e.KeyChar == 47)
                    {
                        synt = 4;
                        textBox2.Text = x;
                    }
                }
                else if (textBox1.Text != "0" && textBox1.Text != " ")
                {
                    if (prwto == true)
                    {

                        try
                        {
                            res = Convert.ToDouble(textBox1.Text);
                        }
                        catch (System.FormatException k)
                        {
                            res = 0;
                        }

                        prwto = false;
                        deutero = true;
                        trito = true;
                        if (e.KeyChar == 42)
                        {
                            synt = 3;
                            textBox2.Text = x;
                        }
                        else if (e.KeyChar == 43)
                        {
                            synt = 1;
                            textBox2.Text = x;
                        }
                        else if (e.KeyChar == 45)
                        {
                            synt = 2;
                            textBox2.Text = x;
                        }
                        else if (e.KeyChar == 47)
                        {
                            synt = 4;
                            textBox2.Text = x;
                        }
                    }
                    else
                    {

                        if (trito)
                        {
                            if (e.KeyChar == 42)
                            {
                                synt = 3;
                                textBox2.Text = x;
                            }
                            else if (e.KeyChar == 43)
                            {
                                synt = 1;
                                textBox2.Text = x;
                            }
                            else if (e.KeyChar == 45)
                            {
                                synt = 2;
                                textBox2.Text = x;
                            }
                            else if (e.KeyChar == 47)
                            {
                                synt = 4;
                                textBox2.Text = x;
                            }
                        }
                        else if (!trito)
                        {
                        sec = Convert.ToDouble(textBox1.Text);
                        res = a.pr(res, sec, synt);
                        textBox1.Text = Convert.ToString(res);
                        deutero = true;
                        bs = false;
                        if (e.KeyChar == 42)
                        {
                            synt = 3;
                            textBox2.Text = x;
                        }
                        else if (e.KeyChar == 43)
                        {
                            synt = 1;
                            textBox2.Text = x;
                        }
                        else if (e.KeyChar == 45)
                        {
                            synt = 2;
                            textBox2.Text = x;
                        }
                        else if (e.KeyChar == 47)
                        {
                            synt = 4;
                            textBox2.Text = x;
                        }
                    }
                }

                }
            }
            if (e.KeyChar == 8)//backspace
            {
                if (bs)
                {
                    int l = textBox1.Text.Length;
                    if (l > 0)
                    {
                        textBox1.Text = textBox1.Text.Remove(l - 1);
                    }
                }
            }
            if (e.KeyChar == 61)//ison
            {
                sec = Convert.ToDouble(textBox1.Text);
                res = a.pr(res, sec, synt);
                textBox1.Text = Convert.ToString(res);
                deutero = true;
                prwto = true;
                bs = false;
                sec = 0;
                res = 0;
            }

        }*/

        private void button18_Click(object sender, EventArgs e)//upodiastolh
        {


            if (!textBox1.Text.EndsWith("."))//an h akolouthia arithmwn den teleiwnei me komma
            {
                if (pempto)//an epitrepetai na valoume komma
                {
                    if (!deutero)//an den einai true wste na mhn borei na bei upodiastolh ston deutero arithmo xwris noumero na prohgeitai
                    {
                        if (textBox1.Text == "")//se periptwsh pou pathsoume upodiastolh se keno textbox
                        { textBox1.Text = "0"; }
                        textBox1.Text = textBox1.Text + ".";
                         y = textBox1.Text.IndexOf(".");//anathetei sthn y th thesh ths upodiastolhs
                        
                        pempto = false;//apenergopoiei thn upodiastolh
                    }
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)//ison
        {
            if (res != 0)
            {
                try
                {
                    sec = Convert.ToDouble(textBox1.Text);
                }
                catch (System.FormatException k)
                {
                    sec = 0;
                }
                res = a.pr(res, sec, synt);
                textBox1.Text = Convert.ToString(res);
                pempto = true;//energopoiei thn upodiastolh
                deutero = true;//energopoieitai gia thn eisagwgh tou prwtou psifiou tou deuterou arithmou
                prwto = true;
                bs = false;
                sec = 0;
                ec = true;
            }

            }
        

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ΒΑΤΙΚΙΩΤΗΣ ΚΩΝΣΤΑΝΤΙΝΟΣ,ΦΑΣΟΥΛΗΣ ΑΓΓΕΛΟΣ,ΦΟΥΡΜΟΥΖΗΣ ΓΙΩΡΓΟΣ");
        }//onomata

        private void button23_Click(object sender, EventArgs e)//log x
        {
            if ((textBox1.Text == "0" || textBox1.Text == "") && prwto == true)
            {

                prwto = false;
                textBox1.Text = "0";
                res = 0;
                synt = 9;
                textBox2.Text = "logx";
            }
            else if (textBox1.Text != "0" && textBox1.Text != "")
            {
                if (prwto == true)
                {

                    try
                    {
                        res = Convert.ToDouble(textBox1.Text);
                    }
                    catch (System.FormatException k)
                    {
                        res = 0;
                    }

                    prwto = false;
                    deutero = true;
                    trito = true;
                    pempto = true;
                    synt = 9;
                    textBox2.Text = "logx";
                }
                else
                {
                    if (trito)
                    {
                        synt = 9;
                        textBox2.Text = "logx";
                    }
                    else if (!trito)
                    {
                        sec = Convert.ToDouble(textBox1.Text);
                        res = a.pr(res, sec, synt);
                        textBox1.Text = Convert.ToString(res);
                        deutero = true;
                        bs = false;
                        pempto = true;
                        synt = 9;
                        textBox2.Text = "logx";
                    }
                }

            }
        }

        private void button24_Click(object sender, EventArgs e)//log e
        {
            synt = 8;
            try
            {
                res = Convert.ToDouble(textBox1.Text);
            }
            catch (System.FormatException k)
            {
                res = 0;
            }
            res = a.pr2(res, synt);
            deutero = true;
            bs = false;
            pempto = true;
            textBox1.Text = Convert.ToString(res);
            textBox2.Text = "log e";
        }

        private void button25_Click(object sender, EventArgs e)//hmitono
        {
            synt = 10;
            try
            {
                res = Convert.ToDouble(textBox1.Text);
            }
            catch (System.FormatException k)
            {
                res = 0;
            }
            res = a.pr2(res, synt);
            deutero = true;
            bs = false;
            pempto = true;
            textBox1.Text = Convert.ToString(res);
            textBox2.Text = "sin";
        }

        private void button26_Click(object sender, EventArgs e)//sinimitono
        {
            synt = 11;
            try
            {
                res = Convert.ToDouble(textBox1.Text);
            }
            catch (System.FormatException k)
            {
                res = 0;
            }
            res = a.pr2(res, synt);
            deutero = true;
            bs = false;
            pempto = true;
            textBox1.Text = Convert.ToString(res);
            textBox2.Text = "cos";
        }

        private void button27_Click(object sender, EventArgs e)//efaptomenh
        {
            synt = 12;
            try
            {
                res = Convert.ToDouble(textBox1.Text);
            }
            catch (System.FormatException k)
            {
                res = 0;
            }
            res = a.pr2(res, synt);
            deutero = true;
            bs = false;
            pempto = true;
            textBox1.Text = Convert.ToString(res);
            textBox2.Text = "tan";
        }

        private void button28_Click(object sender, EventArgs e)//more,less
        {
            if (!tetarto)
            {
                this.Size = new Size(400, 400);
                button20.Visible = true;
                button21.Visible = true;
                button22.Visible = true;
                button23.Visible = true;
                button24.Visible = true;
                button25.Visible = true;
                button26.Visible = true;
                button27.Visible = true;
                tetarto = true;
                textBox2.Location = new Point(273, 45);
                button28.Text = "Less";
            }
            else if (tetarto)
            {
                this.Size = new Size(290, 400);
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                tetarto = false;
                textBox2.Location = new Point(201, 4);
                button28.Text = "More";
            }

        }


      

       

      

       

        
    }

    
}
