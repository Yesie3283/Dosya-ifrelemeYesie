using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dosyasifreleme
{
    public partial class DSS : Form
    {
        public DSS()
        {
            InitializeComponent();

            SurukleAlanPanel.AllowDrop = true;
            SurukleAlanPanel.DragEnter += SurukleAlanPanel_DragEnter;
            SurukleAlanPanel.DragDrop += SurukleAlanPanel_DragDrop;
        }

        private void DSS_Load(object sender, EventArgs e)
        {
            sifre_mtb.PasswordChar = '*';
        }

        private void SifreGoster_btn_Click(object sender, EventArgs e)
        {
            if (sifre_mtb.PasswordChar == '*')
            {
                sifre_mtb.PasswordChar = '\0';
            }
            else
            {
                sifre_mtb.PasswordChar = '*';
            }
        }

        private void SurukleAlanPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private async void SurukleAlanPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] dosyalar = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (dosyalar == null || dosyalar.Length == 0)
            {
                MessageBox.Show("Lütfen bir dosya veya klasör sürükleyin.");
                return;
            }
            string secilendosya = dosyalar[0];
            string sifre = sifre_mtb.Text;

            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen önce bir şifre girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!chkAES.Checked && !chkTwofish.Checked && !chkTripleDES.Checked)
            {
                MessageBox.Show("Lütfen bir şifreleme algoritması seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Enabled = false;

            try
            {
                if (Directory.Exists(secilendosya))
                {
                    string[] iceridekiDosyalar = Directory.GetFiles(secilendosya, "*.*", SearchOption.AllDirectories);

                    foreach (string dosyaYolu in iceridekiDosyalar)
                    {
                        if (sifrele_rbtn.Checked && !dosyaYolu.EndsWith(".enc"))
                        {
                            string hedef = dosyaYolu + ".enc";
                            await IslemYapAsync(dosyaYolu, hedef, sifre, true);
                            File.Delete(dosyaYolu);
                        }
                        else if (coz_rbtn.Checked && dosyaYolu.EndsWith(".enc"))
                        {
                            string hedef = dosyaYolu.Substring(0, dosyaYolu.Length - 4);
                            await IslemYapAsync(dosyaYolu, hedef, sifre, false);
                            File.Delete(dosyaYolu);
                        }
                    }
                    MessageBox.Show("Klasör içindeki tüm dosyalar başarıyla işlendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (sifrele_rbtn.Checked)
                    {
                        string hedefDosya = secilendosya + ".enc";
                        await IslemYapAsync(secilendosya, hedefDosya, sifre, true);
                        File.Delete(secilendosya);
                        MessageBox.Show("Dosya başarıyla şifrelendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (coz_rbtn.Checked)
                    {
                        string hedefDosya = secilendosya.EndsWith(".enc")
                            ? secilendosya.Substring(0, secilendosya.Length - 4)
                            : secilendosya + "_cozuldu";
                        await IslemYapAsync(secilendosya, hedefDosya, sifre, false);
                        File.Delete(secilendosya);
                        MessageBox.Show("Dosya şifresi çözüldü!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Şifrele veya Çöz seçeneğini işaretleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private async Task IslemYapAsync(string kaynakPath, string hedefPath, string password, bool sifreleMi)
        {
            byte[] salt = Encoding.UTF8.GetBytes("Yesie3283Salt");
            using (var deriver = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] aesKey = deriver.GetBytes(32);
                byte[] aesIV = deriver.GetBytes(16);

                byte[] layerKey = deriver.GetBytes(32);
                byte[] layerIV = deriver.GetBytes(16);

                byte[] tdesKey = deriver.GetBytes(24);
                byte[] tdesIV = deriver.GetBytes(8);

                using (FileStream fsKaynak = new FileStream(kaynakPath, FileMode.Open, FileAccess.Read))
                using (FileStream fshedef = new FileStream(hedefPath, FileMode.Create, FileAccess.Write))
                {
                    Stream aktifStream = fshedef;

                    if (sifreleMi)
                    {
                        if (chkTripleDES.Checked)
                        {
                            TripleDES tdes = TripleDES.Create();
                            tdes.Key = tdesKey;
                            tdes.IV = tdesIV;
                            aktifStream = new CryptoStream(aktifStream, tdes.CreateEncryptor(), CryptoStreamMode.Write);
                        }
                        if (chkTwofish.Checked)
                        {
                            Aes aes2 = Aes.Create();
                            aes2.Key = layerKey;
                            aes2.IV = layerIV;
                            aktifStream = new CryptoStream(aktifStream, aes2.CreateEncryptor(), CryptoStreamMode.Write);
                        }
                        if (chkAES.Checked)
                        {
                            Aes aes1 = Aes.Create();
                            aes1.Key = aesKey;
                            aes1.IV = aesIV;
                            aktifStream = new CryptoStream(aktifStream, aes1.CreateEncryptor(), CryptoStreamMode.Write);
                        }

                        byte[] buffer = new byte[1048576];
                        int okunan;
                        while ((okunan = await fsKaynak.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await aktifStream.WriteAsync(buffer, 0, okunan);
                        }

                        if (aktifStream is CryptoStream cs)
                        {
                            cs.FlushFinalBlock();
                        }
                    }
                    else
                    {
                        Stream okumaStream = fsKaynak;
                        if (chkAES.Checked)
                        {
                            Aes aes1 = Aes.Create();
                            aes1.Key = aesKey;
                            aes1.IV = aesIV;
                            okumaStream = new CryptoStream(okumaStream, aes1.CreateDecryptor(), CryptoStreamMode.Read);
                        }
                        if (chkTwofish.Checked)
                        {
                            Aes aes2 = Aes.Create();
                            aes2.Key = layerKey;
                            aes2.IV = layerIV;
                            okumaStream = new CryptoStream(okumaStream, aes2.CreateDecryptor(), CryptoStreamMode.Read);
                        }
                        if (chkTripleDES.Checked)
                        {
                            TripleDES tdes = TripleDES.Create();
                            tdes.Key = tdesKey;
                            tdes.IV = tdesIV;
                            okumaStream = new CryptoStream(okumaStream, tdes.CreateDecryptor(), CryptoStreamMode.Read);
                        }

                        // Karışıklığı önlemek için buffer boyutunu şifreleme ile aynı yapalım (8192 veya 4096 daha güvenlidir)
                        byte[] buffer = new byte[1048576];
                        int okunan;
                        while ((okunan = await okumaStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fshedef.WriteAsync(buffer, 0, okunan);
                        }

                        // Okuma stream'lerini tamamen kapatıp veriyi diske gömelim
                        okumaStream.Close();
                    }
                }
                }
            }
        }
    }
