using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuComponenteGrafico
{
    public partial class MeuBotao : Control
    {
        public MeuBotao()
        {
            InitializeComponent();
            BorderColor = Color.Black;
        }

        #region enumerations
        public enum ShapeType
        {
            Ellipse,
            Rectangle
        }
        #endregion

        #region properties
        private ShapeType _Shape;
        /// <summary>
        /// Seleciona o formato gráfico do botão.
        /// </summary>
        [Description("Modifica o formato gráfico do botão."),
         Category("Appearance"),
         DefaultValue(typeof(ShapeType), "Ellipse"),
         Browsable(true)
        ]
        public ShapeType Shape
        {
            get { return _Shape; }
            set { _Shape = value; }
        }

        private Color _BorderColor;
        /// <summary>
        /// Seleciona a cor da borda do controle.
        /// </summary>
        [Description("Seleciona a cor da borda do controle."),
         Category("Appearance"),
         DefaultValue(typeof(Color), "Black"),
         Browsable(true)
        ]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        private bool _Hovering;

        private bool Hovering
        {
            get { return _Hovering; }
            set
            {
                // como evitar o flickering do componente
                if (value == _Hovering) return;
                _Hovering = value;
                Invalidate();
            }
        }

        private bool _Pressed;

        private bool Pressed
        {
            get { return _Pressed; }
            set { 
                    if(value == _Pressed) return;
                    _Pressed = value; 
                    Invalidate();
                }
        }


        #endregion

        #region events
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Hovering = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            Hovering = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) Pressed = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) Pressed = false;
        }

        #endregion
        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            var r = ClientRectangle;
            r.Width -= 1; r.Height -= 1;

            g.FillRectangle(new SolidBrush(BackColor), r);
            
            Color fill = BackColor;
            if(Pressed)
            {
                fill = Color.Cyan;
            } else if(Hovering) { 
                fill = Color.LightCyan; 
            } else
            {
                fill = BackColor;
            }

            if (Shape == ShapeType.Ellipse)
            {
                g.FillEllipse(new SolidBrush(fill), r);
                g.DrawEllipse(new Pen(BorderColor, 2.0f), r);
            }
            else
            {
                g.FillRectangle(new SolidBrush(fill), r);
                g.DrawRectangle(new Pen(BorderColor, 2.0f), r);
            }

            var f = new Font(Font.Name, (float)r.Height * 0.3f,
                            Font.Style, GraphicsUnit.Pixel);

            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, f, new SolidBrush(ForeColor),
                new RectangleF((float)r.Left, (float)r.Top,
                               (float)r.Width, (float)r.Height), sf);

        }
    }
}
