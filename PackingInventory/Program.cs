namespace PackingInventory
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public InventoryItem(string name, double weight, double volume)
        {
            this.Name = name;
            this.Weight = weight;
            this.Volume = volume;
        }
    }

    // Arrow: Trọng lượng 0.1, Thể tích 0.05.
    public class Arrow : InventoryItem
    {
        public Arrow() : base("Arrow", 0.1, 0.05)
        { }
    }

    // Bow: Trọng lượng 1, Thể tích 4.
    public class Bow : InventoryItem
    {
        public Bow() : base("Bow", 1, 4)
        { }
    }

    // Rope: Trọng lượng 1, Thể tích 1.5.
    public class Rope : InventoryItem
    {
        public Rope() : base("Rope", 1, 1.5)
        { }
    }

    // Water: Trọng lượng 2, Thể tích 3.
    public class Water : InventoryItem
    {
        public Water() : base("Water", 2, 3)
        { }
    }

    // Food: Trọng lượng 1, Thể tích 0.5.
    public class Food : InventoryItem
    {
        public Food() : base("Food", 1, 0.5)
        { }
    }

    // Sword: Trọng lượng 5, Thể tích 3.
    public class Sword : InventoryItem
    {
        public Sword() : base("Sword", 5, 3)
        { }
    }

    public class Pack
    {
        public List<InventoryItem> Items { get; set; }
        public int MaxItem { get; }
        public int MaxWeight { get; }
        public int MaxVolume { get; }

        public int CurrentItemCount => Items.Count;
        public double CurrentWeight { get => Items.Sum(item => item.Weight); }
        public double CurrentVolume { get => Items.Sum(item => item.Volume); }

        public Pack(int maxItem, int maxWeight, int maxVolume)
        {
            MaxItem = maxItem;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            Items = new List<InventoryItem>();
        }

        public void AddItem(int itemType)
        {
            InventoryItem temp;
            switch (itemType)
            {
                case 1: // Arrow
                    temp = new Arrow();
                    if (IsAddPossibility(temp))
                    {
                        Items.Add(temp);
                        DisplayCurrentStatus();
                    }
                    else
                        Console.WriteLine("Can't add this Arrow (0.1, 0.05)");
                    break;
                case 2: // Bow
                    temp = new Bow();
                    if (IsAddPossibility(temp))
                    {
                        Items.Add(temp);
                        DisplayCurrentStatus();
                    }
                    else
                        Console.WriteLine("Can't add this Bow (1, 4)");
                    break;
                case 3: // Rope
                    temp = new Rope();
                    if (IsAddPossibility(temp))
                    {
                        Items.Add(temp);
                        DisplayCurrentStatus();
                    }
                    else
                        Console.WriteLine("Can't add this Rope (1, 1.5)");
                    break;
                case 4: // Water
                    temp = new Water();
                    if (IsAddPossibility(temp))
                    {
                        Items.Add(temp);
                        DisplayCurrentStatus();
                    }
                    else
                        Console.WriteLine("Can't add this Water (2, 3)");
                    break;
                case 5: // Food
                    temp = new Food();
                    if (IsAddPossibility(temp))
                    {
                        Items.Add(temp);
                        DisplayCurrentStatus();
                    }
                    else
                        Console.WriteLine("Can't add this Food (1, 0.5)");
                    break;
                case 6: // Sword
                    temp = new Sword();
                    if (IsAddPossibility(temp))
                    {
                        Items.Add(temp);
                        DisplayCurrentStatus();
                    }
                    else
                        Console.WriteLine("Can't add this Sword (5, 3)");
                    break;
                case 7:
                    DisplayDetailedItems();
                    break;
            }
        }

        public bool IsAddPossibility(InventoryItem item)
        {
            if (CurrentItemCount >= MaxItem) return false;
            else if (item.Weight + CurrentWeight > MaxWeight) return false;
            else if (item.Volume + CurrentVolume > MaxVolume) return false;
            return true;
        }

        public void DisplayCurrentStatus()
        {
            Console.WriteLine("Quantity - ItemType - Weight - Volume");
            Console.WriteLine($"  {CurrentItemCount}/{MaxItem}      {CurrentWeight}/{MaxWeight}       {CurrentVolume}/{MaxVolume}");
        }

        public void DisplayDetailedItems()
        {
            int idx = 0;
            Console.WriteLine("Quantity - Weight - Volume");

            foreach (InventoryItem item in Items)
            {
                idx++;
                Console.WriteLine($"{idx}  {item.Name}   {item.Weight}     {item.Volume}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== PACKING INVENTORY ===");

                //1. Pack class (max item, max weight, max volume)
                Pack pack = new Pack(5, 10, 10);

                //2. Add item to the Pack
                Console.WriteLine("1. Arrow");
                Console.WriteLine("2. Bow");
                Console.WriteLine("3. Rope");
                Console.WriteLine("4. Water");
                Console.WriteLine("5. Food");
                Console.WriteLine("6. Sword");
                Console.WriteLine("7. Display detailed items");
                Console.WriteLine("0. Exit");
                while (true)
                {
                    Console.Write("Please select what item to add: ");

                    if (!Int32.TryParse(Console.ReadLine(), out int item))
                    {
                        Console.WriteLine("Please enter a number.");
                        continue;
                    }

                    if (item == 0) break;

                    pack.AddItem(item);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}