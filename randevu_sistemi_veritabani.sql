create database randevu_sistemi
use randevu_sistemi
create table randevu(
ad varchar(50) not null,
soyad varchar(50) not null,
numara int not null,
tarih date not null,
saat time not null,
bolum varchar(50) not null
)

select * from randevu







create database randevu_sistemi
use randevu_sistemi
create table randevu(
ad varchar(50) not null,
soyad varchar(50) not null,
numara int not null,
tarih date not null,
saat time not null
)

alter table randevu
add bolum varchar(50) not null

