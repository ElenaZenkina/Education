namespace Task1
{
    partial class MainForm
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddReward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditReward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteReward = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlTabPanel = new System.Windows.Forms.TabControl();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.ctlUserGrid = new System.Windows.Forms.DataGridView();
            this.tpRewards = new System.Windows.Forms.TabPage();
            this.ctlRewardGrid = new System.Windows.Forms.DataGridView();
            this.contextUserMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.contextEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRewardMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextAddReward = new System.Windows.Forms.ToolStripMenuItem();
            this.contextEditReward = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDeleteReward = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.ctlTabPanel.SuspendLayout();
            this.tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlUserGrid)).BeginInit();
            this.tpRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlRewardGrid)).BeginInit();
            this.contextUserMenu.SuspendLayout();
            this.contextRewardMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(992, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUser,
            this.tsmiReward});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(108, 20);
            this.tsmiEdit.Text = "Редактирование";
            // 
            // tsmiUser
            // 
            this.tsmiUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddUser,
            this.tsmiEditUser,
            this.tsmiDeleteUser});
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(152, 22);
            this.tsmiUser.Text = "Пользователи";
            // 
            // tsmiAddUser
            // 
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.Size = new System.Drawing.Size(163, 22);
            this.tsmiAddUser.Text = "Добавить...";
            this.tsmiAddUser.Click += new System.EventHandler(this.tsmiAddUser_Click);
            // 
            // tsmiEditUser
            // 
            this.tsmiEditUser.Name = "tsmiEditUser";
            this.tsmiEditUser.Size = new System.Drawing.Size(163, 22);
            this.tsmiEditUser.Text = "Редактировать...";
            this.tsmiEditUser.Click += new System.EventHandler(this.tsmiEditUser_Click);
            // 
            // tsmiDeleteUser
            // 
            this.tsmiDeleteUser.Name = "tsmiDeleteUser";
            this.tsmiDeleteUser.Size = new System.Drawing.Size(163, 22);
            this.tsmiDeleteUser.Text = "Удалить...";
            this.tsmiDeleteUser.Click += new System.EventHandler(this.tsmiDeleteUser_Click);
            // 
            // tsmiReward
            // 
            this.tsmiReward.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddReward,
            this.tsmiEditReward,
            this.tsmiDeleteReward});
            this.tsmiReward.Name = "tsmiReward";
            this.tsmiReward.Size = new System.Drawing.Size(152, 22);
            this.tsmiReward.Text = "Награды";
            // 
            // tsmiAddReward
            // 
            this.tsmiAddReward.Name = "tsmiAddReward";
            this.tsmiAddReward.Size = new System.Drawing.Size(163, 22);
            this.tsmiAddReward.Text = "Добавить...";
            this.tsmiAddReward.Click += new System.EventHandler(this.tsmiAddReward_Click);
            // 
            // tsmiEditReward
            // 
            this.tsmiEditReward.Name = "tsmiEditReward";
            this.tsmiEditReward.Size = new System.Drawing.Size(163, 22);
            this.tsmiEditReward.Text = "Редактировать...";
            this.tsmiEditReward.Click += new System.EventHandler(this.tsmiEditReward_Click);
            // 
            // tsmiDeleteReward
            // 
            this.tsmiDeleteReward.Name = "tsmiDeleteReward";
            this.tsmiDeleteReward.Size = new System.Drawing.Size(163, 22);
            this.tsmiDeleteReward.Text = "Удалить...";
            this.tsmiDeleteReward.Click += new System.EventHandler(this.tsmiDeleteReward_Click);
            // 
            // ctlTabPanel
            // 
            this.ctlTabPanel.Controls.Add(this.tpUsers);
            this.ctlTabPanel.Controls.Add(this.tpRewards);
            this.ctlTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlTabPanel.Location = new System.Drawing.Point(0, 24);
            this.ctlTabPanel.Name = "ctlTabPanel";
            this.ctlTabPanel.SelectedIndex = 0;
            this.ctlTabPanel.Size = new System.Drawing.Size(992, 378);
            this.ctlTabPanel.TabIndex = 1;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.ctlUserGrid);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(984, 352);
            this.tpUsers.TabIndex = 0;
            this.tpUsers.Text = "Пользователи";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // ctlUserGrid
            // 
            this.ctlUserGrid.AllowUserToOrderColumns = true;
            this.ctlUserGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlUserGrid.ContextMenuStrip = this.contextUserMenu;
            this.ctlUserGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlUserGrid.Location = new System.Drawing.Point(3, 3);
            this.ctlUserGrid.Name = "ctlUserGrid";
            this.ctlUserGrid.Size = new System.Drawing.Size(978, 346);
            this.ctlUserGrid.TabIndex = 0;
            this.ctlUserGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ctlUserGrid_ColumnHeaderMouseClick);
            // 
            // tpRewards
            // 
            this.tpRewards.Controls.Add(this.ctlRewardGrid);
            this.tpRewards.Location = new System.Drawing.Point(4, 22);
            this.tpRewards.Name = "tpRewards";
            this.tpRewards.Padding = new System.Windows.Forms.Padding(3);
            this.tpRewards.Size = new System.Drawing.Size(984, 352);
            this.tpRewards.TabIndex = 1;
            this.tpRewards.Text = "Награды";
            this.tpRewards.UseVisualStyleBackColor = true;
            // 
            // ctlRewardGrid
            // 
            this.ctlRewardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlRewardGrid.ContextMenuStrip = this.contextRewardMenu;
            this.ctlRewardGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlRewardGrid.Location = new System.Drawing.Point(3, 3);
            this.ctlRewardGrid.Name = "ctlRewardGrid";
            this.ctlRewardGrid.Size = new System.Drawing.Size(978, 346);
            this.ctlRewardGrid.TabIndex = 0;
            this.ctlRewardGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ctlUserGrid_ColumnHeaderMouseClick);
            // 
            // contextUserMenu
            // 
            this.contextUserMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextAddUser,
            this.contextEditUser,
            this.contextDeleteUser});
            this.contextUserMenu.Name = "contextUserMenu";
            this.contextUserMenu.Size = new System.Drawing.Size(164, 70);
            // 
            // contextAddUser
            // 
            this.contextAddUser.Name = "contextAddUser";
            this.contextAddUser.Size = new System.Drawing.Size(163, 22);
            this.contextAddUser.Text = "Добавить...";
            this.contextAddUser.Click += new System.EventHandler(this.tsmiAddUser_Click);
            // 
            // contextEditUser
            // 
            this.contextEditUser.Name = "contextEditUser";
            this.contextEditUser.Size = new System.Drawing.Size(163, 22);
            this.contextEditUser.Text = "Редактировать...";
            this.contextEditUser.Click += new System.EventHandler(this.tsmiEditUser_Click);
            // 
            // contextDeleteUser
            // 
            this.contextDeleteUser.Name = "contextDeleteUser";
            this.contextDeleteUser.Size = new System.Drawing.Size(163, 22);
            this.contextDeleteUser.Text = "Удалить...";
            this.contextDeleteUser.Click += new System.EventHandler(this.tsmiDeleteUser_Click);
            // 
            // contextRewardMenu
            // 
            this.contextRewardMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextAddReward,
            this.contextEditReward,
            this.contextDeleteReward});
            this.contextRewardMenu.Name = "contextRewardMenu";
            this.contextRewardMenu.Size = new System.Drawing.Size(164, 70);
            this.contextRewardMenu.Click += new System.EventHandler(this.tsmiAddReward_Click);
            // 
            // contextAddReward
            // 
            this.contextAddReward.Name = "contextAddReward";
            this.contextAddReward.Size = new System.Drawing.Size(163, 22);
            this.contextAddReward.Text = "Добавить...";
            this.contextAddReward.Click += new System.EventHandler(this.tsmiAddReward_Click);
            // 
            // contextEditReward
            // 
            this.contextEditReward.Name = "contextEditReward";
            this.contextEditReward.Size = new System.Drawing.Size(163, 22);
            this.contextEditReward.Text = "Редактировать...";
            this.contextEditReward.Click += new System.EventHandler(this.tsmiEditReward_Click);
            // 
            // contextDeleteReward
            // 
            this.contextDeleteReward.Name = "contextDeleteReward";
            this.contextDeleteReward.Size = new System.Drawing.Size(163, 22);
            this.contextDeleteReward.Text = "Удалить...";
            this.contextDeleteReward.Click += new System.EventHandler(this.tsmiDeleteReward_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 402);
            this.Controls.Add(this.ctlTabPanel);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Задание 14";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ctlTabPanel.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlUserGrid)).EndInit();
            this.tpRewards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlRewardGrid)).EndInit();
            this.contextUserMenu.ResumeLayout(false);
            this.contextRewardMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiReward;
        private System.Windows.Forms.TabControl ctlTabPanel;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tpRewards;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddReward;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditReward;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteReward;
        private System.Windows.Forms.ContextMenuStrip contextUserMenu;
        private System.Windows.Forms.ToolStripMenuItem contextAddUser;
        private System.Windows.Forms.ToolStripMenuItem contextEditUser;
        private System.Windows.Forms.ToolStripMenuItem contextDeleteUser;
        private System.Windows.Forms.ContextMenuStrip contextRewardMenu;
        private System.Windows.Forms.ToolStripMenuItem contextAddReward;
        private System.Windows.Forms.ToolStripMenuItem contextEditReward;
        private System.Windows.Forms.ToolStripMenuItem contextDeleteReward;
        private System.Windows.Forms.DataGridView ctlUserGrid;
        private System.Windows.Forms.DataGridView ctlRewardGrid;
    }
}

