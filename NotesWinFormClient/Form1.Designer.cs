namespace NotesWinFormClient
{
    partial class Form1
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
            NotesLB = new ListBox();
            AddNewNoteBtn = new Button();
            NoteTitleTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            NoteTextTB = new TextBox();
            SaveNoteBtn = new Button();
            RefreshNotesListBtn = new Button();
            SuspendLayout();
            // 
            // NotesLB
            // 
            NotesLB.FormattingEnabled = true;
            NotesLB.ItemHeight = 15;
            NotesLB.Location = new Point(12, 41);
            NotesLB.Name = "NotesLB";
            NotesLB.Size = new Size(161, 259);
            NotesLB.TabIndex = 0;
            NotesLB.SelectedIndexChanged += NotesLB_SelectedIndexChanged;
            // 
            // AddNewNoteBtn
            // 
            AddNewNoteBtn.Location = new Point(12, 12);
            AddNewNoteBtn.Name = "AddNewNoteBtn";
            AddNewNoteBtn.Size = new Size(105, 23);
            AddNewNoteBtn.TabIndex = 1;
            AddNewNoteBtn.Text = "Add New Note";
            AddNewNoteBtn.UseVisualStyleBackColor = true;
            AddNewNoteBtn.Click += AddNewNoteBtn_Click;
            // 
            // NoteTitleTB
            // 
            NoteTitleTB.Location = new Point(190, 41);
            NoteTitleTB.Name = "NoteTitleTB";
            NoteTitleTB.Size = new Size(408, 23);
            NoteTitleTB.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 20);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 3;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(190, 67);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 4;
            label2.Text = "Text";
            // 
            // NoteTextTB
            // 
            NoteTextTB.Location = new Point(190, 85);
            NoteTextTB.Multiline = true;
            NoteTextTB.Name = "NoteTextTB";
            NoteTextTB.Size = new Size(408, 212);
            NoteTextTB.TabIndex = 5;
            // 
            // SaveNoteBtn
            // 
            SaveNoteBtn.Location = new Point(497, 303);
            SaveNoteBtn.Name = "SaveNoteBtn";
            SaveNoteBtn.Size = new Size(101, 23);
            SaveNoteBtn.TabIndex = 6;
            SaveNoteBtn.Text = "Save Note";
            SaveNoteBtn.UseVisualStyleBackColor = true;
            SaveNoteBtn.Click += SaveNoteBtn_ClickAsync;
            // 
            // RefreshNotesListBtn
            // 
            RefreshNotesListBtn.Location = new Point(12, 306);
            RefreshNotesListBtn.Name = "RefreshNotesListBtn";
            RefreshNotesListBtn.Size = new Size(161, 23);
            RefreshNotesListBtn.TabIndex = 7;
            RefreshNotesListBtn.Text = "Refresh List";
            RefreshNotesListBtn.UseVisualStyleBackColor = true;
            RefreshNotesListBtn.Click += RefreshNotesListBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 335);
            Controls.Add(RefreshNotesListBtn);
            Controls.Add(SaveNoteBtn);
            Controls.Add(NoteTextTB);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NoteTitleTB);
            Controls.Add(AddNewNoteBtn);
            Controls.Add(NotesLB);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox NotesLB;
        private Button AddNewNoteBtn;
        private TextBox NoteTitleTB;
        private Label label1;
        private Label label2;
        private TextBox NoteTextTB;
        private Button SaveNoteBtn;
        private Button RefreshNotesListBtn;
    }
}