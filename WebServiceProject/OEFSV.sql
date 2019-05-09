-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: May 09, 2019 at 09:53 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `OEFSV`
--

-- --------------------------------------------------------

--
-- Table structure for table `bankPaymentFormFillup`
--

CREATE TABLE `bankPaymentFormFillup` (
  `id` int(11) NOT NULL,
  `regNum` varchar(50) NOT NULL,
  `transacNum` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bankPaymentFormFillup`
--

INSERT INTO `bankPaymentFormFillup` (`id`, `regNum`, `transacNum`) VALUES
(7, '2013-123-456', 491669),
(8, '2013-123-457', 123),
(9, '2013-123-456', 124),
(10, '2013-123-457', 126),
(13, '2013-123-456', 601386),
(14, '2013-123-456', 689775),
(15, '2013-123-456', 184925),
(16, '2013-123-456', 175314),
(17, '2013-123-456', 891861),
(18, '2013-123-456', 741893),
(19, '2013-123-456', 133447),
(20, '2013-123-456', 394170),
(21, '2013-123-456', 694672),
(22, '2013-123-456', 843841),
(23, '2013-123-456', 748159);

-- --------------------------------------------------------

--
-- Table structure for table `departmentInfo`
--

CREATE TABLE `departmentInfo` (
  `id` int(11) NOT NULL,
  `regNum` varchar(50) NOT NULL,
  `attendance` double NOT NULL,
  `dept_payment` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `departmentInfo`
--

INSERT INTO `departmentInfo` (`id`, `regNum`, `attendance`, `dept_payment`) VALUES
(1, '2013-123-456', 88, 7000);

-- --------------------------------------------------------

--
-- Table structure for table `hallInfo`
--

CREATE TABLE `hallInfo` (
  `id` int(11) NOT NULL,
  `regNum` varchar(50) NOT NULL,
  `is_resident` tinyint(1) NOT NULL,
  `hall_payment_res` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hallInfo`
--

INSERT INTO `hallInfo` (`id`, `regNum`, `is_resident`, `hall_payment_res`) VALUES
(1, '2013-123-456', 1, 900);

-- --------------------------------------------------------

--
-- Table structure for table `registrarInfo`
--

CREATE TABLE `registrarInfo` (
  `id` int(11) NOT NULL,
  `regNum` varchar(50) NOT NULL,
  `universityFee` double NOT NULL,
  `examRoll` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `registrarInfo`
--

INSERT INTO `registrarInfo` (`id`, `regNum`, `universityFee`, `examRoll`) VALUES
(1, '2013-123-456', 5000, 4978),
(2, '2013-123-456', 7000, 1179);

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `id` int(11) NOT NULL,
  `regNum` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `gender` varchar(50) NOT NULL,
  `fatherName` varchar(50) NOT NULL,
  `motherName` varchar(50) NOT NULL,
  `session` varchar(50) NOT NULL,
  `instOrDept` varchar(50) NOT NULL,
  `hall` varchar(50) NOT NULL,
  `currentSemester` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`id`, `regNum`, `name`, `gender`, `fatherName`, `motherName`, `session`, `instOrDept`, `hall`, `currentSemester`) VALUES
(1, '2013-123-456', 'Nazmul', 'Male', 'Father', 'Mother', '2013-2014', 'IIT', 'Amar Ekushey Hall', 1),
(2, '2013-123-457', 'Abc', 'Male', 'def', 'ghi', '2013-14', 'IIT', 'FH', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bankPaymentFormFillup`
--
ALTER TABLE `bankPaymentFormFillup`
  ADD PRIMARY KEY (`id`),
  ADD KEY `regNum` (`regNum`);

--
-- Indexes for table `departmentInfo`
--
ALTER TABLE `departmentInfo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `regNum` (`regNum`);

--
-- Indexes for table `hallInfo`
--
ALTER TABLE `hallInfo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `regNum` (`regNum`);

--
-- Indexes for table `registrarInfo`
--
ALTER TABLE `registrarInfo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `regNum` (`regNum`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`regNum`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bankPaymentFormFillup`
--
ALTER TABLE `bankPaymentFormFillup`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `registrarInfo`
--
ALTER TABLE `registrarInfo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bankPaymentFormFillup`
--
ALTER TABLE `bankPaymentFormFillup`
  ADD CONSTRAINT `bankPaymentFormFillup_ibfk_1` FOREIGN KEY (`regNum`) REFERENCES `student` (`regNum`);

--
-- Constraints for table `departmentInfo`
--
ALTER TABLE `departmentInfo`
  ADD CONSTRAINT `departmentInfo_ibfk_1` FOREIGN KEY (`regNum`) REFERENCES `student` (`regNum`);

--
-- Constraints for table `hallInfo`
--
ALTER TABLE `hallInfo`
  ADD CONSTRAINT `hallInfo_ibfk_1` FOREIGN KEY (`regNum`) REFERENCES `student` (`regNum`);

--
-- Constraints for table `registrarInfo`
--
ALTER TABLE `registrarInfo`
  ADD CONSTRAINT `registrarInfo_ibfk_1` FOREIGN KEY (`regNum`) REFERENCES `student` (`regNum`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
