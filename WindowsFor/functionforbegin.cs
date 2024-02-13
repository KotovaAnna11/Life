using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button _startGame = new Button();
        private Button _no = new Button();
        private Button _yes = new Button();
        private bool _isNotRandom = true;
        
        ///Функция, спрашивающая у пользователя, как он хочет начать
        private void Begin()
        {
            this.Controls.Clear();
            _field = new int[_fieldSize, _fieldSize];
            _newField = new int[_fieldSize, _fieldSize];
            _countGeneration = new int[_fieldSize, _fieldSize];

            _startGame.Dispose();
            _startGame = CreateButton(new Point(500, 100), new Size(100, 100),
                "Хотите ли вы самостоятельно задать жизнь?", Color.Bisque);
            this.Controls.Add(_startGame);
            
            _yes.Dispose();
            _yes = CreateButton(new Point(350, 300), new Size(100, 100), "Да! Я хочу пустое поле!", Color.Bisque);
            this.Controls.Add(_yes);
            
            _no.Dispose();
            _no = CreateButton(new Point(650, 300), new Size(100, 100), "Нет, спасибо. Я хочу сгенерированное поле!",
                Color.Bisque);
            this.Controls.Add(_no);
            
            _no.Click += new EventHandler(DeleteStartWindow);
            _yes.Click += new EventHandler(DeleteStartWindow);
        }
        
        /// <summary>
        /// Функция, удаляющая ненужные кнопки
        /// </summary>
        private void DeleteStartWindow(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string text = button.Text;
            _isNotRandom = true;
            _no.Dispose();
            _yes.Dispose();
            _startGame.Dispose();
            if (text == "Нет, спасибо. Я хочу сгенерированное поле!")
            {
                _isNotRandom = false;
            }
            FillArrayField();
            CreateServiceButtons();
        }
    }
}