
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int[,] _countGeneration;
        
        /// <summary>
        /// Функция, отвечающая за смену статуса клетки, при нажатии прльзователя
        /// </summary>
        private void ChangeCellState(object sender, MouseEventArgs e)
        {
            _g = Graphics.FromImage(_fieldNow);
            if (_field[e.X/ _cellSize, e.Y/ _cellSize] == 1)
            {
                _g.FillEllipse(Brushes.White,(e.X / _cellSize) * _cellSize , (e.Y / _cellSize) * _cellSize  , _cellSize, _cellSize);
                _field[e.X/ _cellSize, e.Y / _cellSize] = 0;
                _countGeneration[e.X / _cellSize, e.Y / _cellSize] = 0;
            }
            else
            {
                _field[e.X / _cellSize, e.Y/ _cellSize] = 1;
                _countGeneration[e.X / _cellSize, e.Y / _cellSize] += 1;
                _g.FillEllipse(Brushes.Bisque,(e.X/ _cellSize) * _cellSize , (e.Y/ _cellSize) * _cellSize , _cellSize, _cellSize);
            }
            _fieldPictureBox.Image = _fieldNow;
        }
        
        /// <summary>
        /// Функция, отвечающая за показ, сколько поколений подряд клетка была живой
        /// </summary>
        private void PrintCellGenerations(object sender, MouseEventArgs e)
        {
            int x =e.X / _cellSize;
            int y = e.Y  / _cellSize ;
            _showCountGeneration.Text = (_countGeneration[x, y]).ToString();

        }
        
        /// <summary>
        /// Функция, отвечающая за прокрутку поля
        /// </summary>
        private void ScrollHandler(object sender, ScrollEventArgs e) {
            _fieldPictureBox.Invalidate(false);
        }
    }
}