# Red Dead Redemption 2 Mod Manager

<p align="center">
  <img src="https://img.shields.io/github/v/release/devilteams-s/RDR2-Mod-Manager?style=for-the-badge&color=c72c2c" alt="Latest Release">
  <img src="https://img.shields.io/github/downloads/devilteams-s/RDR2-Mod-Manager/total?style=for-the-badge&color=28a745" alt="Downloads">
  <img src="https://img.shields.io/github/license/devilteams-s/RDR2-Mod-Manager?style=for-the-badge" alt="License">
</p>

Red Dead Redemption 2 (RDR2) için C# / Windows Forms ile geliştirilmiş; sade, hızlı ve güvenli bir yerel mod yöneticisidir. Oyun dosyalarınızı bozmadan tek tıkla mod yükleyip kaldırmanızı sağlar.

---

## 📥 İndir (Hazır Sürüm)

Projeyi derlemekle uğraşmak istemiyorsanız, doğrudan çalıştırılabilir `.exe` dosyasını Releases sayfamızdan indirebilirsiniz:

👉 **[En Son Sürümü İndir (Releases)](https://github.com/devilteams-s/RDR2-Mod-Manager/releases/latest)**

---

## 🚀 Özellikler

- **⚡ Tek Tıkla Kurulum & Kaldırma:** Mod dosyalarını oyun dizinine otomatik aktarır; kaldırıldığında artık dosya bırakmadan temizler.
- **📁 Otomatik Dizin Tespiti:** Oyunun kurulu olduğu klasörü bir kez seçmeniz yeterlidir; ayarlarınız otomatik kaydedilir.
- **📦 Yerel Mod Kütüphanesi:** Uygulama klasöründeki `YerelModlar` klasörüne eklediğiniz tüm modları otomatik tanır ve listeler.
- **🛡️ Temiz Mod Kaldırma:** Yüklü modu kaldırdığınızda oyunun orijinal dosyalarına dokunmadan yalnızca mod dosyalarını temizler.
- **📂 Hızlı Dizin Erişimi:** Tek tıkla RDR2 ana oyun klasörünü dosya gezgininde açar.
- **🔄 Yol Değiştirme:** Yanlış dizin seçildiğinde tek tıkla oyun yolunu sıfırlama seçeneği.

---

## 📖 Kullanım Rehberi

1. **[Releases](https://github.com/devilteams-s/RDR2-Mod-Manager/releases/latest)** sayfasından `.exe` dosyasını indirin ve istediğiniz bir klasöre koyun.
2. Programı çalıştırın ve ilk açılışta `RDR2.exe` dosyasının bulunduğu ana oyun klasörünü seçin.
3. Programın yanında otomatik oluşan `YerelModlar` klasörüne yüklemek istediğiniz modları klasör halinde yerleştirin:
   ```
   YerelModlar/
   ├── RampageTrainer/
   │   ├── Rampage.asi
   │   └── RampageFiles/
   └── DigerMod/
       └── ...
   ```
4. Programı açın, listeden kurmak istediğiniz modu seçip **Modu Yükle** butonuna tıklayın.
5. Modu devre dışı bırakmak istediğinizde modu seçip **Modu Kaldır** demeniz yeterlidir.

---

## 🛠️ Kaynak Koddan Derleme (Geliştiriciler İçin)

Eğer projeyi kendiniz derlemek veya katkıda bulunmak isterseniz:

### Gereksinimler
- **Windows 10 / 11**
- **.NET Framework 4.7.2** veya üzeri
- **Visual Studio 2019 / 2022** (.NET Masaüstü Geliştirme iş yükü ile)

### Adımlar
```bash
git clone https://github.com/devilteams-s/RDR2-Mod-Manager.git
```
1. `Red Dead Redemption Mod Manager.slnx` dosyasını Visual Studio ile açın.
2. `Build` > `Build Solution` (veya `F5`) ile derleyin ve çalıştırın.

---

## 📄 Lisans
Bu proje açık kaynaklıdır ve MIT lisansı altında sunulmaktadır.
