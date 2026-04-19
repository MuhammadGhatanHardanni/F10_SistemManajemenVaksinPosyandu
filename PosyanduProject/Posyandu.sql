CREATE DATABASE PosyanduVaksin;
GO

USE PosyanduVaksin;
GO

CREATE TABLE Users (
    id_user       INT PRIMARY KEY IDENTITY(1,1),
    nama_lengkap  VARCHAR(100) NOT NULL,
    username      VARCHAR(50)  NOT NULL UNIQUE,
    password      VARCHAR(255) NOT NULL,
    role          VARCHAR(20)  NOT NULL CHECK (role IN ('Bidan','Petugas','OrangTua'))
);

CREATE TABLE Balita (
    id_balita    INT PRIMARY KEY IDENTITY(1,1),
    id_orang_tua INT          NULL REFERENCES Users(id_user),
    nik          VARCHAR(16)  NOT NULL UNIQUE,
    nama_balita  VARCHAR(100) NOT NULL,
    tgl_lahir    DATE         NOT NULL,
    jenis_kelamin CHAR(1)     NOT NULL CHECK (jenis_kelamin IN ('L','P')),
    nama_ortu    VARCHAR(100) NOT NULL
);

CREATE TABLE Vaksin (
    id_vaksin       INT PRIMARY KEY IDENTITY(1,1),
    nama_vaksin     VARCHAR(50)  NOT NULL,
    stok            INT          NOT NULL DEFAULT 0,
    deskripsi       TEXT         NULL,
    tgl_kedaluwarsa DATE         NOT NULL
);

CREATE TABLE Jadwal_Posyandu (
    id_jadwal       INT PRIMARY KEY IDENTITY(1,1),
    tgl_pelaksanaan DATE          NOT NULL,
    lokasi          VARCHAR(100)  NOT NULL,
    keterangan      VARCHAR(255)  NULL
);

CREATE TABLE Transaksi_Imunisasi (
    id_imunisasi INT PRIMARY KEY IDENTITY(1,1),
    id_balita    INT          NOT NULL REFERENCES Balita(id_balita),
    id_vaksin    INT          NOT NULL REFERENCES Vaksin(id_vaksin),
    id_jadwal    INT          NOT NULL REFERENCES Jadwal_Posyandu(id_jadwal),
    id_petugas   INT          NOT NULL REFERENCES Users(id_user),
    no_antrean   VARCHAR(10)  NOT NULL,
    tgl_suntik   DATETIME     NOT NULL DEFAULT GETDATE(),
    status       VARCHAR(10)  NOT NULL DEFAULT 'Terdaftar'
                              CHECK (status IN ('Terdaftar','Selesai','Batal'))
);

-- Users
INSERT INTO Users (nama_lengkap, username, password, role) VALUES
('Dr. Siti Aminah',    'bidan01',   '1234', 'Bidan'),
('Rina Petugas',       'petugas01', '1234', 'Petugas'),
('Budi Santoso',       'ortu01',    '1234', 'OrangTua'),
('Dewi Rahayu',        'ortu02',    '1234', 'OrangTua');

-- Vaksin
INSERT INTO Vaksin (nama_vaksin, stok, deskripsi, tgl_kedaluwarsa) VALUES
('BCG',         50, 'Vaksin Tuberkulosis',           '2026-12-31'),
('Polio',       80, 'Vaksin Polio Oral (OPV)',        '2026-06-30'),
('DPT-HB-Hib',  60, 'Vaksin Difteri, Pertusis, Tetanus', '2025-12-31'),
('Campak',      45, 'Vaksin Campak Rubella (MR)',     '2026-09-30'),
('Hepatitis B', 70, 'Vaksin Hepatitis B dosis neonatus', '2026-03-31');

-- Jadwal Posyandu
INSERT INTO Jadwal_Posyandu (tgl_pelaksanaan, lokasi, keterangan) VALUES
('2025-07-10', 'Balai RW 03 Kelurahan Maju',  'Jadwal rutin bulan Juli'),
('2025-08-14', 'Balai RW 07 Kelurahan Makmur','Jadwal rutin bulan Agustus'),
('2025-09-11', 'Puskesmas Pembantu Sejahtera', 'Jadwal rutin bulan September');

-- Balita
INSERT INTO Balita (id_orang_tua, nik, nama_balita, tgl_lahir, jenis_kelamin, nama_ortu) VALUES
(3, '3471010102230001', 'Rizky Dwi Santoso',  '2023-02-01', 'L', 'Budi Santoso'),
(4, '3471010505220002', 'Alya Putri Rahayu',  '2022-05-05', 'P', 'Dewi Rahayu'),
(3, '3471011201240003', 'Fajar Nugroho',      '2024-01-12', 'L', 'Budi Santoso');

-- Transaksi Imunisasi
INSERT INTO Transaksi_Imunisasi (id_balita, id_vaksin, id_jadwal, id_petugas, no_antrean, tgl_suntik, status) VALUES
(1, 1, 1, 2, 'A001', '2025-07-10 09:00:00', 'Selesai'),
(2, 2, 1, 2, 'A002', '2025-07-10 09:15:00', 'Selesai'),
(1, 3, 2, 2, 'B001', '2025-08-14 10:00:00', 'Selesai');