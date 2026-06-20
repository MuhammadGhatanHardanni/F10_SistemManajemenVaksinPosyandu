Koneksi Ke Database

<img width="555" height="486" alt="image" src="https://github.com/user-attachments/assets/7a33e8c2-b68c-4a57-b6de-1444093c54dc" />


ditandai dengan muncul pada form Login


Form Insert Data

<img width="1918" height="1020" alt="image" src="https://github.com/user-attachments/assets/48904668-eac0-4a03-b1a6-eb9b09fa83c4" />


Form Tampil Data

<img width="1918" height="1017" alt="image" src="https://github.com/user-attachments/assets/9f2ef877-6b37-4a45-960f-5402f65bc37d" />


Bukti Insert, Update, Delete dan Search

insert
<img width="1918" height="1015" alt="image" src="https://github.com/user-attachments/assets/b175f035-5d65-4069-b719-c649ac53a8c8" />
<img width="1918" height="1013" alt="image" src="https://github.com/user-attachments/assets/0fa27eea-e4f6-46c0-b54a-ff7d18657c4f" />


update
<img width="1918" height="1015" alt="image" src="https://github.com/user-attachments/assets/82299326-b9c7-47a1-aa17-94981799e9b7" />
<img width="1918" height="1017" alt="image" src="https://github.com/user-attachments/assets/c9468fff-e784-43b8-9873-b2afe730be30" />

delete
<img width="1918" height="1017" alt="image" src="https://github.com/user-attachments/assets/7a16b854-999c-4b83-a05d-d9d5b8bfb2ca" />
<img width="1918" height="1015" alt="image" src="https://github.com/user-attachments/assets/e5f80e96-d4e4-47b4-a9a5-af6cf27dda3d" />
<img width="1918" height="1017" alt="image" src="https://github.com/user-attachments/assets/ab5e178c-02eb-4947-ae19-d810f4cb25f9" />

search
<img width="1918" height="1017" alt="image" src="https://github.com/user-attachments/assets/8a73db2d-c841-4537-9500-d9765264c209" />


Sekenario SQL Injection

Dalam skenario ini, kelompok kami menguji keamanan form login pada Sistem Manajemen Vaksin Posyandu. Kami ingin menunjukkan bahwa sistem yang seharusnya hanya bisa diakses dengan kombinasi username dan password yang benar, ternyata memiliki celah dan bisa ditembus menggunakan manipulasi kode SQL.

Pengujian ini kami lakukan dengan empat tujuan utama:

Membuktikan celah keamanan: Memastikan apakah form login rentan terhadap serangan manipulasi database.

Demonstrasi Authentication Bypass: Menunjukkan secara langsung bagaimana proses validasi login bisa dilewati begitu saja.

Analisis Risiko: Memahami seberapa besar bahaya yang mengancam jika sistem ini digunakan di dunia nyata dan diserang oleh pihak tak bertanggung jawab.

Penerapan Solusi: Menemukan letak kesalahan pada kode program dan menerapkan perbaikannya agar sistem kembali aman.

Langkah-Langkah Serangan
Cara kerja serangan ini cukup sederhana, dengan target mengambil alih hak akses tertinggi (Bidan/Admin). Berikut adalah simulasi langkahnya:

Buka aplikasi hingga form Login muncul.

Pada kolom Username, jangan masukkan nama pengguna biasa, melainkan masukkan kode manipulasi ini: admin' OR '1'='1

Pada kolom Password, isi dengan teks sembarang (misalnya: bebas123).

Klik tombol Login.

Mengapa Sistem Bisa Tertipu?
Kerentanan ini terjadi karena sistem database membaca input pengguna secara mentah-mentah. Ketika kita memasukkan kode admin' OR '1'='1, kita sedang memberikan sebuah pernyataan logika matematika kepada database.

Sistem akan mengevaluasi pernyataan 1='1' (satu sama dengan satu). Karena pernyataan tersebut bernilai Selalu Benar (TRUE), sistem langsung menganggap bahwa syarat untuk login sudah terpenuhi. Akibatnya, sistem mengabaikan password yang salah dan langsung membukakan pintu menuju halaman Dashboard Utama.

Dampak Fatal bagi Sistem
Jika eksploitasi ini berhasil dilakukan oleh peretas, dampaknya sangat kritis. Penyerang yang masuk menggunakan sesi Bidan/Admin akan mendapatkan kendali penuh (full access) atas aplikasi. Penyerang dapat melihat, mengubah, merusak, hingga menghapus seluruh data krusial, seperti data rekam medis balita, informasi orang tua, stok vaksin, hingga mengambil alih akun pengguna lainnya.
