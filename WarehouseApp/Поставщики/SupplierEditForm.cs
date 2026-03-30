using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WarehouseApp
{
    public partial class SupplierEditForm : Form
    {
        private int? editId = null;

        public SupplierEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление поставщика";
        }

        public SupplierEditForm(int id, string name, string contact, string phone, string email, string address) : this()
        {
            editId = id;
            this.Text = "Редактирование поставщика";
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
                MessageBox.Show("Введите название поставщика");
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
                        cmd = new SqlCommand(@"UPDATE Suppliers SET 
                            SupplierName = @name, 
                            ContactPerson = @contact, 
                            Phone = @phone, 
                            Email = @email, 
                            Address = @address 
                            WHERE SupplierID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", editId.Value);
                    }
                    else
                    {
                        cmd = new SqlCommand(@"INSERT INTO Suppliers 
                            (SupplierName, ContactPerson, Phone, Email, Address) 
                            VALUES (@name, @contact, @phone, @email, @address)", conn);
                    }

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(editId.HasValue ? "Поставщик обновлен" : "Поставщик добавлен");
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