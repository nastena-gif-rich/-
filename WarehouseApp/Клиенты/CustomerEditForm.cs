using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WarehouseApp
{
    public partial class CustomerEditForm : Form
    {
        private int? editId = null;

        public CustomerEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление клиента";
        }

        public CustomerEditForm(int id, string name, string contact, string phone, string email, string address) : this()
        {
            editId = id;
            this.Text = "Редактирование клиента";
            txtName.Text = name;
            txtContact.Text = contact;
            txtPhone.Text = phone;
            txtEmail.Text = email;
            txtAddress.Text = address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название клиента");
                return;
            }

            try
            {
                string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (editId.HasValue)
                    {
                        cmd = new SqlCommand(@"UPDATE Customers SET 
                            CustomerName = @name, 
                            ContactPerson = @contact, 
                            Phone = @phone, 
                            Email = @email, 
                            Address = @address 
                            WHERE CustomerID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", editId.Value);
                    }
                    else
                    {
                        cmd = new SqlCommand(@"INSERT INTO Customers 
                            (CustomerName, ContactPerson, Phone, Email, Address) 
                            VALUES (@name, @contact, @phone, @email, @address)", conn);
                    }

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(editId.HasValue ? "Клиент обновлен" : "Клиент добавлен");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}