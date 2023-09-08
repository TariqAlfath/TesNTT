CREATE DATABASE NTTTest;
USE NTTTest;
CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Salary INT
);

INSERT INTO Employee (ID, Name, Salary)
VALUES
    (1001, 'Robert', 75000),
    (1002, 'Andy', 80000),
    (1003, 'William', 65000),
    (1004, 'Faisal', 60000),
    (1005, 'Jerry', 75000);


SELECT TOP 2 a.ID,a.[Name],a.Salary  FROM Employee a where a.ID != (select top 1 b.ID from Employee b order by b.Salary DESC) ORDER BY a.Salary desc

