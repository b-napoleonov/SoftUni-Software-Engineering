BACKUP DATABASE SoftUni
TO DISK = 'C:\Users\Blago\Desktop\SoftUni_Courses\C# MS SQL\4_Databases Introduction_Exercise\Databases Introduction - Ex\SoftUni.bak'
DROP DATABASE SoftUni
RESTORE DATABASE SoftUni FROM DISK = 'C:\Users\Blago\Desktop\SoftUni_Courses\C# MS SQL\4_Databases Introduction_Exercise\Databases Introduction - Ex\SoftUni.bak'