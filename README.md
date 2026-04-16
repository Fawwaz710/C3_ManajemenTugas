# Sistem Manajemen Tugas Mahasiswa - UCP 1 PABD

Aplikasi manajemen tugas berbasis desktop yang dibangun menggunakan **C# Windows Forms** dan **SQL Server**. Proyek ini dibuat untuk memenuhi penugasan UCP 1 mata kuliah Pengembangan Aplikasi Basis Data.

## 🚀 Fitur Aplikasi
- **Koneksi Database**: Cek status koneksi saat aplikasi dimulai.
- **Manajemen Tugas (CRUD)**: Tambah, Lihat, Ubah, dan Hapus data tugas.
- **Pencarian**: Mencari tugas berdasarkan judul.
- **Statistik**: Menampilkan total tugas yang tersedia (ExecuteScalar).
- **Relasi Dosen**: Memilih dosen pengampu melalui ComboBox dinamis.

## 📸 Screenshot Aplikasi

### 1. Form Koneksi Database
![Koneksi Berhasil]<img width="1741" height="519" alt="{A1CCA279-BE7E-4135-9E89-AC4C61875A9D}" src="https://github.com/user-attachments/assets/03dd84a2-5a43-495c-ad9c-b6e0afdb9249" />


### 2. Form Input & Tampilan Data (DataGridView)
![Tampilan Utama] <img width="871" height="610" alt="{96A6E5D2-0491-4929-89A0-5A6728319DA3}" src="https://github.com/user-attachments/assets/5dfbba22-9e73-4abd-aba8-94a470befa9b" />


### 3. Bukti Operasi CRUD (Insert, Update, Delete)
![Bukti CRUD]
<img width="884" height="616" alt="{115A9445-7087-4F53-824F-0A9DDAD194BD}" src="https://github.com/user-attachments/assets/17cdbbe9-deb4-47a0-9dbb-2167586f437f" />
<img width="869" height="613" alt="{2A41C61F-1485-42B7-A596-D50D64824BB8}" src="https://github.com/user-attachments/assets/05ef83bb-bc53-471a-b188-5069dd2fded7" />
<img width="961" height="608" alt="{ABD0A480-5727-44A5-864A-40B812887ABC}" src="https://github.com/user-attachments/assets/ad8f75b8-2b65-4549-b483-102c5ff5f2dd" />
<img width="884" height="626" alt="{B4C15E02-5197-443B-A32D-F9808F2D6FAE}" src="https://github.com/user-attachments/assets/80d356e8-5108-4879-8dae-de956c1fb6cc" />


### 4. Fitur Pencarian (Search)
![Fitur Cari]<img width="851" height="222" alt="{3BEE36BA-8175-4B20-9D9B-2A4952BC5C0E}" src="https://github.com/user-attachments/assets/0545c754-5698-40cc-9c90-3252ce66d0ef" />


## 🛠️ Teknologi yang Digunakan
- **Bahasa**: C#
- **Framework**: .NET Framework (Windows Forms)
- **Database**: Microsoft SQL Server
- **Library**: ADO.NET (System.Data.SqlClient)

## 📝 Cara Instalasi
1. Clone repository ini.
2. Jalankan script SQL di folder `/SQL/schema.sql` pada SQL Server Anda.
3. Buka file `.sln` di Visual Studio.
4. Sesuaikan `connectionString` di file `Koneksi.cs`.
5. Tekan F5 untuk menjalankan.
