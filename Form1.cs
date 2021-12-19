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
    public partial class frmmain : Form
    {
        private int openDoc; //счетчик числа открываемых док-тов
        public frmmain()
        {
            InitializeComponent();
            mnuSave.Enabled = false;
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.DocName = "Документ " + ++openDoc;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuArrangelcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.SelectAll();
        }

        private void FontBox_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(FontBox.SelectedItem) == "Verdana")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontVerdana();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Calibri")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontCalibri();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Bell")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontBell();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Arial")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontArial();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Candara")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontCandara();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Elephant")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontElephant();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Calisto")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontCalisto();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Consolas")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontConsolas();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Agency")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontAgency();
            }
            else if (Convert.ToString(FontBox.SelectedItem) == "Onyx")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeFontOnyx();
            }

        }

        private void ColorBox_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(ColorBox.SelectedItem) == "Красный")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorRed();
            }
            else if (Convert.ToString(ColorBox.SelectedItem) == "Зеленый")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorGreen();
            }
            else if (Convert.ToString(ColorBox.SelectedItem) == "Голубой")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorBlue();
            }
            else if (Convert.ToString(ColorBox.SelectedItem) == "Оранжевый")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorOrange();
            }
            else if (Convert.ToString(ColorBox.SelectedItem) == "Желтый")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorYellow();
            }
            else if (Convert.ToString(ColorBox.SelectedItem) == "Серый")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorGray();
            }
            else if (Convert.ToString(ColorBox.SelectedItem) == "Черный")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorBlack();
            }
            else if (Convert.ToString(ColorBox.SelectedItem) == "Розовый")
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.ChangeColorPink();
            }

        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = new blank(); frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this; //указываем родительскую форму 
                frm.DocName = openFileDialog1.FileName; //присваиваем переменной DocName имя 
                                                        //открываемого файла
                frm.Text = frm.DocName; //свойству Text формы присваиваем переменную DocName
                frm.Show();
            }
            mnuSave.Enabled = true;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.Save(saveFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.Save(frm.DocName);
                frm.IsSaved = true;
            }

        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.Save(saveFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.IsSaved = true;
            }
            mnuSave.Enabled = true;

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Close();

        }
    }
}
