using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WarehouseApp
{
    public partial class ProductForm : Form
    {
        private int? editId = null;

        public ProductForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            this.Text = "Добавление товара";
        }

        public ProductForm(int id) : this()
        {
            editId = id;
            this.Text = "Редактирование товара";
            LoadProductData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Категории
                    SqlDataAdapter daCat = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories", conn);
                    DataTable dtCat = new DataTable();
                    daCat.Fill(dtCat);
                    cmbCategory.DataSource = dtCat;
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "CategoryID";

                    // Поставщики
                    SqlDataAdapter daSup = new SqlDataAdapter("SELECT SupplierID, SupplierName FROM Suppliers", conn);
                    DataTable dtSup = new DataTable();
                    daSup.Fill(dtSup);
                    cmbSupplier.DataSource = dtSup;
                    cmbSupplier.DisplayMember = "SupplierName";
                    cmbSupplier.ValueMember = "SupplierID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void LoadProductData()
        {
            if (editId.HasValue)
            {
                try
                {
                    string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", editId.Value);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtName.Text = reader["ProductName"].ToString();
                            cmbCategory.SelectedValue = reader["CategoryID"];
                            cmbSupplier.SelectedValue = reader["SupplierID"];
                            txtQuantity.Text = reader["Quantity"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Введите цену");
                return;
            }

            int quantity = 0;
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
                int.TryParse(txtQuantity.Text, out quantity);

            try
            {
                string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (editId.HasValue)
                    {
                        cmd = new SqlCommand(@"UPDATE Products SET 
                            ProductName = @name, 
                            CategoryID = @cat, 
                            SupplierID = @sup, 
                            Quantity = @qty, 
                            Price = @price, 
                            Description = @desc 
                            WHERE ProductID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", editId.Value);
                    }
                    else
                    {
                        cmd = new SqlCommand(@"INSERT INTO Products 
                            (ProductName, CategoryID, SupplierID, Quantity, Price, Description) 
                            VALUES (@name, @cat, @sup, @qty, @price, @desc)", conn);
                    }

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@cat", cmbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@sup", cmbSupplier.SelectedValue);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(editId.HasValue ? "Товар обновлен" : "Товар добавлен");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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