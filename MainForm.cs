using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ReadXMLDocumentProject
{
    public partial class MainForm : Form
    {
        private string filePath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            DataListBox.Items.Clear();
            filePath = OpenFileDialog();
            if (filePath != "")
            {
                ParseXmlFile(filePath, DataListBox);
            }
        }

        private string OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return "";
        }

        private void ParseXmlFile(string filePath, ListBox listbox)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            DeQuyAddNodes(doc.DocumentElement, listbox, 0);
        }

        private void DeQuyAddNodes(XmlNode node, ListBox listbox, int level)
        {
            string nodeInfo = new String(' ', level * 2);

            if (node.NodeType == XmlNodeType.Element)
            {
                nodeInfo += node.Name;

                if (node.FirstChild != null && node.FirstChild.NodeType == XmlNodeType.Text)
                {
                    nodeInfo += ": " + node.FirstChild.Value;
                    listbox.Items.Add(nodeInfo);
                }
                else
                {
                    listbox.Items.Add(nodeInfo);
                }

                if (node.Attributes != null)
                {
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        string attributeInfo = new String(' ', (level + 1) * 2) + attr.Name + ": " + attr.Value;
                        listbox.Items.Add(attributeInfo);
                    }
                }
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                DeQuyAddNodes(childNode, listbox, level + 1);
            }
        }

        private void AddToDatabaseBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                // Thực hiện đọc và thêm dữ liệu vào cơ sở dữ liệu
                try
                {
                    string connectionString = "Data Source=LAPTOP-F79T3I7P;Initial Catalog=dbReadXMLDocument;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Thực hiện tạo bảng và thêm dữ liệu
                        CreateTableAndInsertData(connection, filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void CreateTableAndInsertData(SqlConnection connection, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // Lấy tên bảng từ tên root node trong XML
            string tableName = doc.DocumentElement.Name;

            // Tạo bảng nếu chưa tồn tại
            string createTableQuery = $"IF OBJECT_ID('{tableName}', 'U') IS NULL CREATE TABLE {tableName} (ID INT IDENTITY(1,1) PRIMARY KEY);";
            using (SqlCommand cmd = new SqlCommand(createTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Thêm cột và dữ liệu từ XML vào bảng
            AddNodesToTable(doc.DocumentElement, connection, tableName, 0);
        }

        private void AddNodesToTable(XmlNode node, SqlConnection connection, string tableName, int level)
        {
            // Implement logic để thêm cột và dữ liệu vào bảng
            // Dựa vào tên node và giá trị của nó

            // Lưu ý: Bạn cần xử lý loại dữ liệu của cột (ví dụ: varchar, int, ...) dựa trên giá trị của node
            // Ở đây tôi giả sử mọi giá trị đều là varchar(255)

            string columnName = node.Name;
            string columnValue = (node.FirstChild != null && node.FirstChild.NodeType == XmlNodeType.Text) ? node.FirstChild.Value : "";

            string insertQuery = $"INSERT INTO {tableName} ({columnName}) VALUES ('{columnValue}');";
            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                AddNodesToTable(childNode, connection, tableName, level + 1);
            }
        }
    }
}
