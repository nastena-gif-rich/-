using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
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
                            CustomerID AS [ID], 
                            CustomerName AS [Клиент], 
                            ISNULL(ContactPerson, '') AS [Контактное лицо], 
                            ISNULL(Phone, '') AS [Телефон], 
                            ISNULL(Email, '') AS [Email], 
                            ISNULL(Address, '') AS [Адрес] 
                        FROM Customers", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCustomers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerEditForm editForm = new CustomerEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            string name = dgvCustomers.CurrentRow.Cells["Клиент"].Value.ToString();
            string contact = dgvCustomers.CurrentRow.Cells["Контактное лицо"].Value.ToString();
            string phone = dgvCustomers.CurrentRow.Cells["Телефон"].Value.ToString();
            string email = dgvCustomers.CurrentRow.Cells["Email"].Value.ToString();
            string address = dgvCustomers.CurrentRow.Cells["Адрес"].Value.ToString();

            CustomerEditForm editForm = new CustomerEditForm(id, name, contact, phone, email, address);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["ID"].Value);
            string name = dgvCustomers.CurrentRow.Cells["Клиент"].Value.ToString();

            if (MessageBox.Show($"Удалить клиента '{name}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadData();
                    MessageBox.Show("Клиент удален");
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
                DataTable dt = (DataTable)dgvCustomers.DataSource;
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $"Клиент LIKE '%{txtSearch.Text}%'";
                }
            }
            catch { }
        }
    }
}