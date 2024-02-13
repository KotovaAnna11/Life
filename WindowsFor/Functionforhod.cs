using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Timer _timer;

        /// <summary>
        /// Функции, считающие останется ли живой клетка в следующем раунде
        /// </summary>
        private int CountNeighbors(int i, int j)
        {
            int sum = 0;
            sum += _field[(((i - 1) % _fieldSize) + _fieldSize) % _fieldSize, (((j - 1) % _fieldSize) + _fieldSize) % _fieldSize];
            sum += _field[(((i - 1) % _fieldSize) + _fieldSize) % _fieldSize, (j + 1) % _fieldSize];
            sum += _field[(i + 1) % _fieldSize, (((j - 1) % _fieldSize) + _fieldSize) % _fieldSize];
            sum += _field[(i + 1) % _fieldSize, (j + 1) % _fieldSize];
            sum += _field[(i) % _fieldSize, (j + 1) % _fieldSize];
            sum += _field[(i) % _fieldSize, (((j - 1) % _fieldSize) + _fieldSize) % _fieldSize];
            sum += _field[(((i - 1) % _fieldSize) + _fieldSize) % _fieldSize, (j) % _fieldSize];
            sum += _field[(i + 1) % _fieldSize, (j) % _fieldSize];
            return sum;
        }
        
        private bool IsLifeCellState(int i, int j)
        {
            int sum = CountNeighbors(i, j);
            return (_isLifeCellState.IndexOf(sum) != -1);
        }
        
        private bool IsDeadCellBecomeLifeCell(int i, int j)
        {
            int sum = CountNeighbors(i, j);
            return (_isDeadCellStateLifeCell.IndexOf(sum) != -1);
        }
        
        /// <summary>
        /// функции, отвечающие за ходы в игре
        /// </summary>
        private void MoveField(object sender, EventArgs e)
        {
            OneMove();
        }
        
        private void ReadCountForMove(object sender, EventArgs e)
        {
            _ok.Enabled = true;
            _input.Enabled = true;
            _ok.Click += new EventHandler(FewMoves);
        }
        
        private void FewMoves(object sender, EventArgs e)
        {
            int x = int.Parse(_input.Text);
            _ok.Click -= new EventHandler(FewMoves);
            _ok.Enabled = false;
            _input.Enabled = false;
            MovesByCount(x);
        }
        
        private void OneMove()
        {
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    if ((IsLifeCellState(i, j) && (_field[i, j] == 1)) || ((IsDeadCellBecomeLifeCell(i, j)) && (_field[i, j] == 0)))
                    {
                        _newField[i, j] = 1;
                        _countGeneration[i, j] += 1;

                    }
                    else
                    {
                        _newField[i, j] = 0;
                        _countGeneration[i, j] = 0;

                    }
                }
            }
            _g = Graphics.FromImage(_fieldNow);
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    if (_newField[i, j] == 0)
                    {
                        _g.FillEllipse(Brushes.White,i * _cellSize, j * _cellSize, _cellSize, _cellSize);
                        _field[i, j] = 0;
                    }
                    else
                    {
                        _g.FillEllipse(Brushes.Bisque,i * _cellSize, j * _cellSize, _cellSize, _cellSize);
                        _field[i, j] = 1;
                    }
                }
            }
            _fieldPictureBox.Image = _fieldNow;
        }
        
        private void MovesByCount(int count)
        {
            for (int i = 0; i < count; i++)
            {
                OneMove();
            }
        }
        
        /// <summary>
        /// Функции, отвечающие за таймер
        /// </summary>
        private void StopTimer(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            
            _timerForMove.Dispose();
            _timerForMove = new Button();
            _timerForMove.Location = new Point(100, 250);
            _timerForMove.Size = new Size(100, 100);
            _timerForMove.Text = "Хочу включить таймер!";
            _timerForMove.BackColor = Color.Bisque;
            this.Controls.Add(_timerForMove);
            _timerForMove.Click += new EventHandler(StartTimer);
        }

        private void StartTimer(object sender, EventArgs e)
        {
            _timerForMove.Dispose();
            _timerForMove = new Button();
            _timerForMove.Location = new Point(100, 250);
            _timerForMove.Size = new Size(100, 100);
            _timerForMove.Text = "Хочу выключить таймер!";
            _timerForMove.BackColor = Color.Bisque;
            this.Controls.Add(_timerForMove);
            _timerForMove.Click += new EventHandler(StopTimer);
            
            _timer = new Timer();
            _timer.Interval = 10000;
            _timer.Tick += new EventHandler(OneTimerStep);
            _timer.Enabled = true;
        }

        private void OneTimerStep(object sender, EventArgs e)
        {
            OneMove();
        }
    }
}