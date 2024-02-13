using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int[,] _field;
        private int[,] _newField;
        private Image _backgroundForField = (new Bitmap(_cellSize * _fieldSize, _cellSize * _fieldSize));

        /// <summary>
        /// Функция, заполняющая массив _field
        /// </summary>
        private void FillArrayField()
        {
            if (!_isNotRandom)
            {
                Random random = new Random();
                for (int i = 0; i < _fieldSize; i++)
                {
                    for (int j = 0; j < _fieldSize; j++)
                    {
                        _field[i, j] = random.Next(0, 2);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _fieldSize; i++)
                {
                    for (int j = 0; j < _fieldSize; j++)
                    {
                        _field[i, j] = 0;
                    }
                }
            }
            DrawFieldByArray();
        }
        
        /// <summary>
        ///Функция, рисующая поле на экране
        /// </summary>
        private void DrawFieldByArray()
        {
            _fieldPictureBox = new PictureBox();
            this.Controls.Clear();
            _fieldPictureBox.Image = _backgroundForField;
            _fieldNow = _backgroundForField;
            _fieldPictureBox.Size = new Size(_fieldSize * _cellSize, _fieldSize * _cellSize);
            _fieldPictureBox.Location = new Point(250, 0);
            _fieldPictureBox.MouseClick += ChangeCellState;
            this.Controls.Add(_fieldPictureBox);
            _fieldPictureBox.MouseMove += PrintCellGenerations;
            
            _showCountGeneration = new Button();
            _showCountGeneration.Size = new Size(25, 25);
            _showCountGeneration.Location = new Point(0, 10);
            _showCountGeneration.BackColor = Color.Bisque;
            this.Controls.Add(_showCountGeneration);
            
            _g = Graphics.FromImage(_fieldNow);
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    if (_field[i, j] == 1)
                    {
                        _g.FillEllipse(Brushes.Bisque,i * _cellSize, j * _cellSize, _cellSize, _cellSize);
                        _countGeneration[i, j] = 1;
                    }
                    else
                    {
                        _g.FillEllipse(Brushes.White,i * _cellSize, j * _cellSize, _cellSize, _cellSize);
                        _countGeneration[i, j] = 0;
                    }
                }
            }
            _fieldPictureBox.Image = _fieldNow;
        }
        
        /// <summary>
        /// Функция, отвечающая за открытие предыдущего поля
        /// </summary>
        private void OpenPreviousField(object sender, EventArgs e)
        {
            DrawFieldByArray();
            CreateServiceButtons();
        }
    }
}