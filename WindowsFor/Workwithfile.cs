using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Функции, отвечающие за сохранение поля в файл
        /// </summary>
        private void CreateOpenDialog(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true; 
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                string namefile = OPF.FileNames[0];
                SaveFieldInFile(namefile);
            }
        }

        private void SaveFieldInImage(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true; 
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                string namefile = OPF.FileNames[0];
                _fieldPictureBox.Image.Save(namefile);
            }
        }
        
        private void SaveFieldInFile(string namefile)
        {
            StreamWriter answerfile = new StreamWriter(namefile);
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    answerfile.Write(_field[i, j]);
                }
                answerfile.Write('\n');
            }
            answerfile.Close();
        }
        
        /// <summary>
        /// Функции, отвечающие за открытие поля из файла
        /// </summary>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                string namefile = OPF.FileNames[0];
                ReadFieldFile(namefile);
                DeleteServiceButtons();
                DrawFieldByArray();
                CreateServiceButtons();
            }
        }

        private void OpenImage(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                string namefile = OPF.FileNames[0];
                ReadFieldImage(namefile);
                DeleteServiceButtons();
                _fieldPictureBox.Image = new Bitmap(new Bitmap(namefile), new Size(_fieldSize * _cellSize, _fieldSize * _cellSize));
                _fieldNow = _fieldPictureBox.Image;
                CreateServiceButtons();
            }
        }

        private void ReadFieldImage(string namefile)
        {
            Bitmap a = new Bitmap(new Bitmap(namefile), new Size(_fieldSize * _cellSize, _fieldSize * _cellSize));
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    if (a.GetPixel(i * _cellSize, j * _cellSize) == Color.Bisque)
                    {
                        _field[i, j] = 1;
                        _countGeneration[i, j] = 1;
                    }
                    else
                    {
                        _field[i, j] = 0;
                        _countGeneration[i, j] = 0;
                    }
                }
            }
        }
        
        private void ReadFieldFile(string namefile)
        {
            StreamReader answerfile = new StreamReader(namefile);
            string a;
            a = answerfile.ReadLine();
            _fieldSize = a.Length;
            char[] a2 = a.ToCharArray();
            _field = new int[_fieldSize, _fieldSize];
            for (int j = 0; j < _fieldSize; j++)
            {
                if (a2[j] == '1')
                {
                    _field[0, j] = 1;
                }
                else
                {
                    _field[0, j] = 0;
                }
            }
            for (int i = 1; i < _fieldSize; i++)
            {
                a = answerfile.ReadLine();
                char[] a1 = a.ToCharArray();
                for (int j = 0; j < _fieldSize; j++)
                {
                    if (a1[j] == '1')
                    {
                        _field[i, j] = 1;
                    }
                    else
                    {
                        _field[i, j] = 0;
                    }
                }
            }
            answerfile.Close();
        }
    }
}