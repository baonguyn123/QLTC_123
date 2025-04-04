-- Tạo database mới
CREATE DATABASE QuanLyChamSocThuCung5;
GO

USE QuanLyChamSocThuCung5;
GO


-- Tạo bảng Bill
CREATE TABLE Bill (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    DateOutput DATETIME  NULL,
    TotalPrice DECIMAL(10, 2) NULL,
	EmployeeID INT NULL FOREIGN KEY REFERENCES Employee(ID)
);

-- Tạo bảng BillInfo
CREATE TABLE BillInfo (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TotalPrice DECIMAL(10, 2) NULL,
    Price DECIMAL(10, 2) NULL,
    Quantity INT NULL,
    Status NVARCHAR(50) NULL,
    IdProduct INT NULL FOREIGN KEY REFERENCES Product(ID),
    IdBill INT NULL FOREIGN KEY REFERENCES Bill(ID)
);

-- Tạo bảng Employee
CREATE TABLE Employee (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NULL,
    Phone NVARCHAR(20) NULL,
    Username NVARCHAR(50) NULL,
    Password NVARCHAR(255) NULL,
    DateOfBirth DATE NULL,
    IdRole INT NULL FOREIGN KEY REFERENCES UserRole(ID),
);



-- Tạo bảng Product
CREATE TABLE Product (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,       -- Mã sản phẩm
    DisplayName NVARCHAR(100) NOT NULL,             -- Tên sản phẩm
    Price FLOAT NOT NULL,                           -- Giá sản phẩm
    Description NVARCHAR(MAX) NULL,                -- Mô tả sản phẩm
    Quantity INT NULL,                              -- Số lượng sản phẩm
    TotalPricef float ,               -- Thành tiền (tính tự động)
    ProductCategory NVARCHAR(50) NOT NULL,         -- Loại sản phẩm
    SaleDate DATETIME NOT NULL DEFAULT GETDATE(),   -- Ngày bán hàng
    EmployeeID INT NULL FOREIGN KEY REFERENCES Employee(ID) -- Mã nhân viên
);

-- Tạo bảng UserRole
CREATE TABLE UserRole (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    DisplayName NVARCHAR(100) NOT NULL
);

CREATE TABLE BoardingInfo (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã thông tin ký gửi
    OwnerName NVARCHAR(100) NOT NULL,          -- Tên chủ
    Contact NVARCHAR(50) NOT NULL,             -- Số điện thoại chủ
    PetName NVARCHAR(100) NOT NULL,            -- Tên thú cưng
    Quantity INT NOT NULL,                     -- Số lượng
    StartDate DATETIME NOT NULL,               -- Ngày và giờ gửi
    EndDate DATETIME NOT NULL,                 -- Ngày và giờ trả
    Price Float NOT NULL,             -- Giá
    TotalPrice Float ,          -- Thành tiền (Tính tự động)
    EmployeeID INT NULL FOREIGN KEY REFERENCES Employee(ID), -- Mã nhân viên
    CageName NVARCHAR(100) NULL                -- Tên chuồng
);
