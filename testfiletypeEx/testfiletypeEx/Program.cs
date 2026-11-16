// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//here i declare class as a public
public class program()
{
    //now i will declare variable as private.
    //private access modifier is used to work on same class only,
    //it restrict the access where another is trying to get the value.
    private string name = "Sreenu Redyy Y";

    //here i declare static method.
    public string Displayname()
    {
        return name;
    }

    //here i am declaring the method as return type as well as static method.
    public static string Displayname1()
    {
        //Console.WriteLine("Hello World!");
        return "Hello World!";
    }
    //public static void Main(string[] args)
    //{
    //    //here inside same class private class is not working,
    //    //because object reference is required for not-static field,properties or methods.
    //    //Console.WriteLine(name);

    //    //to overcome the error we need to create the object.
    //    program p = new program();
    //    Console.WriteLine(p.name);
    //    Console.WriteLine();
    //    Console.WriteLine(p.Displayname());
    //    //here we doesn't required obj because it is a static method.
    //    Console.WriteLine(program.Displayname1());
    //    Console.ReadLine();
    //}
}

//here i am trying to check the protected access modifier protection level.
public class Test()
{
    protected string Department = "Sreenu";

    //here i am creating the not return type method.
    public void DisplayDepartment()
    {
        Console.WriteLine(Department);
    }
}
//here in this same project i am creating the another to access the private value from the above class.
internal class Class1 : Test
{
    //program obj = new program();

    static void Main(string[] args)
    {
        program obj = new program();
        //here we cannot acces the private variable directly,
        //because it thrown error like protection level.
        //Console.WriteLine(obj.name);
        Console.WriteLine(obj.Displayname());

        Console.WriteLine("==========================================================");
        Class1 obj2 = new Class1();
        Console.WriteLine(obj2.Department);
        Console.WriteLine("-------------");
        obj2.DisplayDepartment();

        Console.ReadLine();
    }
}
