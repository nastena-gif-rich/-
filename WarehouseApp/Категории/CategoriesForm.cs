using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
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
                    SqlDataAdapter da = new SqlDataAdapter(@"
                        SELECT 
                            CategoryID AS [ID], 
                            CategoryName AS [Категория], 
                            ISNULL(Description, '') AS [Описание] 
                        FROM Categories", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCategories.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryEditForm editForm = new CategoryEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }

            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            string name = dgvCategories.CurrentRow.Cells["Категория"].Value.ToString();
            string description = dgvCategories.CurrentRow.Cells["Описание"].Value.ToString();

            CategoryEditForm editForm = new CategoryEditForm(id, name, description);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }

            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["ID"].Value);
            string name = dgvCategories.CurrentRow.Cells["Категория"].Value.ToString();

            if (MessageBox.Show($"Удалить категорию '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadData();
                    MessageBox.Show("Категория удалена");
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvCategories.DataSource;
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $"Категория LIKE '%{txtSearch.Text}%'";
                }
            }
            catch { }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}