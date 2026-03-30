using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WarehouseApp
{
    public partial class CategoryEditForm : Form
    {
        private int? editId = null;

        public CategoryEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление категории";
        }

        public CategoryEditForm(int id, string name, string description) : this()
        {
            editId = id;
            this.Text = "Редактирование категории";
            txtName.Text = name;
            txtDescription.Text = description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название категории");
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
                        cmd = new SqlCommand("UPDATE Categories SET CategoryName = @name, Description = @desc WHERE CategoryID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", editId.Value);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO Categories (CategoryName, Description) VALUES (@name, @desc)", conn);
                    }

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@desc", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(editId.HasValue ? "Категория обновлена" : "Категория добавлена");
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