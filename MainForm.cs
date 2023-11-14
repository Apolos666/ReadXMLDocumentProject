using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            string filePath = OpenFileDialog();
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
                  
        }
    }
}
