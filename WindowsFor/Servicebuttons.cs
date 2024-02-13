using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button _oneMove = new Button();
        private Button _fewMoves = new Button();
        private Button _timerForMove = new Button();
        private TextBox _input;
        private Button _ok = new Button();
        private Button _openFieldWithFile = new Button();
        private Button _openFieldWithImage = new Button();
        private Button _saveFieldInFile = new Button();
        private Button _saveFieldInImage = new Button();
        private Button _increaseCell = new Button();
        private Button _reduceCell = new Button();
        private Button _changeRules = new Button();
        private Button _changeFieldSize = new Button();
        private Button _showCountGeneration = new Button();


        /// <summary>
        /// Функция, создающая кнопку по параметрам
        /// </summary>
        private Button CreateButton( Point point, Size size, string text, Color color)
        {
            Button button = new Button();
            button.Location = point;
            button.Size = size;
            button.Text = text;
            button.BackColor = color;
            return button;
        }

        /// <summary>
        /// Функция, отвечающая за создание служебных кнопок
        /// </summary>
        private void CreateServiceButtons()
        {
            _oneMove = CreateButton(new Point(0, 100), new Size(100, 100), "Хочу сделать 1 ход!",
                Color.Bisque);
            this.Controls.Add(_oneMove);
            _oneMove.Click += new EventHandler(MoveField);

            _fewMoves = CreateButton( new Point(0, 250), new Size(100, 100), "Хочу сделать несколько ходов!", Color.Bisque);
            this.Controls.Add(_fewMoves);
            _fewMoves.Click += new EventHandler(ReadCountForMove);
            
            _timerForMove = CreateButton(  new Point(100, 250), new Size(100, 100), "Хочу включить таймер!", Color.Bisque);
            _timerForMove.Click += new EventHandler(StartTimer);
            this.Controls.Add(_timerForMove);
            
            _openFieldWithFile = CreateButton( new Point(0, 400), new Size(100, 100), "Хочу открыть поле из файла!", Color.Bisque  );
            _openFieldWithFile.Click += new EventHandler(OpenFile);
            this.Controls.Add(_openFieldWithFile);
            
            _openFieldWithImage = CreateButton( new Point(100, 400), new Size(100, 100),  "Хочу открыть поле из файла с расширением jpg!", Color.Bisque );
            _openFieldWithImage.Click += new EventHandler(OpenImage);
            this.Controls.Add(_openFieldWithImage);

            _saveFieldInFile = CreateButton( new Point(0 , 550), new Size(100, 100), "Хочу сохранить это поле в файл!", Color.Bisque );
            _saveFieldInFile.Click += new EventHandler(CreateOpenDialog);
            this.Controls.Add(_saveFieldInFile);

            _saveFieldInImage = CreateButton( new Point(100, 550), new Size(100, 100), "Хочу сохранить это поле в файл с расширением jpg!", Color.Bisque );
            _saveFieldInImage.Click += new EventHandler(SaveFieldInImage);
            this.Controls.Add(_saveFieldInImage);

            _increaseCell = CreateButton( new Point(0, 700), new Size(100, 100), "+", Color.Bisque);
            _increaseCell.Click += new EventHandler(IncreaseCellSize);
            this.Controls.Add(_increaseCell);

            _reduceCell = CreateButton( new Point(0, 850), new Size(100, 100), "-", Color.Bisque);
            _reduceCell.Click += new EventHandler(ReduceCellSize);
            this.Controls.Add(_reduceCell);

            _changeFieldSize = CreateButton( new Point(0 , 1000), new Size(100, 100), "Задать размер", Color.Bisque );
            _changeFieldSize.Click += ReadFieldSize;
            this.Controls.Add(_changeFieldSize);

            _changeRules = CreateButton( new Point(0, 1150), new Size(100, 100), "Изменить правила", Color.Bisque);
            _changeRules.Click += CreateCheckBoxes;
            this.Controls.Add(_changeRules);
            
            _ok = CreateButton(new Point(100, 25), new Size(30, 30), "OK", Color.Bisque);
            this.Controls.Add(_ok);
            _ok.Enabled = false;

            _input = CreateButtonInput();
            this.Controls.Add(_input);
            _input.Enabled = false;
        }
        
        /// <summary>
        /// Функция, отвечающая за удаление сервисных кнопок
        /// </summary>
        private void DeleteServiceButtons()
        {
            _changeFieldSize.Dispose();
            _oneMove.Dispose();
            _fewMoves.Dispose();
            _timerForMove.Dispose();
            _saveFieldInFile.Dispose();
            _saveFieldInImage.Dispose();
            _openFieldWithFile.Dispose();
            _openFieldWithImage.Dispose();
            _increaseCell.Dispose();
            _reduceCell.Dispose();
            _changeRules.Dispose();
            _ok.Dispose();
            _input.Dispose();
            
        }
        
        /// <summary>
        /// Функция, отвечающая за создание промежуточной кнопки _input
        /// </summary>

        private TextBox CreateButtonInput()
        {
            TextBox t= new TextBox();
            t.Location = new Point(50, 20);
            t.Size = new Size(50, 50);
            return t;
        }
    }
}