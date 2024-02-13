using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button _informationAboutChangeRules = new Button();
        private List<int> _isLifeCellState = new List<int>(1) { 3 };
        private List<int> _isDeadCellStateLifeCell = new List<int>(1){5};
        private CheckBox[] _buttonsForLifeCell = new CheckBox[9];
        private CheckBox[] _buttonsForDeadCell = new CheckBox[9];
        private Graphics _g;
        private PictureBox _fieldPictureBox = new PictureBox();
        private Image _fieldNow;
        
        /// <summary>
        /// Функции, отвечающие за замену правил
        /// </summary>
        private void CreateCheckBoxes(object sender, EventArgs e)
        {
            _informationAboutChangeRules = CreateButton(new Point(0, 650), new Size(150, 150),
                "Отметьте в первом столбце при каких значениях в мёртвой клетке зарождается жизнь и отметьте во втором стролбце при каких значениях живая клетка умирает! по окончании выбора нажмите сюда",
                Color.Bisque);
            this.Controls.Add(_informationAboutChangeRules);
            
            for (int i = 0; i <= 8; i++)
            {

                CheckBox c = new CheckBox();
                c.Location = new Point(1, 900 + 40 * i );
                this.Controls.Add(c);
                c.Text = i.ToString();
                c.Size = new Size(30, 30);
                c.Font = new Font("Bradley Hand ITC", 12);
                c.BackColor = Color.Bisque;
                c.Click += FillButtonsForLifeCell;
                _buttonsForLifeCell[i] = c;
                
                CheckBox d = new CheckBox();
                d.Location = new Point(  50, 900 + 40 * i);
                d.BackColor = Color.Bisque;
                d.Size = new Size(30, 30);
                d.Text = i.ToString();
                d.Font = new Font("Bradley Hand ITC", 12);
                d.Click += FillButtonsForDeadCell;
                this.Controls.Add(d);
                _buttonsForDeadCell[i] = d;
            }
            _isDeadCellStateLifeCell = new List<int>();
            _isLifeCellState = new List<int>();
            _informationAboutChangeRules.Click += new EventHandler(ChangeRules);
            this.Controls.Add(_ok);
            
        }

         private void FillButtonsForLifeCell(object sender, EventArgs e)
         {
             CheckBox a = sender as CheckBox;
             int x = int.Parse(a.Text);
             if (_isLifeCellState.IndexOf(x) == -1)
             {
                 _isLifeCellState.Add(x);
             }
             else
             {
                 _isLifeCellState.Remove(_isLifeCellState.IndexOf(x));
             }
         }
         
         private void FillButtonsForDeadCell(object sender, EventArgs e)
         {
             CheckBox a = sender as CheckBox;
             int x = int.Parse(a.Text);
             if (_isDeadCellStateLifeCell.IndexOf(x) == -1)
             {
                 _isDeadCellStateLifeCell.Add(x);
             }
             else
             {
                 _isDeadCellStateLifeCell.Remove(_isDeadCellStateLifeCell.IndexOf(x));
             }
         }

        private void ChangeRules(object sender, EventArgs e)
        {
            
            for (int i = 0; i <= 8; i++)
            {
                _buttonsForLifeCell[i].Dispose();
                _buttonsForDeadCell[i].Dispose();
            }
            _informationAboutChangeRules.Dispose();

        }
    }
}