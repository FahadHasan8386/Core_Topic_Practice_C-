using ADO.NET;

var sql = "insert into student ([Name] , Cgpa , InActive , DateOfBirth) values('Hasan' , 3.44 , 0 , '2002-01-04')";


SqlUtility sqlUtility = new SqlUtility();
sqlUtility.ExcuteSql(sql);

Console.WriteLine("Complete");