-- SISTEM MANAJEMEN VAKSIN POSYANDU
CREATE DATABASE SistemManajemenPosyandu;
GO

USE SistemManajemenPosyandu;
GO

-- PEMBUATAN TABEL
CREATE TABLE Users (
    id_user         INT PRIMARY KEY IDENTITY(1,1),
    nama_lengkap    VARCHAR(100) NOT NULL,
    username        VARCHAR(50)  NOT NULL UNIQUE,
    password        VARCHAR(255) NOT NULL,
    role            VARCHAR(20)  NOT NULL CHECK (role IN ('Bidan', 'Petugas', 'OrangTua'))
);
GO

CREATE TABLE Balita (
    id_balita       INT PRIMARY KEY IDENTITY(1,1),
    id_orang_tua    INT          NULL REFERENCES Users(id_user),
    nik             VARCHAR(16)  NOT NULL UNIQUE,
    nama_balita     VARCHAR(100) NOT NULL,
    tgl_lahir       DATE         NOT NULL,
    jenis_kelamin   CHAR(1)      NOT NULL CHECK (jenis_kelamin IN ('L', 'P')),
    nama_ortu       VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Vaksin (
    id_vaksin       INT PRIMARY KEY IDENTITY(1,1),
    nama_vaksin     VARCHAR(50)  NOT NULL,
    stok            INT          NOT NULL DEFAULT 0,
    deskripsi       TEXT         NULL,
    tgl_kedaluwarsa DATE         NOT NULL
);
GO

CREATE TABLE Jadwal_Posyandu (
    id_jadwal       INT PRIMARY KEY IDENTITY(1,1),
    tgl_pelaksanaan DATE         NOT NULL,
    lokasi          VARCHAR(100) NOT NULL,
    keterangan      VARCHAR(255) NULL
);
GO

CREATE TABLE Transaksi_Imunisasi (
    id_imunisasi    INT PRIMARY KEY IDENTITY(1,1),
    id_balita       INT          NOT NULL REFERENCES Balita(id_balita),
    id_vaksin       INT          NOT NULL REFERENCES Vaksin(id_vaksin),
    id_jadwal       INT          NOT NULL REFERENCES Jadwal_Posyandu(id_jadwal),
    id_petugas      INT          NOT NULL REFERENCES Users(id_user),
    no_antrean      VARCHAR(10)  NOT NULL,
    tgl_suntik      DATETIME     NOT NULL DEFAULT GETDATE(),
    status          VARCHAR(10)  NOT NULL DEFAULT 'Terdaftar' CHECK (status IN ('Terdaftar', 'Selesai', 'Batal'))
);
GO

CREATE TABLE Catatan_Pertumbuhan (
    id_pertumbuhan  INT PRIMARY KEY IDENTITY(1,1),
    id_balita       INT          NOT NULL REFERENCES Balita(id_balita),
    id_petugas      INT          NOT NULL REFERENCES Users(id_user),
    tgl_timbang     DATE         NOT NULL DEFAULT GETDATE(),
    berat_badan     DECIMAL(5,2) NOT NULL, 
    tinggi_badan    DECIMAL(5,2) NOT NULL, 
    lingkar_kepala  DECIMAL(5,2) NULL,     
    catatan_tambahan VARCHAR(255) NULL      
);
GO

-- INSERT DATA DUMMY

INSERT INTO Users (nama_lengkap, username, password, role) 
VALUES
    ('Admin Posyandu',  'admin01',   '1234', 'Bidan'),
    ('Dr. Siti Aminah', 'bidan01',   '1234', 'Bidan'),
    ('Rina Petugas',    'petugas01', '1234', 'Petugas'),
    ('Budi Santoso',    'ortu01',    '1234', 'OrangTua'),
    ('Dewi Rahayu',     'ortu02',    '1234', 'OrangTua');
GO

INSERT INTO Vaksin (nama_vaksin, stok, deskripsi, tgl_kedaluwarsa) 
VALUES
    ('BCG',         50, 'Vaksin Tuberkulosis',                 '2026-12-31'),
    ('Polio',       80, 'Vaksin Polio Oral (OPV)',             '2026-06-30'),
    ('DPT-HB-Hib',  60, 'Vaksin Difteri, Pertusis, Tetanus',   '2025-12-31'),
    ('Campak',      45, 'Vaksin Campak Rubella (MR)',          '2026-09-30'),
    ('Hepatitis B', 70, 'Vaksin Hepatitis B dosis neonatus',   '2026-03-31');
GO

INSERT INTO Jadwal_Posyandu (tgl_pelaksanaan, lokasi, keterangan) 
VALUES
    ('2025-07-10', 'Balai RW 03 Kelurahan Maju',   'Jadwal rutin bulan Juli'),
    ('2025-08-14', 'Balai RW 07 Kelurahan Makmur', 'Jadwal rutin bulan Agustus'),
    ('2025-09-11', 'Puskesmas Pembantu Sejahtera', 'Jadwal rutin bulan September');
GO

INSERT INTO Balita (id_orang_tua, nik, nama_balita, tgl_lahir, jenis_kelamin, nama_ortu) 
VALUES
    (4, '3471010102230001', 'Rizky Dwi Santoso', '2023-02-01', 'L', 'Budi Santoso'), 
    (5, '3471010505220002', 'Alya Putri Rahayu', '2022-05-05', 'P', 'Dewi Rahayu'),  
    (4, '3471011201240003', 'Fajar Nugroho',     '2024-01-12', 'L', 'Budi Santoso'); 
GO

INSERT INTO Transaksi_Imunisasi (id_balita, id_vaksin, id_jadwal, id_petugas, no_antrean, tgl_suntik, status) 
VALUES
    (1, 1, 1, 2, 'A001', '2025-07-10 09:00:00', 'Selesai'),
    (2, 2, 1, 2, 'A002', '2025-07-10 09:15:00', 'Selesai'),
    (1, 3, 2, 2, 'B001', '2025-08-14 10:00:00', 'Selesai');
GO

INSERT INTO Catatan_Pertumbuhan (id_balita, id_petugas, tgl_timbang, berat_badan, tinggi_badan, lingkar_kepala, catatan_tambahan) 
VALUES
    (1, 2, '2025-07-10', 12.50, 88.00, 48.00, 'Pertumbuhan normal, anak sehat'),
    (2, 2, '2025-07-10', 14.20, 95.50, 50.00, 'Anak sangat aktif'),
    (3, 3, '2025-08-14', 9.80,  78.00, 45.50, 'Perlu tambahan gizi, berat di bawah rata-rata');
GO

-- VIEWS

CREATE VIEW vwBalitaPublic AS
SELECT 
    id_balita AS [ID], 
    nik AS [NIK], 
    nama_balita AS [Nama Balita], 
    tgl_lahir AS [Tgl Lahir], 
    jenis_kelamin AS [L/P], 
    nama_ortu AS [Nama Ortu]
FROM Balita;
GO

CREATE VIEW vwVaksinPublic AS
SELECT 
    id_vaksin AS [ID], 
    nama_vaksin AS [Vaksin], 
    stok AS [Stok], 
    deskripsi AS [Deskripsi], 
    tgl_kedaluwarsa AS [Tgl Expired]
FROM Vaksin;
GO

CREATE VIEW vwJadwalPublic AS
SELECT 
    id_jadwal AS [ID], 
    CONVERT(varchar, tgl_pelaksanaan, 106) AS [Tgl Pelaksanaan], 
    lokasi AS [Lokasi], 
    keterangan AS [Keterangan]
FROM Jadwal_Posyandu;
GO

CREATE VIEW vwImunisasiPublic AS
SELECT 
    ti.id_imunisasi AS [ID], 
    b.nama_balita AS [Nama Balita], 
    v.nama_vaksin AS [Vaksin], 
    CONVERT(varchar, j.tgl_pelaksanaan, 106) + ' - ' + j.lokasi AS [Jadwal], 
    ti.no_antrean AS [No. Antrean], 
    FORMAT(ti.tgl_suntik, 'dd/MM/yyyy HH:mm') AS [Tgl Suntik],
    ti.status AS [Status]
FROM Transaksi_Imunisasi ti
JOIN Balita b ON b.id_balita = ti.id_balita
JOIN Vaksin v ON v.id_vaksin = ti.id_vaksin
JOIN Jadwal_Posyandu j ON j.id_jadwal = ti.id_jadwal;
GO

CREATE VIEW vwPertumbuhanPublic AS
SELECT 
    cp.id_pertumbuhan AS [ID], 
    b.nama_balita AS [Nama Balita], 
    CONVERT(varchar, cp.tgl_timbang, 106) AS [Tgl Timbang], 
    cp.berat_badan AS [Berat (kg)], 
    cp.tinggi_badan AS [Tinggi (cm)], 
    cp.lingkar_kepala AS [Lingkar Kepala], 
    cp.catatan_tambahan AS [Catatan]
FROM Catatan_Pertumbuhan cp
JOIN Balita b ON cp.id_balita = b.id_balita;
GO

-- STORED PROCEDURES (CRUD & SEARCH)

-- SP BALITA
CREATE PROCEDURE sp_InsertBalita 
    @id_ortu INT, 
    @nik VARCHAR(16), 
    @nama VARCHAR(100), 
    @tgl DATE, 
    @jk CHAR(1), 
    @ortu VARCHAR(100) 
AS 
BEGIN
    IF EXISTS (SELECT 1 FROM Balita WHERE nik = @nik)
    BEGIN
        RAISERROR('Gagal: NIK sudah terdaftar di dalam database!', 16, 1);
        RETURN;
    END

    INSERT INTO Balita (id_orang_tua, nik, nama_balita, tgl_lahir, jenis_kelamin, nama_ortu) 
    VALUES (@id_ortu, @nik, @nama, @tgl, @jk, @ortu);
END;
GO

CREATE PROCEDURE sp_UpdateBalita 
    @id INT, 
    @nik VARCHAR(16), 
    @nama VARCHAR(100), 
    @tgl DATE, 
    @jk CHAR(1), 
    @ortu VARCHAR(100) 
AS 
BEGIN
    UPDATE Balita 
    SET nik = @nik, nama_balita = @nama, tgl_lahir = @tgl, jenis_kelamin = @jk, nama_ortu = @ortu 
    WHERE id_balita = @id;
END;
GO

CREATE PROCEDURE sp_DeleteBalita 
    @id INT 
AS 
BEGIN 
    BEGIN TRY
        DELETE FROM Balita WHERE id_balita = @id; 
    END TRY
    BEGIN CATCH
        RAISERROR('Akses Ditolak: Data Balita memiliki riwayat transaksi/pertumbuhan.', 16, 1);
    END CATCH
END;
GO

CREATE PROCEDURE sp_SearchBalita 
    @keyword VARCHAR(100) 
AS 
BEGIN
    SET @keyword = ISNULL(@keyword, '');
    SELECT * FROM vwBalitaPublic 
    WHERE [Nama Balita] LIKE '%' + @keyword + '%' OR [NIK] LIKE '%' + @keyword + '%';
END;
GO

-- SP VAKSIN
CREATE PROCEDURE sp_InsertVaksin 
    @nama VARCHAR(50), 
    @stok INT, 
    @deskripsi TEXT, 
    @tgl DATE 
AS 
BEGIN
    INSERT INTO Vaksin (nama_vaksin, stok, deskripsi, tgl_kedaluwarsa) 
    VALUES (@nama, @stok, @deskripsi, @tgl);
END;
GO

CREATE PROCEDURE sp_UpdateVaksin 
    @id INT, 
    @nama VARCHAR(50), 
    @stok INT, 
    @deskripsi TEXT, 
    @tgl DATE 
AS 
BEGIN
    IF (@stok < 0)
    BEGIN
        RAISERROR('Gagal: Stok vaksin tidak boleh kurang dari 0!', 16, 1);
        RETURN;
    END

    UPDATE Vaksin 
    SET nama_vaksin = @nama, stok = @stok, deskripsi = @deskripsi, tgl_kedaluwarsa = @tgl 
    WHERE id_vaksin = @id;
END;
GO

CREATE PROCEDURE sp_DeleteVaksin 
    @id INT 
AS 
BEGIN 
    BEGIN TRY
        DELETE FROM Vaksin WHERE id_vaksin = @id; 
    END TRY
    BEGIN CATCH
        RAISERROR('Akses Ditolak: Vaksin sudah dipakai di transaksi.', 16, 1);
    END CATCH
END;
GO

CREATE PROCEDURE sp_SearchVaksin 
    @keyword VARCHAR(100) 
AS 
BEGIN
    SET @keyword = ISNULL(@keyword, '');
    SELECT * FROM vwVaksinPublic 
    WHERE [Vaksin] LIKE '%' + @keyword + '%';
END;
GO

-- SP JADWAL
CREATE PROCEDURE sp_InsertJadwal 
    @tgl DATE, 
    @lokasi VARCHAR(100), 
    @ket VARCHAR(255) 
AS 
BEGIN
    IF EXISTS (SELECT 1 FROM Jadwal_Posyandu WHERE tgl_pelaksanaan = @tgl AND lokasi = @lokasi)
    BEGIN
        RAISERROR('Gagal: Jadwal sudah ada untuk lokasi dan tanggal tersebut!', 16, 1);
        RETURN;
    END

    INSERT INTO Jadwal_Posyandu (tgl_pelaksanaan, lokasi, keterangan) 
    VALUES (@tgl, @lokasi, @ket);
END;
GO

CREATE PROCEDURE sp_UpdateJadwal 
    @id INT, 
    @tgl DATE, 
    @lokasi VARCHAR(100), 
    @ket VARCHAR(255) 
AS 
BEGIN
    UPDATE Jadwal_Posyandu 
    SET tgl_pelaksanaan = @tgl, lokasi = @lokasi, keterangan = @ket 
    WHERE id_jadwal = @id;
END;
GO

CREATE PROCEDURE sp_DeleteJadwal 
    @id INT 
AS 
BEGIN 
    BEGIN TRY
        DELETE FROM Jadwal_Posyandu WHERE id_jadwal = @id; 
    END TRY
    BEGIN CATCH
        RAISERROR('Akses Ditolak: Jadwal sudah digunakan pada transaksi imunisasi.', 16, 1);
    END CATCH
END;
GO

CREATE PROCEDURE sp_SearchJadwal 
    @keyword VARCHAR(100) 
AS 
BEGIN
    SET @keyword = ISNULL(@keyword, '');
    SELECT * FROM vwJadwalPublic 
    WHERE [Lokasi] LIKE '%' + @keyword + '%';
END;
GO

-- SP IMUNISASI
CREATE PROCEDURE sp_InsertImunisasi 
    @id_balita INT, 
    @id_vaksin INT, 
    @id_jadwal INT, 
    @id_petugas INT, 
    @no_antrean VARCHAR(10), 
    @tgl_suntik DATETIME, 
    @status VARCHAR(10) 
AS 
BEGIN
    IF EXISTS (SELECT 1 FROM Transaksi_Imunisasi WHERE id_balita = @id_balita AND id_vaksin = @id_vaksin AND id_jadwal = @id_jadwal)
    BEGIN
        RAISERROR('Gagal: Anak tersebut sudah terdaftar untuk vaksin ini di jadwal yang sama!', 16, 1);
        RETURN;
    END

    INSERT INTO Transaksi_Imunisasi (id_balita, id_vaksin, id_jadwal, id_petugas, no_antrean, tgl_suntik, status) 
    VALUES (@id_balita, @id_vaksin, @id_jadwal, @id_petugas, @no_antrean, @tgl_suntik, @status);
END;
GO

CREATE PROCEDURE sp_UpdateImunisasi 
    @id INT, 
    @status VARCHAR(10) 
AS 
BEGIN
    UPDATE Transaksi_Imunisasi 
    SET status = @status 
    WHERE id_imunisasi = @id;
END;
GO

CREATE PROCEDURE sp_DeleteImunisasi 
    @id INT 
AS 
BEGIN 
    DELETE FROM Transaksi_Imunisasi WHERE id_imunisasi = @id; 
END;
GO

CREATE PROCEDURE sp_SearchImunisasi 
    @keyword VARCHAR(100) 
AS 
BEGIN
    SET @keyword = ISNULL(@keyword, '');
    SELECT * FROM vwImunisasiPublic 
    WHERE [Nama Balita] LIKE '%' + @keyword + '%';
END;
GO

-- SP PERTUMBUHAN
CREATE PROCEDURE sp_InsertPertumbuhan 
    @id_balita INT, 
    @id_petugas INT, 
    @tgl DATE, 
    @berat DECIMAL(5,2), 
    @tinggi DECIMAL(5,2), 
    @lk DECIMAL(5,2), 
    @catatan VARCHAR(255) 
AS 
BEGIN
    INSERT INTO Catatan_Pertumbuhan (id_balita, id_petugas, tgl_timbang, berat_badan, tinggi_badan, lingkar_kepala, catatan_tambahan) 
    VALUES (@id_balita, @id_petugas, @tgl, @berat, @tinggi, @lk, @catatan);
END;
GO

CREATE PROCEDURE sp_UpdatePertumbuhan 
    @id INT, 
    @tgl DATE, 
    @berat DECIMAL(5,2), 
    @tinggi DECIMAL(5,2), 
    @lk DECIMAL(5,2), 
    @catatan VARCHAR(255) 
AS 
BEGIN
    UPDATE Catatan_Pertumbuhan 
    SET tgl_timbang = @tgl, berat_badan = @berat, tinggi_badan = @tinggi, lingkar_kepala = @lk, catatan_tambahan = @catatan 
    WHERE id_pertumbuhan = @id;
END;
GO

CREATE PROCEDURE sp_DeletePertumbuhan 
    @id INT 
AS 
BEGIN 
    DELETE FROM Catatan_Pertumbuhan WHERE id_pertumbuhan = @id; 
END;
GO

CREATE PROCEDURE sp_SearchPertumbuhan 
    @keyword VARCHAR(100) 
AS 
BEGIN
    SET @keyword = ISNULL(@keyword, '');
    SELECT * FROM vwPertumbuhanPublic 
    WHERE [Nama Balita] LIKE '%' + @keyword + '%';
END;
GO

-- SP COUNT

CREATE PROCEDURE sp_CountBalita @Total INT OUTPUT AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT @Total = COUNT(*) FROM Balita; 
END;
GO

CREATE PROCEDURE sp_CountVaksin @Total INT OUTPUT AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT @Total = COUNT(*) FROM Vaksin; 
END;
GO

CREATE PROCEDURE sp_CountJadwal @Total INT OUTPUT AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT @Total = COUNT(*) FROM Jadwal_Posyandu; 
END;
GO

CREATE PROCEDURE sp_CountImunisasi @Total INT OUTPUT AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT @Total = COUNT(*) FROM Transaksi_Imunisasi; 
END;
GO

CREATE PROCEDURE sp_CountPertumbuhan @Total INT OUTPUT AS 
BEGIN 
    SET NOCOUNT ON; 
    SELECT @Total = COUNT(*) FROM Catatan_Pertumbuhan; 
END;
GO