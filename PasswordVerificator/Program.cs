namespace PasswordValidator
{
    // 1. Create a password verification class
    // 2. Condition 1: length within 6 and 13
    // 3. Condition 2: contain atleast 1 lower and 1 upper case
    // 4. Condition 3: no T and & character

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while(true)
                {
                    Console.WriteLine("=== PASSWORD VERIFICATOR ===");
                    Console.Write("Please enter your password: ");
                    string password = Console.ReadLine();

                    if (password == "exit") break;

                    PasswordValidator pv = new PasswordValidator(password);
                    if (pv.IsPasswordValid())
                        Console.WriteLine("Your password is valid");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class PasswordValidator
    {
        public string Password { get; private set; }
        public PasswordValidator(string password)
        {
            Password = password;
        }

        public bool IsPasswordValid()
        {
            if (string.IsNullOrEmpty(Password))
            {
                Console.WriteLine("Password can't be blank");
                return false;
            }
            if (!IsLengthValid())
            {
                if (Password.Length < 6)
                    Console.WriteLine("Password length need atleast 6 letters");
                if (Password.Length > 13)
                    Console.WriteLine("Passowrd length needs atmost 13 letters");
                return false;
            }
            if (!IsAtleastLowerCase()) 
            {
                Console.WriteLine("Password needs at least one lower case");
                return false;
            }
            if (!IsAtleastUpperCase())
            {
                Console.WriteLine("Password needs at least one upper case");
                return false;
            }
            if (!IsAtleastDigit())
            {
                Console.WriteLine("Password needs at least one digit");
                return false;
            }
            if (IsHasAmpersand())
            {
                Console.WriteLine("Password can't have Ampersand");
                return false;
            }
            if (IsHasLetterT())
            {
                Console.WriteLine("Password can't have T letter");
                return false;
            }
            return true;
        }

        bool IsLengthValid()
        {
            return Password.Length >= 6 && Password.Length <= 13;
        }

        bool IsAtleastUpperCase()
        {
            return Password.Any(char.IsUpper);
        }

        bool IsAtleastLowerCase()
        {
            return Password.Any (char.IsLower);
        }

        bool IsAtleastDigit()
        {
            return Password.Any(char.IsDigit);
        }

        bool IsHasLetterT()
        {
            return Password.Contains('T');
        }

        bool IsHasAmpersand()
        {
            return Password.Contains('&');
        }
    }
}
