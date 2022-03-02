using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Reproductor : UserControl
    {
        public Reproductor()
        {
            InitializeComponent();
        }


        private bool pausePlay = true;
        [Category("Apariencia")]
        [Description("Pone el componente en Pausa o Play")]
        public bool PausePlay
        {
            set
            {
                pausePlay = value;
                button1.Image = value ? Properties.Resources.pausa : Properties.Resources.play;
            }
            get
            {
                return pausePlay;
            }
        }

        private int mm;
        [Category("Apariencia")]
        [Description("Valor entre 0 y 99")]
        public int Mm
        {
            set
            {
                if (value > 99 || value < 0)
                {
                    mm = 0;
                }
                else
                {
                    mm = value;
                }
                Recolocar();
            }
            get
            {
                return mm;
            }
        }

        private int ss;
        [Category("Apariencia")]
        [Description("Valor entre 0 y 59")]
        public int Ss
        {
            set
            {
                if (value > 59)
                {
                    ss = value % 60;
                    DesbordaTiempo?.Invoke(this, EventArgs.Empty);
                }
                else if (value < 0)
                {
                    ss = 0;
                }
                else
                {
                    ss = value;
                }
                Recolocar();
            }
            get
            {
                return ss;
            }
        }

        [Category("pausePlay")]
        [Description("Cambia entre play y pause")]
        public event EventHandler ClickEnPause;

        [Category("Desborda tiempo")]
        [Description("Cuando ss es mayor que 59")]
        public event EventHandler DesbordaTiempo;

        private void Recolocar()
        {
            label1.Text = string.Format("{0:00}:{1:00}", mm, ss);
        }

        private void Click(object sender, EventArgs e)
        {
            ClickEnPause?.Invoke(this, EventArgs.Empty);
            base.OnClick(e);
        }
    }

}
