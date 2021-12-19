using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class blank : Form
    {
        public string DocName; //имя документа
        private String BufferText; //хранение буферизованного фрагмента текста
        public bool IsSaved = false; //переменная, которая будет фиксировать сохранение документа

        public blank()
        {
            InitializeComponent();
        }
        public void Cut() //вырезание текста
        {
            this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        public void Copy() //копирование текста
        {
            this.BufferText = richTextBox1.SelectedText;
        }
        public void Paste() //вставка текста
        {
            richTextBox1.SelectedText = this.BufferText;
        }
        public void SelectAll() //выделение всего текста 
        {
            richTextBox1.SelectAll();
        }
        public void Delete() //удаление текста
        {
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }

        private void cmnuCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void cmnuCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void cmnuPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void cmnuDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        public void ChangeColorRed() //красный цвет
        {
            richTextBox1.SelectionColor = Color.Red;
        }
        public void ChangeColorGreen() //зеленый цвет
        {
            richTextBox1.SelectionColor = Color.Green;
        }
        public void ChangeColorBlue() //голубой цвет
        {
            richTextBox1.SelectionColor = Color.Blue;
        }
        public void ChangeColorYellow() //желтый цвет
        {
            richTextBox1.SelectionColor = Color.Yellow;
        }
        public void ChangeColorGray() //серый цвет
        {
            richTextBox1.SelectionColor = Color.Gray;
        }
        public void ChangeColorOrange() //оранжевый цвет
        {
            richTextBox1.SelectionColor = Color.Orange;
        }
        public void ChangeColorBlack() //черный цвет
        {
            richTextBox1.SelectionColor = Color.Black;
        }
        public void ChangeColorPink() //розовый цвет
        {
            richTextBox1.SelectionColor = Color.Pink;
        }

        //методы выбора шрифта текста
        public void ChangeFontVerdana() //шрифты
        {
            richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
        }
        public void ChangeFontCalibri()
        {
            richTextBox1.SelectionFont = new Font("Calibri", 25, FontStyle.Regular);
        }
        public void ChangeFontBell()
        {
            richTextBox1.SelectionFont = new Font("Bell", 30, FontStyle.Italic);
        }
        public void ChangeFontArial()
        {
            richTextBox1.SelectionFont = new Font("Arial", 15, FontStyle.Bold);
        }
        public void ChangeFontCandara()
        {
            richTextBox1.SelectionFont = new Font("Candara", 48, FontStyle.Italic);
        }
        public void ChangeFontElephant()
        {
            richTextBox1.SelectionFont = new Font("Elephant", 18, FontStyle.Underline);
        }
        public void ChangeFontCalisto()
        {
            richTextBox1.SelectionFont = new Font("Calisto", 64, FontStyle.Strikeout);
        }
        public void ChangeFontConsolas()
        {
            richTextBox1.SelectionFont = new Font("Consolas", 9, FontStyle.Regular);
        }
        public void ChangeFontAgency()
        {
            richTextBox1.SelectionFont = new Font("Agency", 52, FontStyle.Underline);
        }
        public void ChangeFontOnyx()
        {
            richTextBox1.SelectionFont = new Font("Onyx", 72, FontStyle.Strikeout);
        }
        public void Open(String OpenFileName) //метод открытия док-та
        {
            if (OpenFileName == null) { return; }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd(); sr.Close();
                DocName = OpenFileName;
            }
        }
        public void Save(String SaveFileName) //метод сохранения док-та
        {
            if (SaveFileName == null) { return; }
            else
            {
                StreamWriter sw = new StreamWriter(SaveFileName);
                sw.WriteLine(richTextBox1.Text); sw.Close(); //устанавливаем имя документа 
                DocName = SaveFileName;
            }
        }

        private void blank_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsSaved == true)
                if (MessageBox.Show("Сохранить внесенные изменения в "
                + this.DocName + "?", "Сообщение", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Save(this.DocName);
                }
        }
    }
}
