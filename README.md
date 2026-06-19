<<<<<<< HEAD
Koneksi Ke Database

<img width="502" height="443" alt="image" src="https://github.com/user-attachments/assets/1237ab33-e3d8-4abe-b1f7-5386ff6eb3a4" />

ditandai dengan muncul pada form Login


Form Insert Data

<img width="1919" height="1021" alt="image" src="https://github.com/user-attachments/assets/a2a5e7e3-3550-41ad-8b10-b79da002b7d6" />


Form Tampil Data

<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/ee864d30-f2a2-4c65-81e4-a630ab57ece8" />


Bukti Insert, Update, Delete dan Search

insert
<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/33118893-8dfa-4019-b477-e9fd09a39e52" />

update
<img width="1919" height="1017" alt="image" src="https://github.com/user-attachments/assets/c699de06-c075-436e-ae5d-0783873a4f83" />
<img width="1919" height="1014" alt="image" src="https://github.com/user-attachments/assets/b6a1d681-6129-45d4-beed-cf06f9c9c973" />

delete
<img width="1919" height="1019" alt="image" src="https://github.com/user-attachments/assets/fd661a1c-d525-4fb7-ad2b-69dd2cb671da" />
<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/5526ac7e-9d42-4edf-88ba-7fa0eedea67e" />
<img width="1919" height="1021" alt="image" src="https://github.com/user-attachments/assets/d8f3d3be-b200-44c7-a6cf-b818eda2af0f" />

search
<img width="1919" height="1024" alt="image" src="https://github.com/user-attachments/assets/384767ad-5316-4eda-8f07-8ca7d4a11fe5" />


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
=======
Koneksi Ke Database

<img width="502" height="443" alt="image" src="https://github.com/user-attachments/assets/1237ab33-e3d8-4abe-b1f7-5386ff6eb3a4" />

ditandai dengan muncul pada form Login


Form Insert Data

<img width="1919" height="1021" alt="image" src="https://github.com/user-attachments/assets/a2a5e7e3-3550-41ad-8b10-b79da002b7d6" />


Form Tampil Data

<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/ee864d30-f2a2-4c65-81e4-a630ab57ece8" />


Bukti Insert, Update, Delete dan Search

insert
<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/33118893-8dfa-4019-b477-e9fd09a39e52" />

update
<img width="1919" height="1017" alt="image" src="https://github.com/user-attachments/assets/c699de06-c075-436e-ae5d-0783873a4f83" />
<img width="1919" height="1014" alt="image" src="https://github.com/user-attachments/assets/b6a1d681-6129-45d4-beed-cf06f9c9c973" />

delete
<img width="1919" height="1019" alt="image" src="https://github.com/user-attachments/assets/fd661a1c-d525-4fb7-ad2b-69dd2cb671da" />
<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/5526ac7e-9d42-4edf-88ba-7fa0eedea67e" />
<img width="1919" height="1021" alt="image" src="https://github.com/user-attachments/assets/d8f3d3be-b200-44c7-a6cf-b818eda2af0f" />

search
<img width="1919" height="1024" alt="image" src="https://github.com/user-attachments/assets/384767ad-5316-4eda-8f07-8ca7d4a11fe5" />


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
>>>>>>> b4e69e4d388eddcb5a4372e27286ff12ac2c1fdd
