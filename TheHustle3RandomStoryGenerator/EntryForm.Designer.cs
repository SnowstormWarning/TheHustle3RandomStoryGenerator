
namespace TheHustle3RandomStoryGenerator
{
    partial class EntryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdventureButton = new System.Windows.Forms.Button();
            this.PromptTextBox = new System.Windows.Forms.TextBox();
            this.OptionsListBox = new System.Windows.Forms.ListBox();
            this.SelectOptionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AdventureButton
            // 
            this.AdventureButton.Location = new System.Drawing.Point(373, 12);
            this.AdventureButton.Name = "AdventureButton";
            this.AdventureButton.Size = new System.Drawing.Size(288, 46);
            this.AdventureButton.TabIndex = 0;
            this.AdventureButton.Text = "Start Adventure";
            this.AdventureButton.UseVisualStyleBackColor = true;
            this.AdventureButton.Click += new System.EventHandler(this.AdventureButton_Click);
            // 
            // PromptTextBox
            // 
            this.PromptTextBox.Location = new System.Drawing.Point(12, 64);
            this.PromptTextBox.Multiline = true;
            this.PromptTextBox.Name = "PromptTextBox";
            this.PromptTextBox.ReadOnly = true;
            this.PromptTextBox.Size = new System.Drawing.Size(1033, 475);
            this.PromptTextBox.TabIndex = 1;
            // 
            // OptionsListBox
            // 
            this.OptionsListBox.FormattingEnabled = true;
            this.OptionsListBox.ItemHeight = 32;
            this.OptionsListBox.Location = new System.Drawing.Point(3, 545);
            this.OptionsListBox.Name = "OptionsListBox";
            this.OptionsListBox.Size = new System.Drawing.Size(1042, 356);
            this.OptionsListBox.TabIndex = 2;
            // 
            // SelectOptionButton
            // 
            this.SelectOptionButton.Enabled = false;
            this.SelectOptionButton.Location = new System.Drawing.Point(824, 907);
            this.SelectOptionButton.Name = "SelectOptionButton";
            this.SelectOptionButton.Size = new System.Drawing.Size(221, 46);
            this.SelectOptionButton.TabIndex = 3;
            this.SelectOptionButton.Text = "Select Option";
            this.SelectOptionButton.UseVisualStyleBackColor = true;
            this.SelectOptionButton.Click += new System.EventHandler(this.SelectOptionButton_Click);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 992);
            this.Controls.Add(this.SelectOptionButton);
            this.Controls.Add(this.OptionsListBox);
            this.Controls.Add(this.PromptTextBox);
            this.Controls.Add(this.AdventureButton);
            this.Name = "EntryForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AdventureButton;
        private System.Windows.Forms.TextBox PromptTextBox;
        private System.Windows.Forms.ListBox OptionsListBox;
        private System.Windows.Forms.Button SelectOptionButton;
    }
}

