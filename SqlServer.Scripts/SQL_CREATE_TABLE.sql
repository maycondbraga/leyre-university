-- Create the Database
USE MASTER
CREATE DATABASE DB_USER

-- Create the Tables
USE DB_USER
GO

CREATE TABLE TB_COURSE
(
ID_COURSE INT PRIMARY KEY NOT NULL,
DS_TITLE VARCHAR(50) NULL,
NR_CREDITS INT NULL
)

CREATE TABLE TB_ENROLLMENT
(
ID_ENROLLMENT INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
ID_COURSE INT NULL,
ID_STUDENT INT NULL,
DS_GRADE CHAR(1) NULL
)

CREATE TABLE TB_STUDENT
(
ID_STUDENT INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
DS_FIRST_MID_NAME VARCHAR(50) NULL,
DS_LAST_NAME VARCHAR(50) NULL,
DT_ENROLLMENT DATETIME2(7) NULL
)

ALTER TABLE TB_ENROLLMENT
ADD CONSTRAINT FK_ENROLLMENT_COURSE
FOREIGN KEY (ID_COURSE) REFERENCES TB_COURSE(ID_COURSE)

ALTER TABLE TB_ENROLLMENT
ADD CONSTRAINT FK_ENROLLMENT_STUDENT
FOREIGN KEY (ID_STUDENT) REFERENCES TB_STUDENT(ID_STUDENT)