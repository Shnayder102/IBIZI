using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using aes256 = IS_LAB3.AES_256;

namespace IS_LAB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        

        private void ButtonEncrypt_Clicked(object sender, EventArgs e)
        {
            string text = this.InputText.Text;
            string key = this.KeyTextBox.Text;

            List<byte> cipher = encrypt(text, key);

            this.OutputText.Text = BitConverter.ToString(cipher.ToArray())
                                   .Replace("-", " ");
        }

        private void ButtonDecrypt_Clicked(object sender, EventArgs e)
        {
            string input = this.InputText.Text;
            List<byte> cipher = cipher = input.Split(' ')
                                              .Select(num => Convert.ToByte(num, 16))
                                              .ToList();

            string key = this.KeyTextBox.Text;

            List<byte> decrypted = decrypt(cipher, key);
            this.OutputText.Text = Encoding.ASCII.GetString(decrypted.ToArray());
        }

        private void ButtonSwap_Clicked(object sender, EventArgs e)
        {
            string temp = this.InputText.Text;
            this.InputText.Text = this.OutputText.Text;
            this.OutputText.Text = temp;
        }

        public static List<byte> encrypt(string text, string key)
        {
            List<byte> text_bytes = Encoding.ASCII.GetBytes(text).ToList();

            List<byte> crypted_data = new List<byte>();
            List<byte> crypted_part = new List<byte>();

            List<byte> temp = new List<byte>();
            foreach (byte b in text_bytes)
            {
                temp.Add(b);
                if (temp.Count == 16)
                {
                    crypted_part = aes256.encrypt(temp, key);
                    crypted_data.AddRange(crypted_part);
                    temp.Clear();
                }
            }

            int count = temp.Count();
            if (count > 0 && count < 16)
            {
                int empty_spaces = 16 - count;

                for (int i = 0; i < empty_spaces - 1; i++)
                {
                    temp.Add(0x00);
                }
                temp.Add(0x03);

                crypted_part = aes256.encrypt(temp, key);
                crypted_data.AddRange(crypted_part);
            }

            return crypted_data;
        }

        public static List<byte> decrypt(List<byte> crypted_data, string key)
        {
            List<byte> temp = new List<byte>();
            List<byte> decrypted_part = new List<byte>();
            List<byte> decrypted_data = new List<byte>();

            foreach (byte b in crypted_data)
            {
                temp.Add(b);
                if (temp.Count == 16)
                {
                    decrypted_part = aes256.decrypt(temp, key);
                    decrypted_data.AddRange(decrypted_part);
                    temp.Clear();
                }

            }

            int count = temp.Count();
            if (count > 0 && count < 16)
            {
                int empty_spaces = 16 - count;

                for (int i = 0; i < empty_spaces - 1; i++)
                {
                    temp.Add(0x00);
                }
                temp.Add(0x03);

                decrypted_part = aes256.decrypt(temp, key);
                decrypted_data.AddRange(decrypted_part);
            }

            return decrypted_data;
        }

        private void InputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
