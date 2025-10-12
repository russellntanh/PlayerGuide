namespace Advanced_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write and Read to/from File");

            // Create data
            List<Student> students = new List<Student>()
            {
                new Student("20250501", "Russell Nguyen", 80),
                new Student("20250502", "Tom Pham", 90),
                new Student("20250503", "Tony Nguyen", 50),
                new Student("20250504", "Lamine Nguyen", 80),
                new Student("20250505", "Jason Duong", 75),
            };

            // Convert data to string
            string allStudents = "This file contains all students.";
            string contents = String.Empty;

            foreach (Student student in students)
            {
                contents += student.Id + "," + student.Name + "," + student.score + "\n";
            }

            // WriteAllFile
            File.WriteAllText("D:\\students-write.txt", contents);


            // ReadAllFile
            string readFromFile = File.ReadAllText("D:\\students-read.txt");
        }
    }

    public record Student(string Id, string Name, int score);

}
