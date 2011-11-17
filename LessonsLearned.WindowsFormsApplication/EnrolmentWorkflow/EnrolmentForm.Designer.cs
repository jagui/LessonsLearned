namespace LessonsLearned.WindowsFormsApplication.EnrolmentWorkflow
{
    partial class EnrolmentForm
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
            this.EnrolButton = new System.Windows.Forms.Button();
            this.DateOfBirthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnrolButton
            // 
            this.EnrolButton.Location = new System.Drawing.Point(248, 152);
            this.EnrolButton.Name = "EnrolButton";
            this.EnrolButton.Size = new System.Drawing.Size(75, 23);
            this.EnrolButton.TabIndex = 13;
            this.EnrolButton.Text = "Enrol";
            this.EnrolButton.UseVisualStyleBackColor = true;
            this.EnrolButton.Click += new System.EventHandler(this.EnrolButton_Click);
            // 
            // DateOfBirthDatePicker
            // 
            this.DateOfBirthDatePicker.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DateOfBirthDatePicker.Location = new System.Drawing.Point(123, 110);
            this.DateOfBirthDatePicker.Name = "DateOfBirthDatePicker";
            this.DateOfBirthDatePicker.Size = new System.Drawing.Size(200, 20);
            this.DateOfBirthDatePicker.TabIndex = 12;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(123, 63);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.LastNameTextBox.TabIndex = 11;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(123, 17);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.FirstNameTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date Of Birth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "First Name";
            // 
            // EnrolmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 194);
            this.Controls.Add(this.EnrolButton);
            this.Controls.Add(this.DateOfBirthDatePicker);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EnrolmentForm";
            this.Text = "EnrolmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnrolButton;
        private System.Windows.Forms.DateTimePicker DateOfBirthDatePicker;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}