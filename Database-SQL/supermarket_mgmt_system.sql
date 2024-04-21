-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 13, 2024 at 03:47 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `supermarket_mgmt_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `customer_table`
--

CREATE TABLE `customer_table` (
  `customer_ID` int(11) NOT NULL,
  `loyalty_number` varchar(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `NIC` varchar(12) NOT NULL,
  `contact_num` varchar(10) NOT NULL,
  `points` int(11) NOT NULL DEFAULT 0,
  `registered_date` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer_table`
--

INSERT INTO `customer_table` (`customer_ID`, `loyalty_number`, `name`, `NIC`, `contact_num`, `points`, `registered_date`) VALUES
(1, '112233', 'Jonathan Fedrik', '0', '0715001002', 0, '2024-03-30'),
(2, '112234', 'John Thomas', '199985854652', '0758542155', 5, '2024-03-30'),
(3, '115234', 'John Sam', '199558585465', '0758542150', 50, '2024-03-30'),
(4, '252212', 'Sam Anderson', '200012121512', '0785225412', 268, '2024-03-30'),
(5, '552210', 'John Derik', '199956452345', '0712536412', 0, '2024-03-30');

-- --------------------------------------------------------

--
-- Table structure for table `login_users`
--

CREATE TABLE `login_users` (
  `userID` int(10) NOT NULL,
  `username` varchar(150) NOT NULL,
  `password` varchar(150) NOT NULL,
  `role` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login_users`
--

INSERT INTO `login_users` (`userID`, `username`, `password`, `role`) VALUES
(1, 'John', '123', 'manager'),
(2, 'Derik', '123', 'cashier'),
(3, 'Alice', '123', 'stock keeper'),
(4, 'Bob', '123', 'manager'),
(5, 'Eva', '123', 'cashier'),
(6, 'Linda', '123', 'stock keeper');

-- --------------------------------------------------------

--
-- Table structure for table `stocks_table`
--

CREATE TABLE `stocks_table` (
  `stock_ID` int(10) NOT NULL,
  `barcode` int(30) NOT NULL,
  `item_name` varchar(200) NOT NULL,
  `unit_price` decimal(5,2) NOT NULL,
  `no_of_items` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `stocks_table`
--

INSERT INTO `stocks_table` (`stock_ID`, `barcode`, `item_name`, `unit_price`, `no_of_items`) VALUES
(11, 12345, 'LIFEBUOY SOAP', '100.00', 79),
(12, 12335, 'SUNLIGHT SOAP', '80.00', 90),
(13, 78552, 'MUNCHEE GINGER BUSCUIT', '150.00', 50),
(14, 93412, 'COCA-COLA', '220.00', 189),
(19, 63341, 'LAY\'S POTATO CHIPS', '129.99', 120),
(20, 87465, 'DOVE SHAMPOO', '400.99', 80),
(21, 54518, 'TIDE LAUNDRY DETERGENT', '80.50', 100),
(22, 37859, 'KITKAT CHOCOLATE BAR', '500.00', 146),
(24, 93415, 'COCA-COLA-ZERO', '200.00', 108);

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `billNumber` int(11) NOT NULL,
  `loyaltyNumber` varchar(10) DEFAULT NULL,
  `transactionDate` datetime NOT NULL DEFAULT current_timestamp(),
  `paymentMethod` varchar(4) NOT NULL,
  `totalAmount` decimal(10,2) NOT NULL,
  `discount` decimal(10,2) NOT NULL,
  `netTotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`billNumber`, `loyaltyNumber`, `transactionDate`, `paymentMethod`, `totalAmount`, `discount`, `netTotal`) VALUES
(1004, '252212', '2024-04-02 14:08:17', '', '1750.00', '2.00', '1748.00'),
(1021, '', '2024-04-12 18:49:15', '', '100.00', '0.00', '100.00'),
(1022, '', '2024-04-12 22:00:46', '', '100.00', '0.00', '100.00'),
(1023, '', '2024-04-12 22:02:01', '', '100.00', '0.00', '100.00'),
(1024, '', '2024-04-12 22:24:10', '', '100.00', '0.00', '100.00'),
(1025, '', '2024-04-12 22:28:30', '', '100.00', '0.00', '100.00'),
(1026, '', '2024-04-12 22:31:05', '', '100.00', '0.00', '100.00'),
(1027, '', '2024-04-12 22:41:22', '', '1300.00', '0.00', '1300.00'),
(1028, '', '2024-04-12 23:08:49', '', '300.00', '0.00', '300.00'),
(1029, '252212', '2024-04-13 00:11:55', '', '2450.00', '29.40', '2420.60'),
(1030, '', '2024-04-13 16:16:52', 'Cash', '350.00', '0.00', '350.00'),
(1031, '112234', '2024-04-13 16:41:48', 'Card', '100.00', '0.00', '100.00'),
(1032, 'NA', '2024-04-13 16:42:12', 'Cash', '100.00', '0.00', '100.00'),
(1033, 'NA', '2024-04-13 19:14:40', 'Card', '500.00', '0.00', '500.00');

-- --------------------------------------------------------

--
-- Table structure for table `transaction_items`
--

CREATE TABLE `transaction_items` (
  `transactionItemID` int(11) NOT NULL,
  `billNumber` int(11) NOT NULL,
  `barcode` int(30) NOT NULL,
  `itemName` varchar(255) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unitPrice` decimal(10,2) NOT NULL,
  `totalItemPrice` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transaction_items`
--

INSERT INTO `transaction_items` (`transactionItemID`, `billNumber`, `barcode`, `itemName`, `quantity`, `unitPrice`, `totalItemPrice`) VALUES
(22, 1021, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(23, 1022, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(24, 1023, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(25, 1024, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(26, 1025, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(27, 1026, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(28, 1027, 12345, 'LIFEBUOY SOAP', 13, '100.00', '1300.00'),
(29, 1028, 12345, 'LIFEBUOY SOAP', 3, '100.00', '300.00'),
(30, 1029, 12345, 'LIFEBUOY SOAP', 2, '100.00', '200.00'),
(31, 1029, 93412, 'COCA-COLA', 1, '250.00', '250.00'),
(32, 1029, 37859, 'KITKAT CHOCOLATE BAR', 4, '500.00', '2000.00'),
(33, 1030, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(34, 1030, 93412, 'COCA-COLA', 1, '250.00', '250.00'),
(35, 1031, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(36, 1032, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(37, 1033, 12345, 'LIFEBUOY SOAP', 1, '100.00', '100.00'),
(38, 1033, 93415, 'COCA-COLA-ZERO', 2, '200.00', '400.00');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer_table`
--
ALTER TABLE `customer_table`
  ADD PRIMARY KEY (`customer_ID`);

--
-- Indexes for table `login_users`
--
ALTER TABLE `login_users`
  ADD PRIMARY KEY (`userID`);

--
-- Indexes for table `stocks_table`
--
ALTER TABLE `stocks_table`
  ADD PRIMARY KEY (`stock_ID`),
  ADD UNIQUE KEY `barcode` (`barcode`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`billNumber`);

--
-- Indexes for table `transaction_items`
--
ALTER TABLE `transaction_items`
  ADD PRIMARY KEY (`transactionItemID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customer_table`
--
ALTER TABLE `customer_table`
  MODIFY `customer_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `login_users`
--
ALTER TABLE `login_users`
  MODIFY `userID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `stocks_table`
--
ALTER TABLE `stocks_table`
  MODIFY `stock_ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `billNumber` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1034;

--
-- AUTO_INCREMENT for table `transaction_items`
--
ALTER TABLE `transaction_items`
  MODIFY `transactionItemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
