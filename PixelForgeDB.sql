CREATE DATABASE PixelForge_DB
GO
USE PixelForge_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Yazar')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTur_ID int,
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(20),
	Mail nvarchar(100),
	Sifre nvarchar(12),
	Durum bit,
	CONSTRAINT pk_Yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTur_ID)
	REFERENCES YoneticiTurleri(ID) 
)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Durum bit,
	CONSTRAINT pk_kategoriler PRIMARY KEY(ID)
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(1,1),
	Kategori_ID int,
	Yazar_ID int,
	Baslik nvarchar(150),
	Ozet nvarchar(350),
	Icerik ntext,
	KapakResim nvarchar(70),
	EklemeTarih Datetime,
	GoruntulemeSayi int,
	BegeniSayi int,
	BegeniOrani decimal(18,2),
	Durum bit,
	CONSTRAINT pk_Makale PRIMARY KEY(ID),
	CONSTRAINT fk_MakaleKategori FOREIGN KEY(Kategori_ID)
	REFERENCES Kategoriler(ID),
	CONSTRAINT fk_MakaleYazar FOREIGN KEY(Yazar_ID)
	REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(20),
	Mail nvarchar(100),
	Sifre nvarchar(12),
	UyelikTarihi Datetime,
	Durum bit,
	CONSTRAINT pk_uye PRIMARY KEY(ID),
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	Uye_ID int,
	Makale_ID int,
	Yonetici_ID int,
	YorumTarih Datetime,
	Durum bit,
	CONSTRAINT pk_Yorum PRIMARY KEY(ID),
	CONSTRAINT fk_yorumUye FOREIGN KEY(Uye_ID) REFERENCES Uyeler(ID),
	CONSTRAINT fk_yorumMakale FOREIGN KEY(Makale_ID) REFERENCES Makaleler(ID),
	CONSTRAINT fk_yorumYonetici FOREIGN KEY(Yonetici_ID) REFERENCES Yoneticiler(ID)
)