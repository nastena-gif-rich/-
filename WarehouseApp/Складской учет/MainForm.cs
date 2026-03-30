using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.ProductID AS [ID],
                            p.ProductName AS [Наименование],
                            ISNULL(c.CategoryName, '') AS [Категория],
                            ISNULL(s.SupplierName, '') AS [Поставщик],
                            p.Quantity AS [Количество],
                            p.Price AS [Цена],
                            (p.Quantity * p.Price) AS [Сумма],
                            ISNULL(p.Description, '') AS [Описание]
                        FROM Products p
                        LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                        LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProducts.DataSource = dt;

                    if (dgvProducts.Columns.Contains("Цена"))
                        dgvProducts.Columns["Цена"].DefaultCellStyle.Format = "N2";
                    if (dgvProducts.Columns.Contains("Сумма"))
                        dgvProducts.Columns["Сумма"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new ProductForm().ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ID"].Value);
            new ProductForm(id).ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ID"].Value);
            string name = dgvProducts.CurrentRow.Cells["Наименование"].Value.ToString();

            if (MessageBox.Show($"Удалить товар '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadData();
                    MessageBox.Show("Товар удален");
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvProducts.DataSource;
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $"Наименование LIKE '%{txtSearch.Text}%'";
                }
            }
            catch { }
        }

        // ПРИХОД ТОВАРА
        private void приходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ID"].Value);
            string name = dgvProducts.CurrentRow.Cells["Наименование"].Value.ToString();
            int currentQty = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Количество"].Value);

            string qtyStr = Microsoft.VisualBasic.Interaction.InputBox($"Сколько товара '{name}' поступило? (Текущий остаток: {currentQty})", "Приход товара", "");

            if (int.TryParse(qtyStr, out int qty) && qty > 0)
            {
                try
                {
                    string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        int newQty = currentQty + qty;

                        SqlCommand cmdUpdate = new SqlCommand("UPDATE Products SET Quantity = @qty WHERE ProductID = @id", conn);
                        cmdUpdate.Parameters.AddWithValue("@qty", newQty);
                        cmdUpdate.Parameters.AddWithValue("@id", id);
                        cmdUpdate.ExecuteNonQuery();

                        SqlCommand cmdLog = new SqlCommand("INSERT INTO Incoming (ProductID, Quantity, Date) VALUES (@id, @qty, GETDATE())", conn);
                        cmdLog.Parameters.AddWithValue("@id", id);
                        cmdLog.Parameters.AddWithValue("@qty", qty);
                        cmdLog.ExecuteNonQuery();
                    }
                    LoadData();
                    MessageBox.Show($"Приход оформлен. Новое количество: {currentQty + qty}");
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
            }
            else
            {
                MessageBox.Show("Введите корректное количество");
            }
        }

        // РАСХОД ТОВАРА
        private void расходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ID"].Value);
            string name = dgvProducts.CurrentRow.Cells["Наименование"].Value.ToString();
            int currentQty = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Количество"].Value);

            if (currentQty == 0)
            {
                MessageBox.Show("Товара нет на складе!");
                return;
            }

            string qtyStr = Microsoft.VisualBasic.Interaction.InputBox($"Сколько товара '{name}' отгрузить? (Доступно: {currentQty})", "Расход товара", "");

            if (int.TryParse(qtyStr, out int qty) && qty > 0 && qty <= currentQty)
            {
                try
                {
                    string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        int newQty = currentQty - qty;

                        SqlCommand cmdUpdate = new SqlCommand("UPDATE Products SET Quantity = @qty WHERE ProductID = @id", conn);
                        cmdUpdate.Parameters.AddWithValue("@qty", newQty);
                        cmdUpdate.Parameters.AddWithValue("@id", id);
                        cmdUpdate.ExecuteNonQuery();

                        SqlCommand cmdLog = new SqlCommand("INSERT INTO Outgoing (ProductID, Quantity, Date) VALUES (@id, @qty, GETDATE())", conn);
                        cmdLog.Parameters.AddWithValue("@id", id);
                        cmdLog.Parameters.AddWithValue("@qty", qty);
                        cmdLog.ExecuteNonQuery();
                    }
                    LoadData();
                    MessageBox.Show($"Расход оформлен. Осталось: {currentQty - qty}");
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
            }
            else
            {
                MessageBox.Show($"Введите корректное количество (1-{currentQty})");
            }
        }

        // МЕНЮ
        private void товарыToolStripMenuItem_Click(object sender, EventArgs e) => LoadData();

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SuppliersForm().ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CustomersForm().ShowDialog();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CategoriesForm().ShowDialog();
        }

        // ОТЧЕТ - НОВАЯ ФОРМА С ТАБЛИЦЕЙ
        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Данные уже загружаются в конструкторе
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}