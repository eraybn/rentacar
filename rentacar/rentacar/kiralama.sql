-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 16 May 2023, 13:26:55
-- Sunucu sürümü: 10.4.25-MariaDB
-- PHP Sürümü: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `kiralama`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `arackayit`
--

CREATE TABLE `arackayit` (
  `a_sira` int(11) NOT NULL,
  `a_plaka` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_marka` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_seri` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_model` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_renk` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_km` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_yakit` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_ucret` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_durum` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `arackayit`
--

INSERT INTO `arackayit` (`a_sira`, `a_plaka`, `a_marka`, `a_seri`, `a_model`, `a_renk`, `a_km`, `a_yakit`, `a_ucret`, `a_durum`) VALUES
(1, '31 BAL 031', 'BMW', '320d', '2021', 'SİYAH', '29.384', 'Dizel', '1500', 'Boş'),
(2, '31 ERY 07', 'RENAULT', 'talisman', '2022', 'FÜME(GRİ)', '57.000', 'Benzin', '900', 'Dolu'),
(4, '31 AHU 030', 'MERCEDES', 'c180', '2012', 'BEJ', '178.843', 'Benzin', '840', 'Dolu'),
(5, '33 BAR 033', 'MERCEDES', 'e250', '2019', 'BEYAZ', '45.756', 'Benzin', '970', 'Boş'),
(8, '27 AAN 046', 'RENAULT', 'symbol', '2016', 'BEYAZ', '198.715', 'Dizel', '355', 'Boş'),
(9, '01 UDK 020', 'MERCEDES', 'c180', '2012', 'BEYAZ', '243.010', 'Benzin', '620', 'Boş');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri_ekleme`
--

CREATE TABLE `musteri_ekleme` (
  `m_sira` int(11) NOT NULL,
  `m_tc` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_ad_soyad` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_cinsiyet` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_telefon` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_adres` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_ehliyet_no` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_ehl_yer` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_mail` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `musteri_ekleme`
--

INSERT INTO `musteri_ekleme` (`m_sira`, `m_tc`, `m_ad_soyad`, `m_cinsiyet`, `m_telefon`, `m_adres`, `m_ehliyet_no`, `m_ehl_yer`, `m_mail`) VALUES
(2, '95456248515', 'BARAN CEV', 'E', '(452) 545-5151', 'MERSIN', 'ZX -4528', 'MERSIN', 'baran@gmail.com'),
(3, '51525545155', 'ALICAN BERK', 'K', '(625) 151-2215', 'KONYA', 'ME -7652', 'KONYA', 'ali@gmail.com'),
(4, '26455265251', 'MADISON BEER', 'K', '(451) 251-2551', 'KARS', 'EL -7964', 'KARS', 'madison@gmail.com'),
(6, '12651225251', 'HANDE ERÇEL', 'K', '(151) 525-5151', 'MANISA', 'ER -8430', 'MANISA', 'handeee@gmail.com'),
(7, '45121522151', 'SERENAY SARı', 'K', '(655) 626-5252', 'İSTANBUL', 'QK -7637', 'ISTANBUL', 'sere@gmail.com'),
(11, '26452164856', 'ERAY BAL', 'E', '(537) 818-0658', 'HATAY', 'AC -264458', 'HATAY', 'eray@gmail.com'),
(13, '46892584561', 'EREN TOK', 'E', '(541) 515-4155', 'MUĞLA', 'CZ -4798 ', 'NEVŞEHIR', 'eren@gmail.com'),
(14, '79512555454', 'IREM GULER', 'K', '(534) 845-1625', 'ADANA', 'MA -6183', 'ADANA', 'irem@gmail.com');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sozlesme`
--

CREATE TABLE `sozlesme` (
  `m_sira` int(11) NOT NULL,
  `m_tc` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_ad_soyad` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_telefon` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_ehliyet_no` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `m_ehl_yer` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_plaka` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_km` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_odeme_tur` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_kira_ucret` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_gun` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_tutar` varchar(255) COLLATE utf8_turkish_ci NOT NULL DEFAULT '',
  `a_cikis_tarih` datetime NOT NULL DEFAULT current_timestamp(),
  `a_donus_tarih` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `sozlesme`
--

INSERT INTO `sozlesme` (`m_sira`, `m_tc`, `m_ad_soyad`, `m_telefon`, `m_ehliyet_no`, `m_ehl_yer`, `a_plaka`, `a_km`, `a_odeme_tur`, `a_kira_ucret`, `a_gun`, `a_tutar`, `a_cikis_tarih`, `a_donus_tarih`) VALUES
(21, 'ALICAN BERK', '51525545155', '(625) 151-2215', 'ME -7652', 'KONYA', '31 ERY 07', '57.000', 'Nakit', '900', '13', '10800', '2023-05-16 00:00:00', '2023-05-29 00:00:00'),
(22, 'IREM GULER', '79512555454', '(534) 845-1625', 'MA -6183', 'ADANA', '31 AHU 030', '178.843', 'Nakit', '840', '15', '12600', '2023-05-16 00:00:00', '2023-05-31 00:00:00'),
(25, 'ERAY BAL', '26452164856', '(537) 818-0658', 'AC -264458', 'HATAY', '31 BAL 031', '29.384', 'Nakit', '1500', '11', '16500', '2023-05-16 00:00:00', '2023-05-27 00:00:00'),
(27, 'BARAN CEV', '95456248515', '(452) 545-5151', 'ZX -4528', 'MERSIN', '33 BAR 033', '45.756', 'Nakit', '970', '12', '11640', '2023-05-16 00:00:00', '2023-05-28 00:00:00');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `arackayit`
--
ALTER TABLE `arackayit`
  ADD PRIMARY KEY (`a_sira`);

--
-- Tablo için indeksler `musteri_ekleme`
--
ALTER TABLE `musteri_ekleme`
  ADD PRIMARY KEY (`m_sira`);

--
-- Tablo için indeksler `sozlesme`
--
ALTER TABLE `sozlesme`
  ADD PRIMARY KEY (`m_sira`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `arackayit`
--
ALTER TABLE `arackayit`
  MODIFY `a_sira` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `musteri_ekleme`
--
ALTER TABLE `musteri_ekleme`
  MODIFY `m_sira` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Tablo için AUTO_INCREMENT değeri `sozlesme`
--
ALTER TABLE `sozlesme`
  MODIFY `m_sira` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
