namespace OldRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THE OLD ROBOT ===");
            Console.WriteLine("Create a list of robot commands");

            

            // create a Robot
            Robot robot = new Robot();

            robot.Commands.Add(new OnCommand());
            robot.Commands.Add(new NorthCommand());
            robot.Commands.Add(new WestCommand());

            robot.Run();
        }
    }

    public class Robot
    {
        public int X { get; set; } = 10;
        public int Y { get; set; } = 10;
        public bool IsPowered { get; set; }
        public List<RobotCommand> Commands { get; } = new List<RobotCommand>();
        public void Run()
        {
            foreach (var command in Commands)
            {
                command.Run(this);
                Console.WriteLine($"[{X} {Y} {(IsPowered ? "ON" : "OFF")}]");
            }
        }
    }

    // base class
    public abstract class RobotCommand
    {
        public abstract void Run(Robot robot);
    }

    // inherited classes
    public class OnCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (!robot.IsPowered)
            {
                robot.IsPowered = true;
                //Console.WriteLine("Robot is ON now.");
            }
        }
    }

    public class OffCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.IsPowered = false;
                //Console.WriteLine("Robot is OFF now.");
            }
        }
    }

    public class NorthCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.Y -= 1;
                //Console.WriteLine("Move to NORTH.");
            }
        }
    }

    public class SouthCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.Y += 1;
                //Console.WriteLine("Move to SOUTH.");
            }
        }
    }

    public class WestCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X -= 1;
                //Console.WriteLine("Move to WEST.");
            }
        }
    }

    public class EastCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X += 1;
                //Console.WriteLine("Move to EAST.");
            }
        }
    }
}
