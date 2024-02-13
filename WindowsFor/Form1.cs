
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public System.Windows.Forms.Panel MapPanel;
        private static int _fieldSize = 1024;
        private static int _cellSize = 10;
        
        public Form1()
        {
            InitializeComponent();
            AutoScroll = true;
            this.BackColor = Color.SeaShell;
            this.Scroll += ScrollHandler;
            this.Text= "Life";
            Begin();
        }
    }
}