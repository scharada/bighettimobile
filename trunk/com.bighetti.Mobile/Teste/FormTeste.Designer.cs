namespace com.bighetti.Mobile.Teste
{
    partial class FormTeste
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.textBoxDecimal1 = new com.bighetti.Mobile.Controls.TextBoxDecimal();
            this.panelGradient1 = new com.bighetti.Mobile.Controls.PanelGradient();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGradient1 = new com.bighetti.Mobile.Controls.ButtonGradient();
            this.keyboardNumeric1 = new com.bighetti.Mobile.Controls.KeyboardNumeric();
            this.textBoxInteger1 = new com.bighetti.Mobile.Controls.TextBoxInteger();
            this.keyboardNumeric2 = new com.bighetti.Mobile.Controls.KeyboardNumeric();
            this.buttonGradient2 = new com.bighetti.Mobile.Controls.ButtonGradient();
            this.buttonGradient3 = new com.bighetti.Mobile.Controls.ButtonGradient();
            this.panelGradient1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDecimal1
            // 
            this.textBoxDecimal1.Location = new System.Drawing.Point(34, 139);
            this.textBoxDecimal1.Name = "textBoxDecimal1";
            this.textBoxDecimal1.Size = new System.Drawing.Size(67, 20);
            this.textBoxDecimal1.TabIndex = 3;
            // 
            // panelGradient1
            // 
            this.panelGradient1.Controls.Add(this.label1);
            this.panelGradient1.EndColor = System.Drawing.Color.YellowGreen;
            this.panelGradient1.Location = new System.Drawing.Point(19, 53);
            this.panelGradient1.Name = "panelGradient1";
            this.panelGradient1.Size = new System.Drawing.Size(198, 69);
            this.panelGradient1.StartColor = System.Drawing.Color.Yellow;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.Text = "this is a gradient panel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonGradient1
            // 
            this.buttonGradient1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonGradient1.Location = new System.Drawing.Point(19, 14);
            this.buttonGradient1.Name = "buttonGradient1";
            this.buttonGradient1.Size = new System.Drawing.Size(57, 33);
            this.buttonGradient1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonGradient1.TabIndex = 0;
            this.buttonGradient1.Text = "button 1";
            // 
            // keyboardNumeric1
            // 
            this.keyboardNumeric1.Location = new System.Drawing.Point(34, 165);
            this.keyboardNumeric1.Name = "keyboardNumeric1";
            this.keyboardNumeric1.Size = new System.Drawing.Size(67, 83);
            this.keyboardNumeric1.TabIndex = 5;
            // 
            // textBoxInteger1
            // 
            this.textBoxInteger1.Location = new System.Drawing.Point(125, 139);
            this.textBoxInteger1.Name = "textBoxInteger1";
            this.textBoxInteger1.Size = new System.Drawing.Size(67, 20);
            this.textBoxInteger1.TabIndex = 6;
            // 
            // keyboardNumeric2
            // 
            this.keyboardNumeric2.Location = new System.Drawing.Point(125, 165);
            this.keyboardNumeric2.Name = "keyboardNumeric2";
            this.keyboardNumeric2.Size = new System.Drawing.Size(67, 83);
            this.keyboardNumeric2.TabIndex = 7;
            // 
            // buttonGradient2
            // 
            this.buttonGradient2.EndColor = System.Drawing.Color.Yellow;
            this.buttonGradient2.Location = new System.Drawing.Point(82, 14);
            this.buttonGradient2.Name = "buttonGradient2";
            this.buttonGradient2.Size = new System.Drawing.Size(62, 33);
            this.buttonGradient2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonGradient2.TabIndex = 8;
            this.buttonGradient2.Text = "button 2";
            // 
            // buttonGradient3
            // 
            this.buttonGradient3.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonGradient3.Location = new System.Drawing.Point(150, 14);
            this.buttonGradient3.Name = "buttonGradient3";
            this.buttonGradient3.Size = new System.Drawing.Size(67, 33);
            this.buttonGradient3.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.buttonGradient3.TabIndex = 9;
            this.buttonGradient3.Text = "button 3";
            // 
            // FormTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttonGradient3);
            this.Controls.Add(this.buttonGradient2);
            this.Controls.Add(this.keyboardNumeric2);
            this.Controls.Add(this.textBoxInteger1);
            this.Controls.Add(this.keyboardNumeric1);
            this.Controls.Add(this.textBoxDecimal1);
            this.Controls.Add(this.panelGradient1);
            this.Controls.Add(this.buttonGradient1);
            this.Menu = this.mainMenu1;
            this.Name = "FormTeste";
            this.Text = "Test Controls";
            this.Load += new System.EventHandler(this.FormTeste_Load);
            this.panelGradient1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private com.bighetti.Mobile.Controls.ButtonGradient buttonGradient1;
        private com.bighetti.Mobile.Controls.PanelGradient panelGradient1;
        private System.Windows.Forms.Label label1;
        private com.bighetti.Mobile.Controls.TextBoxDecimal textBoxDecimal1;
        private com.bighetti.Mobile.Controls.KeyboardNumeric keyboardNumeric1;
        private com.bighetti.Mobile.Controls.TextBoxInteger textBoxInteger1;
        private com.bighetti.Mobile.Controls.KeyboardNumeric keyboardNumeric2;
        private com.bighetti.Mobile.Controls.ButtonGradient buttonGradient2;
        private com.bighetti.Mobile.Controls.ButtonGradient buttonGradient3;





    }
}

