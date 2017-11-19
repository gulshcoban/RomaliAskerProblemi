using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomalıAskerÖdevi
{
    public partial class frmRomaliAskerOdevi : Form
    {
        public frmRomaliAskerOdevi()
        {
            InitializeComponent();
        }

        private void btnKalanAskerSayisi_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if ((c as TextBox).Text == "")
                    {
                        MessageBox.Show("Lütfen boş alanları doldurunuz...");
                        txtAdimSayisi.Focus();
                        break;
                    }
                    else
                    {
                        ulong askersayisi = Convert.ToUInt64(txtAskerSayisi.Text);
                        ulong adimsayisi = Convert.ToUInt64(txtAdimSayisi.Text);
                        RomaliAsker asker = new RomaliAsker(askersayisi);
                        MessageBox.Show(asker.CalismaZamani(askersayisi, adimsayisi));
                        break;
                    }
                }
            }
        }

        private void txtAskerSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAdimSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAskerSayisi_Leave(object sender, EventArgs e)
        {
            if (txtAskerSayisi.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz...");
                txtAskerSayisi.Focus();
            }
            else if (Convert.ToInt32(txtAskerSayisi.Text) <= 2)
            {
                MessageBox.Show("Lütfen 2'den büyük bir değer giriniz...");
                txtAskerSayisi.Text = "";
                txtAskerSayisi.Focus();
            }
        }

        private void txtAdimSayisi_Leave(object sender, EventArgs e)
        {
            if (txtAdimSayisi.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz...");
                txtAdimSayisi.Focus();
            }
            else if (Convert.ToUInt64(txtAdimSayisi.Text) == 0)
            {
                MessageBox.Show("Lütfen 0'dan büyük bir değer giriniz...");
                txtAdimSayisi.Text = "";
                txtAdimSayisi.Focus();
            }
        }
    }
}
