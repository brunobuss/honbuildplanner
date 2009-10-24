namespace HoNBuildPlanner
{
    partial class newBuild
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
            this.cbox_heroes = new System.Windows.Forms.ComboBox();
            this.pbox_hero = new System.Windows.Forms.PictureBox();
            this.bt_ok = new System.Windows.Forms.Button();
            this.lb_s_buildName = new System.Windows.Forms.Label();
            this.lb_s_selectHero = new System.Windows.Forms.Label();
            this.tbox_buildname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_hero)).BeginInit();
            this.SuspendLayout();
            // 
            // cbox_heroes
            // 
            this.cbox_heroes.FormattingEnabled = true;
            this.cbox_heroes.Location = new System.Drawing.Point(12, 73);
            this.cbox_heroes.Name = "cbox_heroes";
            this.cbox_heroes.Size = new System.Drawing.Size(187, 21);
            this.cbox_heroes.TabIndex = 0;
            this.cbox_heroes.SelectedIndexChanged += new System.EventHandler(this.cbox_heroes_SelectedIndexChanged);
            // 
            // pbox_hero
            // 
            this.pbox_hero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbox_hero.Location = new System.Drawing.Point(205, 12);
            this.pbox_hero.Name = "pbox_hero";
            this.pbox_hero.Size = new System.Drawing.Size(80, 80);
            this.pbox_hero.TabIndex = 5;
            this.pbox_hero.TabStop = false;
            // 
            // bt_ok
            // 
            this.bt_ok.ForeColor = System.Drawing.Color.Black;
            this.bt_ok.Location = new System.Drawing.Point(205, 112);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(80, 23);
            this.bt_ok.TabIndex = 6;
            this.bt_ok.Text = "Ok";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // lb_s_buildName
            // 
            this.lb_s_buildName.AutoSize = true;
            this.lb_s_buildName.Location = new System.Drawing.Point(9, 9);
            this.lb_s_buildName.Name = "lb_s_buildName";
            this.lb_s_buildName.Size = new System.Drawing.Size(64, 13);
            this.lb_s_buildName.TabIndex = 7;
            this.lb_s_buildName.Text = "Build Name:";
            // 
            // lb_s_selectHero
            // 
            this.lb_s_selectHero.AutoSize = true;
            this.lb_s_selectHero.Location = new System.Drawing.Point(12, 57);
            this.lb_s_selectHero.Name = "lb_s_selectHero";
            this.lb_s_selectHero.Size = new System.Drawing.Size(66, 13);
            this.lb_s_selectHero.TabIndex = 8;
            this.lb_s_selectHero.Text = "Select Hero:";
            // 
            // tbox_buildname
            // 
            this.tbox_buildname.Location = new System.Drawing.Point(12, 25);
            this.tbox_buildname.Name = "tbox_buildname";
            this.tbox_buildname.Size = new System.Drawing.Size(187, 20);
            this.tbox_buildname.TabIndex = 9;
            // 
            // newBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(295, 147);
            this.Controls.Add(this.tbox_buildname);
            this.Controls.Add(this.lb_s_selectHero);
            this.Controls.Add(this.lb_s_buildName);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.pbox_hero);
            this.Controls.Add(this.cbox_heroes);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newBuild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Build";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.newBuild_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_hero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_heroes;
        private System.Windows.Forms.PictureBox pbox_hero;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label lb_s_buildName;
        private System.Windows.Forms.Label lb_s_selectHero;
        private System.Windows.Forms.TextBox tbox_buildname;
    }
}