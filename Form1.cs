using System;
using System.Windows.Forms;
using System.Collections;


namespace TicTacToe
{
    public partial class Form1 : Form
    {
        ListBox lst = new ListBox();
        bool stepPc;
        int plast = 0;
        int win = 0;
        string level = "Easy";
        int? pfir = null;                       //
        int[] fld = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initialize_button();
            set_Field();
            easyToolStripMenuItem.Checked = true;
            panel1.Enabled = false;


        }
        private void initialize_button()

        {
            lst.Items.Add(button1);
            lst.Items.Add(button2);
            lst.Items.Add(button3);
            lst.Items.Add(button4);
            lst.Items.Add(button5);
            lst.Items.Add(button6);
            lst.Items.Add(button7);
            lst.Items.Add(button8);
            lst.Items.Add(button9);

        }

        private void save_3()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (fld[i] + fld[i + 1] + fld[i + 2] == 20)
                {
                    for (int j = i; j < 9; j++)
                    {
                        if (fld[j] == 0)
                        {
                            fld[j] = 1;
                            stepPc = false;
                            return;
                        }
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (fld[i] + fld[i + 3] + fld[i + 6] == 20)
                {
                    for (int j = i; j < 9; j += 3)
                    {
                        if (fld[j] == 0)
                        {
                            fld[j] = 1;
                            stepPc = false;
                            return;
                        }
                    }
                    break;
                }
            }

            if (fld[0] + fld[4] + fld[8] == 20)
            {
                for (int i = 0; i < 9; i += 4)
                {
                    if (fld[i] == 0)
                    {
                        fld[i] = 1;
                        stepPc = false;
                        return;
                    }
                }
            }
            else if (fld[2] + fld[4] + fld[6] == 20)
            {
                for (int i = 2; i < 7; i += 2)
                {
                    if (fld[i] == 0)
                    {
                        fld[i] = 1;
                        stepPc = false;
                        return;
                    }
                }
            }
        }
        private void attack_3()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (fld[i] + fld[i + 1] + fld[i + 2] == 2)
                {
                    for (int j = i; j < 9; j++)
                    {
                        if (fld[j] == 0)
                        {
                            fld[j] = 1;

                            win = 1;
                            winner();
                        }
                    }

                }
                else
                {
                    continue;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (fld[i] + fld[i + 3] + fld[i + 6] == 2)
                {
                    for (int j = i; j < 9; j += 3)
                    {
                        if (fld[j] == 0)
                        {
                            fld[j] = 1;

                            win = 1;
                            winner();
                        }
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (fld[0] + fld[4] + fld[8] == 2)
            {
                for (int i = 0; i < 9; i += 4)
                {
                    if (fld[i] == 0)
                    {
                        fld[i] = 1;

                        win = 1;
                        winner();
                    }
                }
            }
            else if (fld[2] + fld[4] + fld[6] == 2)
            {
                for (int i = 2; i < 7; i += 2)
                {
                    if (fld[i] == 0)
                    {
                        fld[i] = 1;

                        win = 1;
                        winner();
                    }
                }
            }
        }
        private void logic_AI()
        {
            user_win();
            nichia();
            if (level == "Hard")
            {
                attack_3();
                save_3();
            }

            if (stepPc == true)
            {
                if (level == "Medium")
                {
                    save_3();
                }
            }

            if (win == 0)
            {
                if (stepPc == true)
                {
                    if (pfir == 4)
                    {
                        random_angle();
                        pfir = 0;
                    }
                    else if (fld[4] == 0)
                    {
                        step_first();
                    }
                    else
                    {
                        step_angle();
                    }
                }
                nichia();
            }
            else
            {
                winner();
            }
            pc_win(); set_Field();
        }
        private void choice()
        {
            stepPc = false;
            panel1.Enabled = true;
        }
        private void nichia()
        {
            bool stan = false; set_Field();
            for (int i = 0; i < 9; i++)
            {
                if (fld[i] == 0)
                {
                    stan = true;
                    break;
                }
            }
            if (stan == false)
            {
                MessageBox.Show("Ничья!");
                stop();
            }
        }
        private void step_angle()
        {
            if (plast == 2 && fld[6] == 0)
            {
                fld[6] = 1;
            }
            else if (plast == 6 && fld[2] == 0)
            {
                fld[2] = 1;
            }
            else if (plast == 0 && fld[8] == 0)
            {
                fld[8] = 1;
            }
            else if (plast == 8 && fld[0] == 0)
            {
                fld[0] = 1;
            }
            else
            {
                random_angle();
            }

            stepPc = false;
        }
        private void button_off(int a, char s)
        {
            Button btn;
            btn = (Button)lst.Items[a];
            btn.Enabled = false;
            lst.Items[a] = btn;
        }
        private void random_angle()
        {
            if (plast == 1) 
            {
                if (fld[6] == 0)
                {
                    fld[6] = 1;
                }
                else if (fld[8] == 0)
                {
                    fld[8] = 1;
                }
                else { total_random(); }
            }
            else if (plast == 3)
            {
                if (fld[2] == 0)
                {
                    fld[2] = 1;
                }
                else if (fld[8] == 1)
                {
                    fld[8] = 1;
                }
                else { total_random(); }
            }
            else if (plast == 5)
            {
                if (fld[0] == 0)
                {
                    fld[0] = 1;
                }
                else if (fld[6] == 0)
                {
                    fld[6] = 1;
                }
                else { total_random(); }
            }
            else if (plast == 7)
            {
                if (fld[0] == 0)
                {
                    fld[0] = 1;
                }
                else if (fld[2] == 0)
                {
                    fld[2] = 1;
                }
                else { total_random(); }
            }
            else { total_random(); }
        }
        private void total_random()
        {
            for (int i = 0; i < 9; i++)
            {
                if (fld[i] == 0)
                {
                    fld[i] = 1;
                }
                else
                {
                    continue;
                }
                break;
            }
        }
        private void step_first()
        {
            fld[4] = 1;
        }
        private void set_Field()
        {
            for (int i = 0; i < 9; i++)
            {
                if (fld[i] == 0)
                {
                    Button btn;
                    btn = (Button)lst.Items[i];
                    btn.Text = "";
                    lst.Items[i] = btn;
                }
                else if (fld[i] == 1)
                {
                    Button btn;
                    btn = (Button)lst.Items[i];
                    btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#333233");
                    button_off(i, 'O');
                    lst.Items[i] = btn;

                }
                else if (fld[i] == 10)
                {
                    Button btn;
                    btn = (Button)lst.Items[i];
                    button_off(i, 'X');
                    btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff5ff");
                    lst.Items[i] = btn;
                }
            }
        }
        private void winner()
        {
            set_Field();
            if (win == 1)
            {
                MessageBox.Show("Ви програли! :(");
                stop();
            }
            else if (win == 2)
            {
                MessageBox.Show("Ви перемогли! :)"); stop();
            }
            else if (win == 3)
            {
                stop();
                MessageBox.Show("Нічия!");
            }
        }
        private void user_win()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (fld[i] + fld[i + 1] + fld[i + 2] == 30)
                {
                    win = 2;
                    winner();
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (fld[i] + fld[i + 3] + fld[i + 6] == 30)
                {
                    win = 2;
                    winner();
                }
            }

            if (fld[0] + fld[4] + fld[8] == 30)
            {
                win = 2;
                winner();
            }
            else if (fld[2] + fld[4] + fld[6] == 30)
            {
                win = 2;
                winner();
            }
        }
        private void pc_win()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (fld[i] + fld[i + 1] + fld[i + 2] == 3)
                {
                    win = 1;
                    winner();
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (fld[i] + fld[i + 3] + fld[i + 6] == 3)
                {
                    win = 1;
                    winner();
                }
            }
            if (fld[0] + fld[4] + fld[8] == 3)
            {
                win = 1;
                winner();
            }
            else if (fld[2] + fld[4] + fld[6] == 3)
            {
                win = 1;
                winner();
            }
        }
        private void stop()
        {
            panel1.Enabled = false;
            var res = MessageBox.Show("Спробуємо ще раз?", "Кінець гри", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }
        }
        private void user_first(int a)
        {
            if (pfir == null)
            {
                pfir = a;
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            user_first(8);
            fld[8] = 10;
            stepPc = true;
            plast = 8;
            logic_AI();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            user_first(7);
            fld[7] = 10;
            stepPc = true;
            plast = 7;
            logic_AI();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            user_first(6);
            fld[6] = 10;
            stepPc = true;
            plast = 6;
            logic_AI();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            user_first(5);
            fld[5] = 10;
            stepPc = true;
            plast = 5;
            logic_AI();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.Red;
            user_first(4);
            fld[4] = 10;
            stepPc = true;
            plast = 4;
            logic_AI();
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            user_first(3);
            fld[3] = 10;
            stepPc = true;
            plast = 3;
            logic_AI();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            user_first(2);
            fld[2] = 10;
            stepPc = true;
            plast = 2;
            logic_AI();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            user_first(1);
            fld[1] = 10;
            stepPc = true;
            plast = 1;
            logic_AI();
        }

        private void СкладнимйToolStripMenuItem_Click(object sender, EventArgs e)
        {

            level = "Hard";
            easyToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
        }

        private void ПочатиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            label1.Text = level;
            choice();
            logic_AI();

        }

        private void ЗакінчитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop();
            Application.Restart();
        }

        private void ЛегкоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = "Easy";
            hardToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
        }

        private void СереднійToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = "Medium";
            easyToolStripMenuItem.Checked = false;
            hardToolStripMenuItem.Checked = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            user_first(0);
            fld[0] = 10;
            stepPc = true;
            plast = 0;
            logic_AI();
        }
    }
}
