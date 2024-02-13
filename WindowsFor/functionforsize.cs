using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Функции, отвечающие за изменение размера клетки в игре
        /// </summary>
        
        private void ReduceCellSize(object sender, EventArgs e)
        {

            _ok.Enabled = true;
            _input.Enabled = true;
            _ok.Click += new EventHandler(ReduceSize);
        }
        private void ReduceSize(object sender, EventArgs e)
        {
            int x = int.Parse(_input.Text);
            _ok.Click -= new EventHandler(ReduceSize);
            _ok.Enabled = false;
            _input.Enabled = false;
            _cellSize -= x;
            _fieldPictureBox.Size = new Size(_fieldSize * _cellSize, _fieldSize * _cellSize);
            _fieldPictureBox.Image =
                new Bitmap(_fieldPictureBox.Image, new Size(_fieldSize * _cellSize, _fieldSize * _cellSize));
            _fieldNow = _fieldPictureBox.Image;
        }

        private void IncreaseCellSize(object sender, EventArgs e)
        {
            
            _ok.Enabled = true;
            _input.Enabled = true;
            _ok.Click += new EventHandler(IncreaseSize);
        }
        
        private void IncreaseSize(object sender, EventArgs e)
        {
            int x = int.Parse(_input.Text);
            _ok.Click -= new EventHandler(IncreaseSize);
            _ok.Enabled = false;
            _input.Enabled = false;
            _cellSize += x;
            _fieldPictureBox.Size = new Size(_fieldSize * _cellSize, _fieldSize * _cellSize);
            _fieldPictureBox.Location = new Point(250, 0);
            _fieldPictureBox.Image =
                new Bitmap(_fieldNow, new Size(_fieldSize * _cellSize, _fieldSize * _cellSize));
            _fieldNow = _fieldPictureBox.Image;
        }
        
        /// <summary>
        /// Функции, отвечающие за задание нового размера поля
        /// </summary>
        private void ReadFieldSize(object sender, EventArgs e)
        {
            _ok.Enabled = true;
            _input.Enabled = true;
            _ok.Click += new EventHandler(ChangeFieldSize);
        }

        private void ChangeFieldSize(object sender, EventArgs e)
        {
            _fieldSize = int.Parse(_input.Text);
            Begin();
        }
    }
}