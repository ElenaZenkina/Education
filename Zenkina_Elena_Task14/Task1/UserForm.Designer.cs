﻿namespace Task1
{
    partial class UserForm
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
            this.lblUserFirstName = new System.Windows.Forms.Label();
            this.tbxUserFirstName = new System.Windows.Forms.TextBox();
            this.tbxUserLastName = new System.Windows.Forms.TextBox();
            this.lblUserLastName = new System.Windows.Forms.Label();
            this.lblUserBirthday = new System.Windows.Forms.Label();
            this.tbxUserAge = new System.Windows.Forms.TextBox();
            this.lblUserAge = new System.Windows.Forms.Label();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ctlErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblRewardList = new System.Windows.Forms.Label();
            this.lbxRewardList = new System.Windows.Forms.ListBox();
            this.lblAddReward = new System.Windows.Forms.Label();
            this.cbxAddReward = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctlErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserFirstName
            // 
            this.lblUserFirstName.AutoSize = true;
            this.lblUserFirstName.Location = new System.Drawing.Point(77, 35);
            this.lblUserFirstName.Name = "lblUserFirstName";
            this.lblUserFirstName.Size = new System.Drawing.Size(29, 13);
            this.lblUserFirstName.TabIndex = 0;
            this.lblUserFirstName.Text = "Имя";
            // 
            // tbxUserFirstName
            // 
            this.tbxUserFirstName.Location = new System.Drawing.Point(121, 32);
            this.tbxUserFirstName.Name = "tbxUserFirstName";
            this.tbxUserFirstName.Size = new System.Drawing.Size(128, 20);
            this.tbxUserFirstName.TabIndex = 1;
            // 
            // tbxUserLastName
            // 
            this.tbxUserLastName.Location = new System.Drawing.Point(121, 77);
            this.tbxUserLastName.Name = "tbxUserLastName";
            this.tbxUserLastName.Size = new System.Drawing.Size(128, 20);
            this.tbxUserLastName.TabIndex = 3;
            // 
            // lblUserLastName
            // 
            this.lblUserLastName.AutoSize = true;
            this.lblUserLastName.Location = new System.Drawing.Point(50, 80);
            this.lblUserLastName.Name = "lblUserLastName";
            this.lblUserLastName.Size = new System.Drawing.Size(56, 13);
            this.lblUserLastName.TabIndex = 2;
            this.lblUserLastName.Text = "Фамилия";
            // 
            // lblUserBirthday
            // 
            this.lblUserBirthday.AutoSize = true;
            this.lblUserBirthday.Location = new System.Drawing.Point(20, 130);
            this.lblUserBirthday.Name = "lblUserBirthday";
            this.lblUserBirthday.Size = new System.Drawing.Size(86, 13);
            this.lblUserBirthday.TabIndex = 4;
            this.lblUserBirthday.Text = "Дата рождения";
            // 
            // tbxUserAge
            // 
            this.tbxUserAge.Enabled = false;
            this.tbxUserAge.Location = new System.Drawing.Point(121, 170);
            this.tbxUserAge.Name = "tbxUserAge";
            this.tbxUserAge.Size = new System.Drawing.Size(128, 20);
            this.tbxUserAge.TabIndex = 7;
            // 
            // lblUserAge
            // 
            this.lblUserAge.AutoSize = true;
            this.lblUserAge.Location = new System.Drawing.Point(57, 173);
            this.lblUserAge.Name = "lblUserAge";
            this.lblUserAge.Size = new System.Drawing.Size(49, 13);
            this.lblUserAge.TabIndex = 6;
            this.lblUserAge.Text = "Возраст";
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Location = new System.Drawing.Point(121, 124);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(128, 20);
            this.dtBirthDate.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(54, 385);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ctlErrorProvider
            // 
            this.ctlErrorProvider.ContainerControl = this;
            // 
            // lblRewardList
            // 
            this.lblRewardList.AutoSize = true;
            this.lblRewardList.Location = new System.Drawing.Point(24, 214);
            this.lblRewardList.Name = "lblRewardList";
            this.lblRewardList.Size = new System.Drawing.Size(82, 13);
            this.lblRewardList.TabIndex = 12;
            this.lblRewardList.Text = "Список наград";
            // 
            // lbxRewardList
            // 
            this.lbxRewardList.FormattingEnabled = true;
            this.lbxRewardList.Location = new System.Drawing.Point(121, 214);
            this.lbxRewardList.Name = "lbxRewardList";
            this.lbxRewardList.Size = new System.Drawing.Size(128, 69);
            this.lbxRewardList.TabIndex = 13;
            // 
            // lblAddReward
            // 
            this.lblAddReward.AutoSize = true;
            this.lblAddReward.Location = new System.Drawing.Point(6, 297);
            this.lblAddReward.Name = "lblAddReward";
            this.lblAddReward.Size = new System.Drawing.Size(100, 13);
            this.lblAddReward.TabIndex = 14;
            this.lblAddReward.Text = "Добавить награду";
            // 
            // cbxAddReward
            // 
            this.cbxAddReward.FormattingEnabled = true;
            this.cbxAddReward.Location = new System.Drawing.Point(121, 297);
            this.cbxAddReward.Name = "cbxAddReward";
            this.cbxAddReward.Size = new System.Drawing.Size(128, 21);
            this.cbxAddReward.TabIndex = 15;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 448);
            this.Controls.Add(this.cbxAddReward);
            this.Controls.Add(this.lblAddReward);
            this.Controls.Add(this.lbxRewardList);
            this.Controls.Add(this.lblRewardList);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtBirthDate);
            this.Controls.Add(this.tbxUserAge);
            this.Controls.Add(this.lblUserAge);
            this.Controls.Add(this.lblUserBirthday);
            this.Controls.Add(this.tbxUserLastName);
            this.Controls.Add(this.lblUserLastName);
            this.Controls.Add(this.tbxUserFirstName);
            this.Controls.Add(this.lblUserFirstName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserFirstName;
        private System.Windows.Forms.TextBox tbxUserFirstName;
        private System.Windows.Forms.TextBox tbxUserLastName;
        private System.Windows.Forms.Label lblUserLastName;
        private System.Windows.Forms.Label lblUserBirthday;
        private System.Windows.Forms.TextBox tbxUserAge;
        private System.Windows.Forms.Label lblUserAge;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ErrorProvider ctlErrorProvider;
        private System.Windows.Forms.ComboBox cbxAddReward;
        private System.Windows.Forms.Label lblAddReward;
        private System.Windows.Forms.ListBox lbxRewardList;
        private System.Windows.Forms.Label lblRewardList;
    }
}