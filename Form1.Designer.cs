namespace MeuComponenteGrafico
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.progressBarControl1 = new MeuComponenteGrafico.ProgressBarControl();
            this.meuBotao1 = new MeuComponenteGrafico.MeuBotao();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(341, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 136);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.BackgroundColor = System.Drawing.Color.Transparent;
            this.progressBarControl1.IsAnimating = true;
            this.progressBarControl1.Location = new System.Drawing.Point(156, 207);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.ProgressColor = System.Drawing.Color.CornflowerBlue;
            this.progressBarControl1.ProgressValue = 8;
            this.progressBarControl1.Size = new System.Drawing.Size(95, 82);
            this.progressBarControl1.Style = MeuComponenteGrafico.ProgressBarStyle.Vertical;
            this.progressBarControl1.TabIndex = 2;
            this.progressBarControl1.Text = "progressBarControl1";
            this.progressBarControl1.Thickness = 8;
            this.progressBarControl1.Click += new System.EventHandler(this.progressBarControl1_Click);
            // 
            // meuBotao1
            // 
            this.meuBotao1.BorderColor = System.Drawing.Color.Lime;
            this.meuBotao1.Location = new System.Drawing.Point(140, 48);
            this.meuBotao1.Margin = new System.Windows.Forms.Padding(2);
            this.meuBotao1.Name = "meuBotao1";
            this.meuBotao1.Size = new System.Drawing.Size(250, 113);
            this.meuBotao1.TabIndex = 1;
            this.meuBotao1.Text = "Comprar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.meuBotao1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private MeuBotao meuBotao1;
        private ProgressBarControl progressBarControl1;
    }
}

