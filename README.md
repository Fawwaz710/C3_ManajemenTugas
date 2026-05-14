# 🎓 Sistem Manajemen Tugas Mahasiswa (LMS Mini) - Project UCP PABD

Aplikasi manajemen tugas (LMS Mini) berbasis desktop yang dibangun menggunakan **C# Windows Forms** dan **SQL Server**. Proyek ini mengimplementasikan arsitektur database tingkat lanjut dan fitur keamanan untuk memenuhi kriteria ujian Pengembangan Aplikasi Basis Data.

## 🌟 Fitur Utama & Kriteria Ujian

Aplikasi ini telah memenuhi standar teknis berikut:
- **Arsitektur Database Terpisah**: Menggunakan **VIEW** untuk operasi baca (Select) dan **Stored Procedures** untuk operasi tulis (Insert, Update, Delete, Search).
- **Advanced Data Binding**: Implementasi **Disconnected Architecture** menggunakan `BindingSource` dan `BindingNavigator` pada DataGridView.
- **Role-Based Authentication**: Sistem Login dengan dua peran berbeda (Dosen & Mahasiswa) dengan hak akses fitur yang disesuaikan.
- **Security (SQL Injection)**: Demonstrasi celah keamanan SQL Injection pada Form Login dan implementasi **Parameterized Query** sebagai solusinya.
- **Validasi Deadline**: Logika khusus untuk mencegah input tenggat waktu di masa lalu atau terlalu jauh di masa depan.
- **Data Recovery**: Fitur **Reset Data** menggunakan `IDENTITY_INSERT` untuk mengembalikan data sampel dari tabel backup.
- **Reporting**: Fitur cetak nilai mahasiswa dalam format laporan.

## 📸 Screenshot Aplikasi

### 1. Form Login & Registrasi
Halaman utama untuk autentikasi user dengan role Dosen atau Mahasiswa.
<img width="537" height="533" alt="{5288D05A-428F-49A8-8027-B0292D1D97F2}" src="https://github.com/user-attachments/assets/adc1183c-b9b3-4cbd-8c32-a8016be3b336" />
<img width="513" height="497" alt="{46472643-3107-4408-BB46-A6AF95EC66FB}" src="https://github.com/user-attachments/assets/354956bb-f49c-4440-8592-20ed3b3557ae" />


### 2. Dashboard Dosen (Manajemen & Monitoring)
Dosen dapat mengelola tugas menggunakan **Stored Procedures** dan memantau pengumpulan tugas mahasiswa melalui **VIEW**.
<img width="1282" height="605" alt="{1EDD5D91-F936-4463-822A-2A0AFDCCDABD}" src="https://github.com/user-attachments/assets/e389857d-6e41-4f15-88f4-a9c2853e4566" />
<img width="1283" height="595" alt="{ED171BB8-6550-4558-9383-F37D60F431C5}" src="https://github.com/user-attachments/assets/acbc89f0-2987-4d61-adaf-a757146345ed" />

<img width="1296" height="600" alt="{98DDACEB-007E-43A8-BAE2-DAC0B29CC523}" src="https://github.com/user-attachments/assets/47d94908-0024-4973-8791-aaeae76021dd" />


### 3. Fitur Data Binding & Navigator
Implementasi navigasi data otomatis sesuai standar modul praktikum.
<img width="1269" height="495" alt="{820F45E2-72D4-4D20-AE7A-48A0934C15C5}" src="https://github.com/user-attachments/assets/391a31cd-692d-4bef-a86a-cb888e2a79fd" />


### 4. Demonstrasi SQL Injection & Reset Data
Halaman pengujian keamanan untuk mensimulasikan serangan SQL Injection dan tombol Reset untuk pemulihan data instan.
<img width="1251" height="414" alt="{2F4593AB-825E-4DDA-90D8-F7D30CBEE487}" src="https://github.com/user-attachments/assets/c76e7cc6-94a9-4567-9919-60f49bced0c2" />
<img width="1281" height="587" alt="{B57BC2AD-D969-449D-A4AF-CE42A4AA25FC}" src="https://github.com/user-attachments/assets/d599c580-0b01-4037-a0b8-1738bbe2d2f6" />



## 🛡️ Skenario SQL Injection (Kriteria Ujian)
Proyek ini menyertakan simulasi serangan SQL Injection untuk tujuan edukasi:
1. **Bypass Login**: Masukkan `' OR '1'='1` pada kolom password untuk masuk tanpa akun valid.
2. **Data Manipulation**: Menggunakan tombol "Test Injection" untuk merubah semua judul tugas menjadi "HACKED" melalui celah *string concatenation*.
3. **Defense**: Solusi pencegahan menggunakan `SqlParameter` telah diterapkan pada seluruh fungsi CRUD utama.

## 🛠️ Teknologi & Arsitektur
- **Bahasa**: C# (.NET Framework)
- **Database**: Microsoft SQL Server
- **Metode Koneksi**: ADO.NET (SqlConnection, SqlDataAdapter, DataSet)
- **Objek Database**: 
  - `v_TugasLengkap`: View untuk relasi tabel tugas dan dosen.
  - `sp_InsertTugas`, `sp_UpdateTugas`, `sp_DeleteTugas`: Stored Procedures untuk integritas data.

## 📝 Cara Instalasi
1. Clone repository ini.
2. Buka SQL Server Management Studio, jalankan script di folder `/SQL/schema.sql`.
3. Pastikan tabel `tugas_Backup` telah dibuat untuk fitur Reset.
4. Buka file `.sln` di Visual Studio.
5. Sesuaikan *Connection String* pada file `Koneksi.cs` dengan Nama Server Anda.
6. Build dan Run (F5).

## 👤 Disusun Oleh
- **Nama**: [Nama Anda]
- **NIM**: [NIM Anda]
- **Mata Kuliah**: Pengembangan Aplikasi Basis Data
