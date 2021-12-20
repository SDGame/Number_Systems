using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Повестка дел:
 * Сделать другие системы по выбору~~~~~~~~~~~~~~~~~~~YES
 * Сделать возможность перевода дробей~~~~~~~~~~~~~~~~NO
 * Математика внутри вырожений~~~~~~~~~~~~~~~~~~~~~~~~NO
 * Выбор СС из которой будет выполняться перевод~~~~~~NO
*/

namespace Number_Systems
{
    public partial class Number_Systems : Form
    {    
        const string date = "2.11.2021";    //Дата релиза, изменять при фиксе кода
        const string version = "1.4";       //Номер версии, изменять при фиксе кода
        Number number = new Number();       //
        Res res = new Res();                //
        bool negative = false;              //Логика на отрицательные числа
        bool ent_other = false;             //Логика на enter при вводе системы счисления
        bool ent_int = false;               //Логика на enter при вводе десятичного числа
        string input_text;                  //Введённое десятичное число
        string other = "";                  //Другая система счисления
        int Base;                           //Система счисления в число
        bool check_warning = false;         //Логика на проверку ошибки
        int input_text_int;                 //Десятичное число в цифрах
        string outsix;                      //Строка для 16-ричной СС
        Point lastPoint;                    //Координаты для перемешения окна
        public Number_Systems()
        {
            InitializeComponent();
            ToolTip t = new ToolTip();      //Объявление подсказок
            t.SetToolTip(Pic_List, "Список изменений");
            t.SetToolTip(info, "Информация о приложении");
            t.SetToolTip(icon_calc, "Информация о разработчике");
            t.SetToolTip(label1, "Закрыть");
            t.SetToolTip(mini, "Свернуть");
            t.SetToolTip(input, "Введите десятичное число");
            t.SetToolTip(text_other, "Информация о системах счисления");
            t.SetToolTip(Tinput_other, "Введите число от 2 до 36");
            t.SetToolTip(T_out_start, "Ваше число");
            t.SetToolTip(textBox1, "Результат");
            t.SetToolTip(Up, "Прибавить");
            t.SetToolTip(Down, "Убавить");
            t.SetToolTip(TB_Other, "Ваша система счисления");
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void mini_MouseEnter(object sender, EventArgs e)
        {
            mini.ForeColor = Color.Gray;
        }
        private void mini_MouseLeave(object sender, EventArgs e)
        {
            mini.ForeColor = Color.White;
        }
        private void TopText_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void TopText_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void two_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                number.two = true;
            }
            else
            {
                number.two = false;
            }
        }
        private void three_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                number.three = true;
            }
            else
            {
                number.three = false;
            }
        }
        private void four_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                number.four = true;
            }
            else
            {
                number.four = false;
            }
        }
        private void fieve_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                number.five = true;
            }
            else
            {
                number.five = false;
            }
        }
        private void six_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                number.sixe = true;
            }
            else
            {
                number.sixe = false;
            }
        }
        private void seven_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                number.seven = true;
            }
            else
            {
                number.seven = false;
            }
        }
        private void eight_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                number.eight = true;
            }
            else
            {
                number.eight = false;
            }
        }
        private void nine_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                number.nine = true;
            }
            else
            {
                number.nine = false;
            }
        }
        private void sixteen_CheckedChanged_1(object sender, EventArgs e)
        {
            if (sixteen.Checked)
            {
                number.sixteen = true;
            }
            else
            {
                number.sixteen = false;
            }
        }
        private void CBOther_CheckedChanged(object sender, EventArgs e)
        {
            if (CBOther.Checked)
            {
                number.other = true;
            }
            else
            {
                number.other = false;
            }
        }
        public void InputVoid()
        {
            this.textBox1.Text = "";
            if (number.other)
            {
                if (ent_int && ent_other)
                {
                    OutPutVoid(input_text_int);
                    UniversalConver(input_text_int, Base);
                }
                else if (ent_int)
                {
                    OutPutVoid(input_text_int);
                }
            }
            else if (!number.other)
            {
                OutPutVoid(input_text_int);
            }
            else
            {
                this.textBox1.Text = "Некоректный данные";
            }
        }
        public void OutPutVoid(int input_text_int)
        {
            for (int i = 2; i <= 9; i++)
            {
                int input_text_int2 = input_text_int;
                var m = new List<int>();
                if (input_text_int2 < 0)
                {
                    input_text_int2 *= -1;
                    negative = true;
                    while (input_text_int2 > 0)
                    {
                        m.Add(input_text_int2 % i);
                        input_text_int2 /= i;
                    }
                    res.Counti(i, m);
                }
                else if (input_text_int2 > 0)
                {
                    negative = false;
                    while (input_text_int2 > 0)
                    {
                        m.Add(input_text_int2 % i);
                        input_text_int2 /= i;
                    }
                    res.Counti(i, m);
                }
                else
                {
                    negative = false;
                    m.Add(0);
                    res.Counti(i, m);
                }
            }
            if (input_text_int > 0)
            {
                negative = false;
                outsix = Convert.ToString(input_text_int, 16);
            }
            else if (input_text_int < 0)
            {
                negative = true;
                outsix = Convert.ToString(-input_text_int, 16);
            }
            res.Rev();
            string a;
            if (number.two)
            {
                res.Conv(2);
                a = string.Join("", res.two);
                this.textBox1.Text += "В 2-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.three)
            {
                res.Conv(3);
                a = string.Join("", res.three);
                this.textBox1.Text += "В 3-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.four)
            {
                res.Conv(4);
                a = string.Join("", res.four);
                this.textBox1.Text += "В 4-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.five)
            {
                res.Conv(5);
                a = string.Join("", res.five);
                this.textBox1.Text += "В 5-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.sixe)
            {
                res.Conv(6);
                a = string.Join("", res.sixe);
                this.textBox1.Text += "В 6-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.seven)
            {
                res.Conv(7);
                a = string.Join("", res.seven);
                this.textBox1.Text += "В 7-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.eight)
            {
                res.Conv(8);
                a = string.Join("", res.eight);
                this.textBox1.Text += "В 8-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.nine)
            {
                res.Conv(9);
                a = string.Join("", res.nine);
                this.textBox1.Text += "В 9-ичной системе: ";
                if (negative && input_text_int != 0)
                {
                    this.textBox1.Text += "-";
                }
                this.textBox1.Text += a;
                this.textBox1.Text += "\r\n";
            }
            if (number.sixteen)
            {
                if (input_text_int != 0)
                {
                    this.textBox1.Text += "В 16-ичной системе: ";
                    if (negative)
                    {
                        this.textBox1.Text += "-";
                    }
                    this.textBox1.Text += outsix;
                    this.textBox1.Text += "\r\n";
                }
                else
                {
                    this.textBox1.Text += "В 16-ичной системе: ";
                    this.textBox1.Text += "0";
                    this.textBox1.Text += "\r\n";
                }
            }
            if (number.other)
            {
                if (other.Contains("\n"))
                {
                    other = other.Replace("\r\n", "");
                }
                if (other == "")
                {
                    this.textBox1.Text += "В неизвестной системе: ";
                }
                else
                {
                    this.textBox1.Text += $"В {other}-ичной системе: ";
                }
                if (input_text_int < 0)
                {
                    this.textBox1.Text += "-";
                }
                try
                {
                    Base = Convert.ToInt32(other);
                    if (!(Base == 1))
                    {
                        this.textBox1.Text += UniversalConver(input_text_int, Base);
                    }
                    else
                    {
                        this.textBox1.Text += "Такой системы счисления не существует";
                    }
                }
                catch
                {
                    this.textBox1.Text += "Ошибка расчёта, введите другую систему";
                }
            }
            if (!number.two && !number.three && !number.four && !number.five &&
                !number.sixe && !number.seven && !number.eight && !number.nine && !number.sixteen && !number.other)
            {
                this.textBox1.Text += "А вчом смысол?";
                if (check_warning)
                {
                    this.textBox1.Text = "";
                    this.textBox1.Text += "Ты дурак?";
                }
                check_warning = !check_warning;
            }
        }
        public void ExitVoid()
        {
            string Massage = "Вы уверены, что хотите выйти?";
            string Caption = "Выход";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if (MessageBox.Show(this, Massage, Caption, buttons, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public string UniversalConver(int number, int toBase)
        {
            if (number < 0)
            {
                negative = true;
            }
            string r = "";
            string letter = "0123456789abcdefghijklmnopqrstuvwxyz";
            int temp10;
            if (negative)
            {
                temp10 = -number;
            }
            else
            {
                temp10 = number;
            }
            while (temp10 >= toBase)
            {
                int mod = temp10 % toBase;
                r = r.Insert(0, letter[mod].ToString());
                temp10 /= toBase;
            }
            r = r.Insert(0, letter[temp10].ToString());
            return r;
        }        
        private void icon_calc_Click(object sender, EventArgs e)
        {
            string massage = $"Разработчик: Я\r\nВерсия: {version}\r\nОт {date}";
            string caption = "Информация о разработчике.";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(this, massage, caption, buttons, MessageBoxIcon.Information);
            //Делал ночью с 25.10 на 26.10
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string massage = "\t\tИнформация:\r\n" +
                "Это приложение для перевода числа в другую систему счисления.\r\n\n" +
                "Оно преобразует десятичное число в выбранные другие системы счисления.\r\n" +
                "Далее будет добавлена возможность переводить десятичные дроби.\r\n" +
                "А так же использовать простую математику в поле для ввода.\r\n";
            string caption = "Информация о приложении.";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(this, massage, caption, buttons, MessageBoxIcon.Information);
        }
        private void text_other_Click(object sender, EventArgs e)
        {
            string massage = "Из-за ограниченного количества букв в английском алфавите вы можете ввести всего лишь число 36, как систему счисления, в которую будет переводиться ваше число.";
            string caption = "Информация о своих системах счисления.";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(this, massage, caption, buttons, MessageBoxIcon.Question);
        }
        private void Up_Click(object sender, EventArgs e)
        {
            try
            {
                if (other == "")
                {
                    other = "0";
                    other = (Convert.ToInt32(other) + 2).ToString();
                    this.Tinput_other.Text = other;
                }
                else
                {
                    if (Convert.ToInt32(other) >= 36)
                    {
                        this.Tinput_other.Text = other;
                    }
                    else
                    {
                        other = (Convert.ToInt32(other) + 1).ToString();
                        this.Tinput_other.Text = other;
                    }   
                }
            }
            catch
            {
                this.Tinput_other.Text = "";
            }
        }
        private void Down_Click(object sender, EventArgs e)
        {
            try
            {
                if (other == "")
                {
                    other = "0";
                    other = (Convert.ToInt32(other) - 1).ToString();
                    this.Tinput_other.Text = other;
                }
                else
                {
                    if (Convert.ToInt32(other) <= 2)
                    {
                        this.Tinput_other.Text = other;
                    }
                    else
                    {
                        other = (Convert.ToInt32(other) - 1).ToString();
                        this.Tinput_other.Text = other;
                    }
                }
            }
            catch
            {
                this.Tinput_other.Text = "";
            }
        }
        private void Pic_List_Click(object sender, EventArgs e)
        {
            string Massage = "Дата зарождения идеи: 14.10.2021\r\n" +
                "Дата реализации консольного кода: 16.10.2021\r\n" +
                "Дата создания первого прототипа в WF: 19.10.2021\r\n" +
                "Дата создания работающей версии: 25.10.2021\r\n" +
                "Дата добавления других систем счисления до 36: 28.10.2021\r\n" +
                "Дата реализации двойного Enter: 29.10.2021";
            string Caption = "Список изменений.";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(this, Massage, Caption, buttons, MessageBoxIcon.Information);
        }
        private void Tinput_other_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back)
            {
                this.Tinput_other.Text = "";
                other = "";
                number.other = false;
                this.CBOther.Checked = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                ent_other = true;
                this.CBOther.Checked = true;
                number.other = true;

                other = this.Tinput_other.Text;
                this.Tinput_other.Text = "";
                this.TB_Other.Text = "";
                try
                {
                    if (Convert.ToInt32(other) >= 37 && Convert.ToInt32(other) != 1)
                    {
                        this.CBOther.Checked = false;
                        number.other = false;
                        this.TB_Other.Text += "Неправильная система счисления";
                        this.textBox1.Text = "";
                        input_text_int = Convert.ToInt32(input_text);
                        OutPutVoid(input_text_int);
                    }
                    else if(Convert.ToInt32(other) == 1 || Convert.ToInt32(other) == 0)
                    {
                        this.TB_Other.Text = "";
                        if (other.Contains("\n"))
                        {
                            other = other.Replace("\r\n", "");
                        }
                        this.TB_Other.Text += "Неправильная система счисления";
                        other = "";
                        number.other = false;
                        this.CBOther.Checked = false;
                    }
                    else
                    {
                        this.TB_Other.Text = "";
                        if (other.Contains("\n"))
                        {
                            other = other.Replace("\r\n", "");
                        }
                        this.TB_Other.Text += $"Ваша система счисления: {other}";
                        input_text_int = Convert.ToInt32(input_text);
                        InputVoid();
                    }
                }
                catch
                {
                    this.TB_Other.Text = "";
                    this.TB_Other.Text += "Ваша система счисления: -";
                }
            }
            if(e.KeyCode == Keys.Escape)
            {
                ExitVoid();
            }
        }
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.input.Text = "";
                input_text = "";
            }
            if(e.KeyCode == Keys.Enter)
            {
                ent_int = true;
                input_text = this.input.Text;
                this.input.Text = "";
                this.T_out_start.Text = "";
                if (input_text.Contains("\n"))
                {
                    input_text = input_text.Replace("\r\n", "");
                }
                this.T_out_start.Text += $"Ваше число: {input_text}";
                try
                {
                    input_text_int = Convert.ToInt32(input_text);
                    InputVoid();
                }
                catch
                {
                    this.T_out_start.Text = "Неверный формат числа";
                    if (!number.two && !number.three && !number.four && !number.five && 
                        !number.sixe && !number.seven && !number.eight && !number.nine && !number.sixteen && !number.other)
                    {
                        this.textBox1.Text = "";
                        this.textBox1.Text += "А вчом смысол?";
                        if (check_warning)
                        {
                            this.textBox1.Text = "";
                            this.textBox1.Text += "Ты дурак?";
                        }
                        check_warning = !check_warning;
                    }
                }
            }
            if(e.KeyCode == Keys.Escape)
            {
                ExitVoid();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ExitVoid();
            }
        }

        private void TB_Other_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ExitVoid();
            }
        }

        private void T_out_start_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ExitVoid();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ExitVoid();
            }
        }
    }
    class Number
    {
        public bool two = true;
        public bool three = true;
        public bool four = true;
        public bool five = true;
        public bool sixe = true;
        public bool seven = true;
        public bool eight = true;
        public bool nine = true;
        public bool sixteen = true;
        public bool other = false;
    }
    class Res
    {
        public List<int> two2 = new List<int>(0);
        public List<int> three2 = new List<int>(0);
        public List<int> four2 = new List<int>(0);
        public List<int> five2 = new List<int>(0);
        public List<int> sixe2 = new List<int>(0);
        public List<int> seven2 = new List<int>(0);
        public List<int> eight2 = new List<int>(0);
        public List<int> nine2 = new List<int>(0);
        public List<int> other2 = new List<int>(0);

        public List<string> two = new List<string>(0);
        public List<string> three = new List<string>(0);
        public List<string> four = new List<string>(0);
        public List<string> five = new List<string>(0);
        public List<string> sixe = new List<string>(0);
        public List<string> seven = new List<string>(0);
        public List<string> eight = new List<string>(0);
        public List<string> nine = new List<string>(0);

        public void Counti(int i, List<int> resul)
        {
            switch (i)
            {
                case 2:
                    two2 = resul;
                    break;
                case 3:
                    three2 = resul;
                    break;
                case 4:
                    four2 = resul;
                    break;
                case 5:
                    five2 = resul;
                    break;
                case 6:
                    sixe2 = resul;
                    break;
                case 7:
                    seven2 = resul;
                    break;
                case 8:
                    eight2 = resul;
                    break;
                case 9:
                    nine2 = resul;
                    break;
                default:
                    break;
            }
        }
        public void Rev()
        {
            two2.Reverse();
            three2.Reverse();
            four2.Reverse();
            five2.Reverse();
            sixe2.Reverse();
            seven2.Reverse();
            eight2.Reverse();
            nine2.Reverse();
        }
        public dynamic Conv(int i)
        {
            string ls = "";
            if (i == 2)
            {
                two = two2.ConvertAll(x => x.ToString()).ToList();
                return two;
            }
            else if (i == 3)
            {
                three = three2.ConvertAll(x => x.ToString()).ToList();
                return three;
            }
            else if (i == 4)
            {
                four = four2.ConvertAll(x => x.ToString()).ToList();
                return four;
            }
            else if (i == 5)
            {
                five = five2.ConvertAll(x => x.ToString()).ToList();
                return five;
            }
            else if (i == 6)
            {
                sixe = sixe2.ConvertAll(x => x.ToString()).ToList();
                return sixe;
            }
            else if (i == 7)
            {
                seven = seven2.ConvertAll(x => x.ToString()).ToList();
                return seven;
            }
            else if (i == 8)
            {
                eight = eight2.ConvertAll(x => x.ToString()).ToList();
                return eight;
            }
            else if (i == 9)
            {
                nine = nine2.ConvertAll(x => x.ToString()).ToList();
                return nine;
            }
            else
            {
                return ls;
            }
        }
    }
}