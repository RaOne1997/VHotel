// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;
using timmer;

var clas = new List<Class1>();


clas.Add(new Class1 { ID = 10, Name = "Abhi" });
clas.Add(new Class1 { ID = 11, Name = "Abhi" });
clas.Add(new Class1 { ID = 12, Name = "Abhi" });
clas.Add(new Class1 { ID = 13, Name = "Abhi" });

Console.WriteLine("before remove");
clas.ForEach(x => Console.WriteLine(x.ID + "" + x.Name));


 clas.RemoveAt(0);


Console.WriteLine("after remove");
clas.ForEach(x => Console.WriteLine(x.ID+"" +  x.Name));

//Console.WriteLine(and.ID +"   "+and.Name);
