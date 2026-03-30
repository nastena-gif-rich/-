using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Основная таблица товаров
                    string query = @"
                        SELECT 
                            ProductName AS [Наименование],
                            Quantity AS [Количество],
                            Price AS [Цена],
                            (Quantity * Price) AS [Сумма]
                        FROM Products
                        WHERE Quantity > 0
                        ORDER BY ProductName";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReport.DataSource = dt;

                    // Форматирование цен
                    if (dgvReport.Columns.Contains("Цена"))
                        dgvReport.Columns["Цена"].DefaultCellStyle.Format = "N2";
                    if (dgvReport.Columns.Contains("Сумма"))
                        dgvReport.Columns["Сумма"].DefaultCellStyle.Format = "N2";

                    // ========== СЧИТАЕМ СТАТИСТИКУ ==========

                    // Общая сумма и общее количество
                    decimal totalSum = 0;
                    int totalItems = 0;
                    decimal minPrice = decimal.MaxValue;
                    decimal maxPrice = 0;
                    string minPriceProduct = "";
                    string maxPriceProduct = "";

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["Количество"]);
                        decimal price = Convert.ToDecimal(row["Цена"]);
                        decimal sum = Convert.ToDecimal(row["Сумма"]);

                        totalSum += sum;
                        totalItems += qty;

                        // Самый дешевый товар
                        if (price < minPrice)
                        {
                            minPrice = price;
                            minPriceProduct = row["Наименование"].ToString();
                        }

                        // Самый дорогой товар
                        if (price > maxPrice)
                        {
                            maxPrice = price;
                            maxPriceProduct = row["Наименование"].ToString();
                        }
                    }

                    // Средняя цена
                    decimal avgPrice = dt.Rows.Count > 0 ? totalSum / totalItems : 0;

                    // Количество уникальных товаров
                    int productCount = dt.Rows.Count;

                    // Заполняем статистику
                    lblTotalSum.Text = $"{totalSum:C}";
                    lblTotalItems.Text = totalItems.ToString("N0");
                    lblProductCount.Text = productCount.ToString();
                    lblAvgPrice.Text = $"{avgPrice:C}";

                    if (productCount > 0)
                    {
                        lblMinPrice.Text = $"{minPrice:C} ({minPriceProduct})";
                        lblMaxPrice.Text = $"{maxPrice:C} ({maxPriceProduct})";
                    }
                    else
                    {
                        lblMinPrice.Text = "Нет товаров";
                        lblMaxPrice.Text = "Нет товаров";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отчета: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTotalSumTitle_Click(object sender, EventArgs e)
        {

        }

        private void panelStats_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}