# Red Dead Redemption 2 Mod Manager

Red Dead Redemption 2 (RDR2) için C# / Windows Forms ile geliştirilmiş sade, hızlı ve kullanışlı bir yerel mod yöneticisi.

---

## 🚀 Özellikler

- **Kolay Kurulum:** Tek tıkla RDR2 ana dizinini (`RDR2.exe`) seçip yapılandırma.
- **Yerel Mod Yönetimi:** `YerelModlar` klasörüne atılan modları otomatik olarak algılar ve listeler.
- **Tek Tıkla Mod Yükleme:** Mod dosyalarını oyun dizinine kopyalar ve durumunu takip eder.
- **Temiz Mod Kaldırma:** Yüklenen modları oyun dizininden otomatik tespit edip tamamen kaldırır ve artık dosyaları temizler.
- **Dizin Kısayolu:** Oyunun ana klasörünü tek tuşla dosya gezgininde açabilme.
- **Yol Sıfırlama:** Yanlış oyun yolu seçildiğinde kolayca sıfırlayabilme imkanı.

---

## 🛠️ Kurulum ve Derleme

### Gereksinimler
- **Windows İşletim Sistemi**
- **.NET Framework 4.7.2** veya üzeri
- **Visual Studio 2019 / 2022** (.NET masaüstü geliştirme paketi ile)

### Projeyi Çalıştırma
1. Bu depoyu klonlayın veya indirin:
   ```bash
   git clone https://github.com/devilteams-s/RDR2-Mod-Manager.git
   ```
2. `Red Dead Redemption Mod Manager.slnx` çözüm dosyasını Visual Studio ile açın.
3. Projeyi derleyin (`Build` -> `Build Solution` veya `F5` tuşu).

---

## 📖 Kullanım

1. Uygulamayı başlattığınızda **RDR2 Ana Klasörünü Seç** butonuna tıklayarak `RDR2.exe` dosyasının bulunduğu ana oyun klasörünü gösterin.
2. Uygulama dizininde otomatik açılan `YerelModlar` klasörüne yüklemek istediğiniz modları klasör halinde atın:
   ```
   YerelModlar/
   ├── RampageTrainer/
   │   ├── Rampage.asi
   │   └── ...
   └── DigerMod/
       └── ...
   ```
3. Listeden istediğiniz modu seçip **Modu Yükle** butonuna basın.
4. Kaldırmak istediğinizde modu seçip **Modu Kaldır** demeniz yeterlidir.

---

## 📄 Lisans
Bu proje açık kaynaklıdır ve MIT lisansı altında dağıtılmaktadır.
