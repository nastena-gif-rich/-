using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
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
                            SupplierID AS [ID], 
                            SupplierName AS [Поставщик], 
                            ISNULL(ContactPerson, '') AS [Контактное лицо], 
                            ISNULL(Phone, '') AS [Телефон], 
                            ISNULL(Email, '') AS [Email], 
                            ISNULL(Address, '') AS [Адрес] 
                        FROM Suppliers", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSuppliers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierEditForm editForm = new SupplierEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow == null)
            {
                MessageBox.Show("Выберите поставщика");
                return;
            }

            int id = Convert.ToInt32(dgvSuppliers.CurrentRow.Cells["ID"].Value);
            string name = dgvSuppliers.CurrentRow.Cells["Поставщик"].Value.ToString();
            string contact = dgvSuppliers.CurrentRow.Cells["Контактное лицо"].Value.ToString();
            string phone = dgvSuppliers.CurrentRow.Cells["Телефон"].Value.ToString();
            string email = dgvSuppliers.CurrentRow.Cells["Email"].Value.ToString();
            string address = dgvSuppliers.CurrentRow.Cells["Адрес"].Value.ToString();

            SupplierEditForm editForm = new SupplierEditForm(id, name, contact, phone, email, address);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow == null)
            {
                MessageBox.Show("Выберите поставщика");
                return;
            }

            int id = Convert.ToInt32(dgvSuppliers.CurrentRow.Cells["ID"].Value);
            string name = dgvSuppliers.CurrentRow.Cells["Поставщик"].Value.ToString();

            if (MessageBox.Show($"Удалить поставщика '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Suppliers WHERE SupplierID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadData();
                    MessageBox.Show("Поставщик удален");
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
                DataTable dt = (DataTable)dgvSuppliers.DataSource;
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $"Поставщик LIKE '%{txtSearch.Text}%'";
                }
            }
            catch { }
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {

        }
    }
}