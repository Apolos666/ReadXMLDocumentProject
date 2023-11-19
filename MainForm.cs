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
using Newtonsoft.Json;

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
        

        private void GenerateJSON_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string jsonFilePath = GenerateJsonFilePath(filePath);

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePath);

                    string jsonString = ConvertXmlToJson(doc);
                    System.IO.File.WriteAllText(jsonFilePath, jsonString);

                    MessageBox.Show("JSON file generated successfully and saved at:\n" + jsonFilePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filePath = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an XML file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private string GenerateJsonFilePath(string xmlFilePath)
        {
            string jsonFileName = System.IO.Path.GetFileNameWithoutExtension(xmlFilePath) + ".json";
            string jsonFilePath = System.IO.Path.Combine("C:\\Đại Học\\THXML\\Bài tập cuối kì\\ReadXMLDocumentProject\\JSON Files\\", jsonFileName);
            return jsonFilePath;
        }

        private string ConvertXmlToJson(XmlDocument doc)
        {
            string json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        private void AddToDatabaseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    string connectionString = "Data Source=LAPTOP-F79T3I7P;Initial Catalog=dbReadXMLDocument;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
          
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePath);
                       
                        foreach (XmlNode node in doc.SelectNodes("/DanhSachSinhVien/SinhVien"))
                        {
                            int maSV = int.Parse(node.SelectSingleNode("MaSV").InnerText);
                            string hoTen = node.SelectSingleNode("HoTen").InnerText;
                            DateTime ngaySinh = DateTime.Parse(node.SelectSingleNode("NgaySinh").InnerText);
                            string khoa = node.SelectSingleNode("Khoa").InnerText;
                           
                            string insertQuery = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, Khoa) VALUES (@MaSV, @HoTen, @NgaySinh, @Khoa)";
                            using (SqlCommand command = new SqlCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@MaSV", maSV);
                                command.Parameters.AddWithValue("@HoTen", hoTen);
                                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                command.Parameters.AddWithValue("@Khoa", khoa);

                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Data added to the database successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an XML file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

