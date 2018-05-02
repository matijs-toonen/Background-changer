﻿namespace UIWebscraper.Forms
{
    partial class WebSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGetHtml = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.radioTextField = new System.Windows.Forms.RadioButton();
            this.radioImages = new System.Windows.Forms.RadioButton();
            this.checkChildElements = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(53, 57);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(441, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // btnGetHtml
            // 
            this.btnGetHtml.Location = new System.Drawing.Point(500, 54);
            this.btnGetHtml.Name = "btnGetHtml";
            this.btnGetHtml.Size = new System.Drawing.Size(75, 23);
            this.btnGetHtml.TabIndex = 2;
            this.btnGetHtml.Text = "Get Html";
            this.btnGetHtml.UseVisualStyleBackColor = true;
            this.btnGetHtml.Click += new System.EventHandler(this.btnGetHtml_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // radioTextField
            // 
            this.radioTextField.AutoSize = true;
            this.radioTextField.Location = new System.Drawing.Point(124, 34);
            this.radioTextField.Name = "radioTextField";
            this.radioTextField.Size = new System.Drawing.Size(68, 17);
            this.radioTextField.TabIndex = 4;
            this.radioTextField.Text = "Text field";
            this.radioTextField.UseVisualStyleBackColor = true;
            // 
            // radioImages
            // 
            this.radioImages.AutoSize = true;
            this.radioImages.Checked = true;
            this.radioImages.Location = new System.Drawing.Point(53, 34);
            this.radioImages.Name = "radioImages";
            this.radioImages.Size = new System.Drawing.Size(65, 17);
            this.radioImages.TabIndex = 5;
            this.radioImages.TabStop = true;
            this.radioImages.Text = "Image(s)";
            this.radioImages.UseVisualStyleBackColor = true;
            // 
            // checkChildElements
            // 
            this.checkChildElements.AutoSize = true;
            this.checkChildElements.Location = new System.Drawing.Point(198, 35);
            this.checkChildElements.Name = "checkChildElements";
            this.checkChildElements.Size = new System.Drawing.Size(95, 17);
            this.checkChildElements.TabIndex = 6;
            this.checkChildElements.Text = "Child Elements";
            this.checkChildElements.UseVisualStyleBackColor = true;
            // 
            // WebSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkChildElements);
            this.Controls.Add(this.radioImages);
            this.Controls.Add(this.radioTextField);
            this.Controls.Add(this.btnGetHtml);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Name = "WebSettings";
            this.Text = "Webscraper";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGetHtml;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkChildElements;
        private System.Windows.Forms.RadioButton radioImages;
        private System.Windows.Forms.RadioButton radioTextField;
    }
}

