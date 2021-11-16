using ClipboardHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// Todo 서버/클라이언트 구현


namespace NetSynClip
{
    public partial class SelectSC : Form
    {
        public SelectSC()
        {
            InitializeComponent();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        
        int TypeTemp = 0;
        string TextTemp = "";
        Image ImgTemp = null;

        bool is_synced_change = false;

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void RadioButton(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = false;
            }
            else
                textBox1.Enabled = true;
        }

        private void ClipboardMonitor_OnClipboardChange(ClipboardFormat format, object data)
        {
            if (!is_synced_change)
            {
                if (Clipboard.ContainsText())
             
                {
                    string ClipTMP = Clipboard.GetText();
                    listBox1.Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add("Text : " + ClipTMP);
                    });
                    
                    TextTemp = ClipTMP;
                    TypeTemp = 1;

                }
                else if (Clipboard.ContainsImage())
                {
                    Image ClipTMP = Clipboard.GetImage();
                    listBox1.Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add("Image");
                    });
                    ImgTemp = (Image)ClipTMP;
                    TypeTemp = 2;
                }
            }
        }

        


        private void SelectSC_Load(object sender, EventArgs e)
        {
            ClipboardMonitor.OnClipboardChange += ClipboardMonitor_OnClipboardChange;
            ClipboardMonitor.Start();
        }
    }
}
