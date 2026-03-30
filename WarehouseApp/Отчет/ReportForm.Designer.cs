namespace WarehouseApp
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelStats;

        // Статистические метки
        private System.Windows.Forms.Label lblTotalSumTitle;
        private System.Windows.Forms.Label lblTotalSum;
        private System.Windows.Forms.Label lblTotalItemsTitle;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblProductCountTitle;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label lblAvgPriceTitle;
        private System.Windows.Forms.Label lblAvgPrice;
        private System.Windows.Forms.Label lblMinPriceTitle;
        private System.Windows.Forms.Label lblMinPrice;
        private System.Windows.Forms.Label lblMaxPriceTitle;
        private System.Windows.Forms.Label lblMaxPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblTotalSumTitle = new System.Windows.Forms.Label();
            this.lblTotalSum = new System.Windows.Forms.Label();
            this.lblTotalItemsTitle = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblProductCountTitle = new System.Windows.Forms.Label();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.lblAvgPriceTitle = new System.Windows.Forms.Label();
            this.lblAvgPrice = new System.Windows.Forms.Label();
            this.lblMinPriceTitle = new System.Windows.Forms.Label();
            this.lblMinPrice = new System.Windows.Forms.Label();
            this.lblMaxPriceTitle = new System.Windows.Forms.Label();
            this.lblMaxPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(209)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(209)))));
            this.dgvReport.Location = new System.Drawing.Point(0, 140);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowTemplate.Height = 35;
            this.dgvReport.Size = new System.Drawing.Size(1000, 460);
            this.dgvReport.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(213)))), ((int)(((byte)(223)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            this.panelTop.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(197)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnClose.Location = new System.Drawing.Point(900, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "❌ Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelStats.Controls.Add(this.lblTotalSumTitle);
            this.panelStats.Controls.Add(this.lblTotalSum);
            this.panelStats.Controls.Add(this.lblTotalItemsTitle);
            this.panelStats.Controls.Add(this.lblTotalItems);
            this.panelStats.Controls.Add(this.lblProductCountTitle);
            this.panelStats.Controls.Add(this.lblProductCount);
            this.panelStats.Controls.Add(this.lblAvgPriceTitle);
            this.panelStats.Controls.Add(this.lblAvgPrice);
            this.panelStats.Controls.Add(this.lblMinPriceTitle);
            this.panelStats.Controls.Add(this.lblMinPrice);
            this.panelStats.Controls.Add(this.lblMaxPriceTitle);
            this.panelStats.Controls.Add(this.lblMaxPrice);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 50);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1000, 90);
            this.panelStats.TabIndex = 2;
            this.panelStats.Paint += new System.Windows.Forms.PaintEventHandler(this.panelStats_Paint);
            // 
            // lblTotalSumTitle
            // 
            this.lblTotalSumTitle.AutoSize = true;
            this.lblTotalSumTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalSumTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblTotalSumTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTotalSumTitle.Name = "lblTotalSumTitle";
            this.lblTotalSumTitle.Size = new System.Drawing.Size(135, 19);
            this.lblTotalSumTitle.TabIndex = 0;
            this.lblTotalSumTitle.Text = "💰 Общая сумма:";
            this.lblTotalSumTitle.Click += new System.EventHandler(this.lblTotalSumTitle_Click);
            // 
            // lblTotalSum
            // 
            this.lblTotalSum.AutoSize = true;
            this.lblTotalSum.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalSum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblTotalSum.Location = new System.Drawing.Point(163, 11);
            this.lblTotalSum.Name = "lblTotalSum";
            this.lblTotalSum.Size = new System.Drawing.Size(31, 20);
            this.lblTotalSum.TabIndex = 1;
            this.lblTotalSum.Text = "0 ₽";
            // 
            // lblTotalItemsTitle
            // 
            this.lblTotalItemsTitle.AutoSize = true;
            this.lblTotalItemsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalItemsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblTotalItemsTitle.Location = new System.Drawing.Point(20, 37);
            this.lblTotalItemsTitle.Name = "lblTotalItemsTitle";
            this.lblTotalItemsTitle.Size = new System.Drawing.Size(137, 19);
            this.lblTotalItemsTitle.TabIndex = 2;
            this.lblTotalItemsTitle.Text = "📦 Всего товаров:";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblTotalItems.Location = new System.Drawing.Point(163, 37);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(39, 19);
            this.lblTotalItems.TabIndex = 3;
            this.lblTotalItems.Text = "0 шт";
            // 
            // lblProductCountTitle
            // 
            this.lblProductCountTitle.AutoSize = true;
            this.lblProductCountTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProductCountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblProductCountTitle.Location = new System.Drawing.Point(20, 62);
            this.lblProductCountTitle.Name = "lblProductCountTitle";
            this.lblProductCountTitle.Size = new System.Drawing.Size(187, 19);
            this.lblProductCountTitle.TabIndex = 4;
            this.lblProductCountTitle.Text = "🏷️ Наименований всего:";
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProductCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblProductCount.Location = new System.Drawing.Point(213, 62);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(39, 19);
            this.lblProductCount.TabIndex = 5;
            this.lblProductCount.Text = "0 шт";
            // 
            // lblAvgPriceTitle
            // 
            this.lblAvgPriceTitle.AutoSize = true;
            this.lblAvgPriceTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvgPriceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblAvgPriceTitle.Location = new System.Drawing.Point(450, 12);
            this.lblAvgPriceTitle.Name = "lblAvgPriceTitle";
            this.lblAvgPriceTitle.Size = new System.Drawing.Size(135, 19);
            this.lblAvgPriceTitle.TabIndex = 6;
            this.lblAvgPriceTitle.Text = "📊 Средняя цена:";
            // 
            // lblAvgPrice
            // 
            this.lblAvgPrice.AutoSize = true;
            this.lblAvgPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvgPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblAvgPrice.Location = new System.Drawing.Point(591, 11);
            this.lblAvgPrice.Name = "lblAvgPrice";
            this.lblAvgPrice.Size = new System.Drawing.Size(29, 19);
            this.lblAvgPrice.TabIndex = 7;
            this.lblAvgPrice.Text = "0 ₽";
            // 
            // lblMinPriceTitle
            // 
            this.lblMinPriceTitle.AutoSize = true;
            this.lblMinPriceTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMinPriceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblMinPriceTitle.Location = new System.Drawing.Point(450, 37);
            this.lblMinPriceTitle.Name = "lblMinPriceTitle";
            this.lblMinPriceTitle.Size = new System.Drawing.Size(143, 19);
            this.lblMinPriceTitle.TabIndex = 8;
            this.lblMinPriceTitle.Text = "⬇️ Самый дешевый:";
            // 
            // lblMinPrice
            // 
            this.lblMinPrice.AutoSize = true;
            this.lblMinPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMinPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblMinPrice.Location = new System.Drawing.Point(599, 37);
            this.lblMinPrice.Name = "lblMinPrice";
            this.lblMinPrice.Size = new System.Drawing.Size(47, 19);
            this.lblMinPrice.TabIndex = 9;
            this.lblMinPrice.Text = "0 ₽ (-)";
            // 
            // lblMaxPriceTitle
            // 
            this.lblMaxPriceTitle.AutoSize = true;
            this.lblMaxPriceTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaxPriceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblMaxPriceTitle.Location = new System.Drawing.Point(450, 62);
            this.lblMaxPriceTitle.Name = "lblMaxPriceTitle";
            this.lblMaxPriceTitle.Size = new System.Drawing.Size(138, 19);
            this.lblMaxPriceTitle.TabIndex = 10;
            this.lblMaxPriceTitle.Text = "⬆️ Самый дорогой:";
            // 
            // lblMaxPrice
            // 
            this.lblMaxPrice.AutoSize = true;
            this.lblMaxPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblMaxPrice.Location = new System.Drawing.Point(594, 62);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.Size = new System.Drawing.Size(47, 19);
            this.lblMaxPrice.TabIndex = 11;
            this.lblMaxPrice.Text = "0 ₽ (-)";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "ReportForm";
            this.Text = "📊 Отчет по складу";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}