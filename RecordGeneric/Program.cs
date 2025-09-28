namespace RecordGeneric
{
    // record class
    public record Student(int Id, string Name, string Department);

    internal class Program
    {
        static void Main(string[] args)
        {
            // instance by record
            Student s1 = new Student(1000, "Russell", "CS");
            Student s2 = new Student(1001, "Tom", "Law");

            // decomposition
            (var id, var name, var department) = s1;

            // display
            Console.WriteLine($"ID = {id}, Name: {name}, Department: {department}");

            // comparison
            Console.WriteLine(s1 == s2);  // false
            Console.WriteLine(s1 == s1);  // true
        }
    }
}
