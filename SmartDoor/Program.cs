namespace SmartDoor
{
    //1. Define three status
    public enum STATE
    {
        Opened,
        Closed,
        Locked
    };

    public class Door
    {
        public STATE CurrentState { get; set; }
        public string CurrentPassword { get; private set; }

        public Door(string initialPass, STATE state)
        {
            CurrentState = state;
            CurrentPassword = initialPass;
        }

        public void Open()
        {
            if (CurrentState == STATE.Closed)
            {
                Console.WriteLine("Door is opened");
                CurrentState = STATE.Opened;
            }
            else if (CurrentState == STATE.Locked)
            {
                Console.WriteLine("Can't open: Door is locked");
            }
            else
            {
                Console.WriteLine("Door is already open.");
            }
        }

        public void Close()
        {
            if (CurrentState == STATE.Opened)
            {
                Console.WriteLine("Door is closed");
                CurrentState = STATE.Closed;
            }
            else
            {
                Console.WriteLine("Can't close");
            }
        }

        public void Lock()
        {
            if (CurrentState == STATE.Closed)
            {
                Console.WriteLine("Door is locked.");
                CurrentState = STATE.Locked;
            }
            else
            {
                Console.WriteLine("Can't lock");
            }
        }

        public void Unlock(string passcode)
        {
            if (CurrentState == STATE.Locked && VerifyPassword(CurrentPassword, passcode))
            {
                Console.WriteLine("Door is unlock");
                CurrentState = STATE.Closed;
            }
            else
            {
                Console.WriteLine("Can't unlock");
            }
        }

        // Verify the current password
        public bool VerifyPassword(string current, string newpw)
        {
            if (string.IsNullOrEmpty(newpw) || string.IsNullOrEmpty(current))
                return false;
            else if (current == newpw)
                return true;
            else return false;
        }

        public bool ChangePassword()
        {
            Console.Write("Please enter current password: ");
            string currentpw = Console.ReadLine();
            if (VerifyPassword(CurrentPassword, currentpw))
            {
                Console.Write("Please enter new password: ");
                string newPassword = Console.ReadLine();
                CurrentPassword = newPassword;
                return true;
            }
            else
            {
                Console.WriteLine("Change password failed.");
                return false;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Door door = new Door("123456", STATE.Opened);

                while (true)
                {
                    Console.WriteLine("===== SMART DOOR =====");
                    Console.WriteLine("1. Open");
                    Console.WriteLine("2. Close");
                    Console.WriteLine("3. Lock");
                    Console.WriteLine("4. Unlock");
                    Console.WriteLine("5. Change password");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("Current State: " + door.CurrentState);

                    Console.Write("Please enter an option: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int option))
                    {
                        Console.WriteLine("Please enter value in 0 - 5");
                        continue;
                    }

                    if (option == 0) break;

                    // check action
                    switch (option)
                    {
                        case 1: // Open
                            door.Open();
                            break;
                        case 2: // Close
                            door.Close();
                            break;
                        case 3: // Lock
                            door.Lock();
                            break;
                        case 4: // Unlock
                            Console.Write("Please enter the password: ");
                            string passcode = Console.ReadLine();
                            door.Unlock(passcode);
                            break;
                        case 5: // Change password
                            door.ChangePassword();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
