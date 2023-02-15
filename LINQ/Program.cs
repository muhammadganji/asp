using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

// :::::: Set Of List via LINQ ::::::::

Main();

void Main()
{

    IList<string> data = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "6", "6", "6" };
    IList<string> data2 = new List<string>() { "4", "5", "6", "7", "10", "12", "6", "6", "3" };

    var dataDistinc = data.Distinct();
    Console.WriteLine("________________Distinct_______________");

    foreach (var item in dataDistinc)
    {
        Console.WriteLine(item);
    }


    Console.WriteLine("_______________Except______________");
    var dataExcept = data.Except(data2);

    foreach (var item in dataExcept)
    {
        Console.WriteLine(item);
    }


    Console.WriteLine("_______________Intersect______________");
    var dataIntersect = data.Intersect(data2);

    foreach (var item in dataIntersect)
    {
        Console.WriteLine(item);
    }


    Console.WriteLine("______________Union_____________");
    var dataUnion = data.Union(data2);

    foreach (var item in dataUnion)
    {
        Console.WriteLine(item);
    }


    Console.WriteLine("______________Concat_____________");
    var dataConcat = data.Concat(data2);

    foreach (var item in dataConcat)
    {
        Console.WriteLine(item);
    }


    // :::::::: Set of Object via LINQ :::::::::

    List<User> users = new List<User>()
            {
                 new User { Name = "Ehsan"},
                 new User { Name = "Maysam"},
                 new User { Name = "Nader"},
                 new User { Name = "Sadegh"},
                 new User { Name = "Ehsan"},
            };

    List<User> user2 = new List<User>()
            {
                 new User { Name = "Ehsan"},
                 new User { Name = "Maysam"},
                 new User { Name = "Nahid"},
                 new User { Name = "Elham"},
                 new User { Name = "Samira"},
                 new User { Name = "negin"},
            };


    var userDistinc = users.Distinct(new userComparer()).ToList();

    foreach (var item in userDistinc)
    {
        Console.WriteLine(item.Name);

    }

    Console.WriteLine("_______________Except______________");

    var userExcept = users.Except(user2, new userComparer());

    foreach (var item in userExcept)
    {
        Console.WriteLine(item.Name);

    }


    Console.WriteLine("_______________Intersect______________");

    var userIntersect = users.Intersect(user2, new userComparer());

    foreach (var item in userIntersect)
    {
        Console.WriteLine(item.Name);

    }

    Console.WriteLine("______________Union______________");

    var userUnion = users.Union(user2, new userComparer());

    foreach (var item in userUnion)
    {
        Console.WriteLine(item.Name);

    }


    Console.WriteLine("______________Union______________");

    var userConcat = users.Concat(user2);

    foreach (var item in userConcat)
    {
        Console.WriteLine(item.Name);

    }


    Console.ReadLine();
}
    

    public class User
{
    public string Name { get; set; }
}

public class userComparer : IEqualityComparer<User>
{
    public bool Equals([AllowNull] User x, [AllowNull] User y)
    {
        if (x.Name == y.Name)
            return true;


        return false;
    }

    public int GetHashCode([DisallowNull] User obj)
    {
        return obj.Name.GetHashCode();
    }
}