using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string modsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "YerelModlar");
        private string gamePath = "";
        private string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");

        private Panel pnlLogin;
        private Panel pnlManager;
        private Button btnSelectPath;
        private Button btnOpenFolder;
        private Button btnInstall;
        private Button btnUninstall;
        private Button btnResetPath;
        private CheckedListBox chkModList;
        private TextBox txtGamePath;
        private Label lblTitle;
        private Label lblSelectInfo;

        public Form1()
        {
            InitializeComponent();

            this.Text = "RDR2 Gelişmiş Mod Manager";
            this.Size = new Size(500, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 30);

            if (!Directory.Exists(modsDir))
            {
                Directory.CreateDirectory(modsDir);
            }

            CreateInterface();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pnlLogin.Dock = DockStyle.Fill;
            pnlManager.Dock = DockStyle.Fill;
            CheckSavedPath();
        }

        private void CreateInterface()
        {
            // --- GİRİŞ EKRANI ---
            pnlLogin = new Panel();
            pnlLogin.BackColor = Color.FromArgb(35, 35, 35);
            this.Controls.Add(pnlLogin);

            lblSelectInfo = new Label();
            lblSelectInfo.Text = "Lütfen Red Dead Redemption 2 oyununun kurulu olduğu klasörü seçin.";
            lblSelectInfo.ForeColor = Color.White;
            lblSelectInfo.Font = new Font("Segoe UI", 11);
            lblSelectInfo.Size = new Size(400, 50);
            lblSelectInfo.Location = new Point(50, 150);
            lblSelectInfo.TextAlign = ContentAlignment.TopCenter;
            pnlLogin.Controls.Add(lblSelectInfo);

            btnSelectPath = new Button();
            btnSelectPath.Text = "RDR2 Ana Klasörünü Seç";
            btnSelectPath.Size = new Size(250, 50);
            btnSelectPath.Location = new Point(120, 220);
            btnSelectPath.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSelectPath.BackColor = Color.FromArgb(199, 44, 44);
            btnSelectPath.ForeColor = Color.White;
            btnSelectPath.FlatStyle = FlatStyle.Flat;
            btnSelectPath.TextAlign = ContentAlignment.MiddleCenter;
            btnSelectPath.Click += new EventHandler(SelectFolderClick);
            pnlLogin.Controls.Add(btnSelectPath);

            // --- YÖNETİM EKRANI ---
            pnlManager = new Panel();
            pnlManager.BackColor = Color.FromArgb(30, 30, 30);
            this.Controls.Add(pnlManager);

            lblTitle = new Label();
            lblTitle.Text = "Yüklenebilir Yerel Modlar";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(200, 25);
            pnlManager.Controls.Add(lblTitle);

            // Mod Listesi
            chkModList = new CheckedListBox();
            chkModList.Location = new Point(20, 45);
            chkModList.Size = new Size(445, 260);
            chkModList.BackColor = Color.FromArgb(45, 45, 45);
            chkModList.ForeColor = Color.White;
            chkModList.Font = new Font("Segoe UI", 11);
            chkModList.BorderStyle = BorderStyle.FixedSingle;
            chkModList.SelectedIndexChanged += new EventHandler(ModListSelectionChanged);
            pnlManager.Controls.Add(chkModList);

            // Dosya Dizinini Aç Butonu
            btnOpenFolder = new Button();
            btnOpenFolder.Text = "Dizini Aç";
            btnOpenFolder.Size = new Size(125, 45);
            btnOpenFolder.Location = new Point(20, 320);
            btnOpenFolder.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnOpenFolder.BackColor = Color.FromArgb(50, 50, 50);
            btnOpenFolder.ForeColor = Color.White;
            btnOpenFolder.FlatStyle = FlatStyle.Flat;
            btnOpenFolder.TextAlign = ContentAlignment.MiddleCenter;
            btnOpenFolder.Padding = new Padding(0);
            btnOpenFolder.Click += new EventHandler(OpenFolderClick);
            pnlManager.Controls.Add(btnOpenFolder);

            // YÜKLE BUTONU (Enable)
            btnInstall = new Button();
            btnInstall.Text = "Modu Yükle";
            btnInstall.Size = new Size(150, 45);
            btnInstall.Location = new Point(155, 320);
            btnInstall.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnInstall.BackColor = Color.DarkGreen;
            btnInstall.ForeColor = Color.White;
            btnInstall.FlatStyle = FlatStyle.Flat;
            btnInstall.TextAlign = ContentAlignment.MiddleCenter;
            btnInstall.Padding = new Padding(0);
            btnInstall.Click += new EventHandler(InstallClick);
            pnlManager.Controls.Add(btnInstall);

            // KALDIR BUTONU (Disable)
            btnUninstall = new Button();
            btnUninstall.Text = "Modu Kaldır";
            btnUninstall.Size = new Size(150, 45);
            btnUninstall.Location = new Point(315, 320);
            btnUninstall.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnUninstall.BackColor = Color.FromArgb(150, 40, 40);
            btnUninstall.ForeColor = Color.White;
            btnUninstall.FlatStyle = FlatStyle.Flat;
            btnUninstall.Enabled = false;
            btnUninstall.TextAlign = ContentAlignment.MiddleCenter;
            btnUninstall.Padding = new Padding(0);
            btnUninstall.Click += new EventHandler(UninstallClick);
            pnlManager.Controls.Add(btnUninstall);

            // Oyun Yolunu Sıfırla Butonu
            btnResetPath = new Button();
            btnResetPath.Text = "Oyun Yolunu Değiştir / Sıfırla";
            btnResetPath.Size = new Size(445, 30);
            btnResetPath.Location = new Point(20, 380);
            btnResetPath.Font = new Font("Segoe UI", 9);
            btnResetPath.BackColor = Color.FromArgb(80, 40, 40);
            btnResetPath.ForeColor = Color.White;
            btnResetPath.FlatStyle = FlatStyle.Flat;
            btnResetPath.TextAlign = ContentAlignment.MiddleCenter;
            btnResetPath.Click += new EventHandler(ResetPathClick);
            pnlManager.Controls.Add(btnResetPath);

            txtGamePath = new TextBox();
            txtGamePath.Location = new Point(20, 425);
            txtGamePath.Size = new Size(445, 25);
            txtGamePath.BackColor = Color.FromArgb(45, 45, 45);
            txtGamePath.ForeColor = Color.Gray;
            txtGamePath.ReadOnly = true;
            pnlManager.Controls.Add(txtGamePath);
        }

        private void CheckSavedPath()
        {
            if (File.Exists(configPath))
            {
                string savedPath = File.ReadAllText(configPath).Trim();
                if (Directory.Exists(savedPath) && File.Exists(Path.Combine(savedPath, "RDR2.exe")))
                {
                    gamePath = savedPath;
                    txtGamePath.Text = gamePath;
                    ShowManager();
                    return;
                }
            }
            ShowLogin();
        }

        private void ShowLogin()
        {
            pnlLogin.Visible = true;
            pnlManager.Visible = false;
        }

        private void ShowManager()
        {
            pnlLogin.Visible = false;
            pnlManager.Visible = true;
            LoadMods();
            UpdateButtonStates();
        }

        private void ModListSelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            if (chkModList.SelectedItem == null)
            {
                btnInstall.Enabled = false;
                btnUninstall.Enabled = false;
                return;
            }

            string selectedMod = chkModList.SelectedItem.ToString();
            string indicatorFile = Path.Combine(gamePath, selectedMod + ".installed");

            if (File.Exists(indicatorFile))
            {
                btnInstall.Enabled = false;
                btnUninstall.Enabled = true;
                btnInstall.BackColor = Color.Gray;
                btnUninstall.BackColor = Color.FromArgb(199, 44, 44);
            }
            else
            {
                btnInstall.Enabled = true;
                btnUninstall.Enabled = false;
                btnInstall.BackColor = Color.DarkGreen;
                btnUninstall.BackColor = Color.Gray;
            }
        }

        private void SelectFolderClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "RDR2.exe dosyasının bulunduğu ana klasörü seçin";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.SelectedPath;
                    if (File.Exists(Path.Combine(path, "RDR2.exe")))
                    {
                        gamePath = path;
                        txtGamePath.Text = gamePath;
                        File.WriteAllText(configPath, gamePath);
                        ShowManager();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen klasörde RDR2.exe bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OpenFolderClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gamePath) && Directory.Exists(gamePath))
            {
                Process.Start("explorer.exe", gamePath);
            }
        }

        private void ResetPathClick(object sender, EventArgs e)
        {
            if (File.Exists(configPath))
            {
                File.Delete(configPath);
            }
            gamePath = "";
            txtGamePath.Text = "";
            ShowLogin();
        }

        private void InstallClick(object sender, EventArgs e)
        {
            if (chkModList.SelectedItem == null) return;

            string modName = chkModList.SelectedItem.ToString();
            string source = Path.Combine(modsDir, modName);
            string indicatorFile = Path.Combine(gamePath, modName + ".installed");

            try
            {
                CopyFiles(source, gamePath);
                File.WriteAllText(indicatorFile, "installed_at: " + DateTime.Now.ToString());

                MessageBox.Show(modName + " başarıyla yüklendi ve aktif edildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yükleme hatası: " + ex.Message);
            }
        }

        private void UninstallClick(object sender, EventArgs e)
        {
            if (chkModList.SelectedItem == null) return;

            string modName = chkModList.SelectedItem.ToString();
            string source = Path.Combine(modsDir, modName);
            string indicatorFile = Path.Combine(gamePath, modName + ".installed");

            try
            {
                DeleteCopiedFiles(source, gamePath);

                if (File.Exists(indicatorFile))
                {
                    File.Delete(indicatorFile);
                }

                MessageBox.Show(modName + " oyundan tamamen temizlendi (Disabled)!", "Kaldırıldı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaldırma hatası: " + ex.Message);
            }
        }

        private void LoadMods()
        {
            chkModList.Items.Clear();
            if (Directory.Exists(modsDir))
            {
                string[] dirs = Directory.GetDirectories(modsDir);
                for (int i = 0; i < dirs.Length; i++)
                {
                    chkModList.Items.Add(Path.GetFileName(dirs[i]));
                }
            }
        }

        private static void CopyFiles(string src, string dest)
        {
            string[] dirs = Directory.GetDirectories(src, "*", SearchOption.AllDirectories);
            for (int i = 0; i < dirs.Length; i++)
            {
                Directory.CreateDirectory(dirs[i].Replace(src, dest));
            }

            string[] files = Directory.GetFiles(src, "*.*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                File.Copy(files[i], files[i].Replace(src, dest), true);
            }
        }

        private static void DeleteCopiedFiles(string src, string dest)
        {
            string[] files = Directory.GetFiles(src, "*.*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                string targetFile = files[i].Replace(src, dest);
                if (File.Exists(targetFile))
                {
                    File.Delete(targetFile);
                }
            }

            string[] dirs = Directory.GetDirectories(src, "*", SearchOption.AllDirectories);
            for (int i = dirs.Length - 1; i >= 0; i--)
            {
                string targetDir = dirs[i].Replace(src, dest);
                if (Directory.Exists(targetDir) && Directory.GetFiles(targetDir).Length == 0 && Directory.GetDirectories(targetDir).Length == 0)
                {
                    Directory.Delete(targetDir);
                }
            }
        }
    }
}