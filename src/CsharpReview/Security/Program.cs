using Security;

var connectionString = "Server=.\\SQLEXPRESS;Database=AspnetB9;User Id=aspnetb9;Password=123456;Trust Server Certificate=True;";
AdonetUtility adonetUtility = new AdonetUtility(connectionString);


Console.Write("Your Query:");
var title = Console.ReadLine();

/*
// ' or 1=1;drop table Courses;--
// ' or 1=1;select * from Courses;--
 

var sql = "select * from Courses where title = '"+ title +"'";
var data = adonetUtility.GetData(sql);
*/



var sql = "select * from Courses where title = @title";
var data = adonetUtility.GetData(sql, new Dictionary<string, object>
{
    { "title", title }
});


if (data is not null)
{
    foreach (var row in data)
    {
        foreach (var col in row)
        {
            Console.Write(col);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}