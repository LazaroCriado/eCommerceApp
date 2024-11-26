namespace eCommerceApp
{
    partial class Form1
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
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.picBoxArticle = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModifiy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.lblField = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.lblCriteria = new System.Windows.Forms.Label();
            this.cmbCriteria = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxArticle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticles
            // 
            this.dgvArticles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Location = new System.Drawing.Point(12, 12);
            this.dgvArticles.MultiSelect = false;
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.RowHeadersWidth = 62;
            this.dgvArticles.RowTemplate.Height = 28;
            this.dgvArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticles.Size = new System.Drawing.Size(705, 367);
            this.dgvArticles.TabIndex = 0;
            this.dgvArticles.SelectionChanged += new System.EventHandler(this.dgvArticles_SelectionChanged);
            // 
            // picBoxArticle
            // 
            this.picBoxArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxArticle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxArticle.Location = new System.Drawing.Point(723, 12);
            this.picBoxArticle.Name = "picBoxArticle";
            this.picBoxArticle.Size = new System.Drawing.Size(362, 367);
            this.picBoxArticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxArticle.TabIndex = 1;
            this.picBoxArticle.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(137, 39);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModifiy
            // 
            this.btnModifiy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModifiy.Location = new System.Drawing.Point(201, 385);
            this.btnModifiy.Name = "btnModifiy";
            this.btnModifiy.Size = new System.Drawing.Size(137, 39);
            this.btnModifiy.TabIndex = 3;
            this.btnModifiy.Text = "Modificar";
            this.btnModifiy.UseVisualStyleBackColor = true;
            this.btnModifiy.Click += new System.EventHandler(this.btnModifiy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(390, 385);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(137, 39);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHide.Location = new System.Drawing.Point(579, 385);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(137, 39);
            this.btnHide.TabIndex = 5;
            this.btnHide.Text = "Dar de baja";
            this.btnHide.UseVisualStyleBackColor = true;
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(14, 453);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(60, 20);
            this.lblField.TabIndex = 6;
            this.lblField.Text = "Campo";
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(80, 449);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(160, 28);
            this.cmbField.TabIndex = 7;
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // lblCriteria
            // 
            this.lblCriteria.AutoSize = true;
            this.lblCriteria.Location = new System.Drawing.Point(281, 453);
            this.lblCriteria.Name = "lblCriteria";
            this.lblCriteria.Size = new System.Drawing.Size(59, 20);
            this.lblCriteria.TabIndex = 8;
            this.lblCriteria.Text = "Criterio";
            // 
            // cmbCriteria
            // 
            this.cmbCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriteria.FormattingEnabled = true;
            this.cmbCriteria.Location = new System.Drawing.Point(346, 449);
            this.cmbCriteria.Name = "cmbCriteria";
            this.cmbCriteria.Size = new System.Drawing.Size(160, 28);
            this.cmbCriteria.TabIndex = 9;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(597, 450);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(160, 26);
            this.txtFilter.TabIndex = 10;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(547, 453);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(44, 20);
            this.lblFilter.TabIndex = 11;
            this.lblFilter.Text = "Filtro";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(777, 444);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(137, 39);
            this.btnFilter.TabIndex = 12;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 495);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmbCriteria);
            this.Controls.Add(this.lblCriteria);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModifiy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.picBoxArticle);
            this.Controls.Add(this.dgvArticles);
            this.Name = "Form1";
            this.Text = "Gestión de Articulos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxArticle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.PictureBox picBoxArticle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModifiy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.Label lblCriteria;
        private System.Windows.Forms.ComboBox cmbCriteria;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnFilter;
    }
}

