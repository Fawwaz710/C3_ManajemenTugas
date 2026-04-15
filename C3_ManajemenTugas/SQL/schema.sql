CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    nama NVARCHAR(150) NOT NULL,
    email NVARCHAR(150) UNIQUE,
    role NVARCHAR(20) NOT NULL
);

CREATE TABLE tugas (
    id_tugas INT IDENTITY(1,1) PRIMARY KEY,
    judul NVARCHAR(200) NOT NULL,
    deskripsi NVARCHAR(MAX),
    deadline DATETIME,
    dosen_id INT,
    FOREIGN KEY (dosen_id) REFERENCES users(user_id)
);

CREATE TABLE pengumpulan (
    id_pengumpulan INT IDENTITY(1,1) PRIMARY KEY,
    tugas_id INT,
    mahasiswa_id INT,
    file_url NVARCHAR(255),
    waktu_submit DATETIME,
    nilai FLOAT,
    status NVARCHAR(50),

    FOREIGN KEY (tugas_id) REFERENCES tugas(id_tugas),
    FOREIGN KEY (mahasiswa_id) REFERENCES users(user_id)
);

INSERT INTO users (nama, email, role) 
VALUES 
('Dosen Matematika', 'math@kampus.ac.id', 'dosen'),
('Dosen Fisika', 'physics@kampus.ac.id', 'dosen'),
('Dosen Bahasa Inggris', 'english@kampus.ac.id', 'dosen');