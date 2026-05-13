ALTER TABLE users ADD password NVARCHAR(50) DEFAULT '123456';
-- Set password awal untuk data yang sudah ada
UPDATE users SET password = 'admin123' WHERE role = 'dosen';
UPDATE users SET password = 'user123' WHERE role = 'mahasiswa';
