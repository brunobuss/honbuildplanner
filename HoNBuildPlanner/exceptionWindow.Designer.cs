namespace HoNBuildPlanner
{
    partial class exceptionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(exceptionWindow));
            this.pbox_behemot = new System.Windows.Forms.PictureBox();
            this.lbl_crash = new System.Windows.Forms.Label();
            this.rtbox = new System.Windows.Forms.RichTextBox();
            this.lb_stack = new System.Windows.Forms.Label();
            this.rtbox_stack = new System.Windows.Forms.RichTextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_continue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_behemot)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox_behemot
            // 
            this.pbox_behemot.ErrorImage = null;
            this.pbox_behemot.Image = ((System.Drawing.Image)(resources.GetObject("pbox_behemot.Image")));
            this.pbox_behemot.InitialImage = null;
            this.pbox_behemot.Location = new System.Drawing.Point(0, 0);
            this.pbox_behemot.Name = "pbox_behemot";
            this.pbox_behemot.Size = new System.Drawing.Size(300, 300);
            this.pbox_behemot.TabIndex = 0;
            this.pbox_behemot.TabStop = false;
            // 
            // lbl_crash
            // 
            this.lbl_crash.AutoSize = true;
            this.lbl_crash.Location = new System.Drawing.Point(306, 9);
            this.lbl_crash.Name = "lbl_crash";
            this.lbl_crash.Size = new System.Drawing.Size(74, 13);
            this.lbl_crash.TabIndex = 1;
            this.lbl_crash.Text = "Crash Handler";
            // 
            // rtbox
            // 
            this.rtbox.BackColor = System.Drawing.Color.LightGray;
            this.rtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbox.Location = new System.Drawing.Point(309, 25);
            this.rtbox.Name = "rtbox";
            this.rtbox.ReadOnly = true;
            this.rtbox.Size = new System.Drawing.Size(335, 113);
            this.rtbox.TabIndex = 2;
            this.rtbox.Text = resources.GetString("rtbox.Text");
            // 
            // lb_stack
            // 
            this.lb_stack.AutoSize = true;
            this.lb_stack.Location = new System.Drawing.Point(306, 141);
            this.lb_stack.Name = "lb_stack";
            this.lb_stack.Size = new System.Drawing.Size(69, 13);
            this.lb_stack.TabIndex = 3;
            this.lb_stack.Text = "Stack Trace:";
            // 
            // rtbox_stack
            // 
            this.rtbox_stack.Location = new System.Drawing.Point(309, 157);
            this.rtbox_stack.Name = "rtbox_stack";
            this.rtbox_stack.Size = new System.Drawing.Size(335, 108);
            this.rtbox_stack.TabIndex = 4;
            this.rtbox_stack.Text = "";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(480, 271);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(164, 23);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "Close HoN Build Planner";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_continue
            // 
            this.btn_continue.Location = new System.Drawing.Point(309, 271);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(165, 23);
            this.btn_continue.TabIndex = 6;
            this.btn_continue.Text = "Ok, ok! Let me finish my build!";
            this.btn_continue.UseVisualStyleBackColor = true;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // exceptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(656, 300);
            this.Controls.Add(this.btn_continue);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.rtbox_stack);
            this.Controls.Add(this.lb_stack);
            this.Controls.Add(this.rtbox);
            this.Controls.Add(this.lbl_crash);
            this.Controls.Add(this.pbox_behemot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "exceptionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Oops! Looks like something DENIED you =/";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.exceptionWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_behemot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox_behemot;
        private System.Windows.Forms.Label lbl_crash;
        private System.Windows.Forms.RichTextBox rtbox;
        private System.Windows.Forms.Label lb_stack;
        private System.Windows.Forms.RichTextBox rtbox_stack;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_continue;
    }
}