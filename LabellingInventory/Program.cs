using System.Text.RegularExpressions;

namespace LabellingInventory
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }

        public InventoryItem(string name, double weight, double volume)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
        }

    }

    public class Arrow : InventoryItem
    {
        public Arrow() : base("Arrow",1, 0.05) { }

        public override string ToString() => Name;
    }

    public class Bow : InventoryItem
    {
        public Bow() : base("Bow", 1, 4) { }

        public override string ToString() => Name;
    }

    public class Rope : InventoryItem
    {
        public Rope() : base("Rope", 0.1, 1) { }
        public override string ToString()=>Name;
    }

    public class Water : InventoryItem
    {
        public Water() : base("Water", 2, 3) { }
        public override string ToString() => Name;
    }

    public class Food : InventoryItem
    {
        public Food() : base("Food", 1, 0.5) { }
        public override string ToString() => Name;
    }

    public class Sword : InventoryItem
    {
        public Sword() : base("Sword", 5, 3) { }
        public override string ToString() => Name;
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
            InventoryItem temp = null;
            switch (itemType)
            {
                case 1: temp = new Arrow(); break;
                case 2: temp = new Bow(); break;
                case 3: temp = new Rope(); break;
                case 4: temp = new Water(); break;
                case 5: temp = new Food(); break;
                case 6: temp = new Sword(); break;
                case 7:
                    DisplayDetailedItems();
                    break;
                case 8:
                    Console.WriteLine(this.ToString());
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select between 0-7.");
                    return;
            }
            if (IsAddPossibility(temp))
            {
                Items.Add(temp);
                DisplayCurrentStatus();
            }
            else
            {
                Console.WriteLine($"Can't add this {temp.Name} ({temp.Weight}, {temp.Volume})");
            }
        }

        public bool IsAddPossibility(InventoryItem item)
        {
            if (item == null) return false;
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
                Console.WriteLine($"{idx}  {item.ToString()}   {item.Weight}     {item.Volume}");
            }
        }

        public override string ToString()
        {
            if (Items.Count == 0) return "Pack contains nothing";
            var distinctItems = Items.Select(item => item.ToString()).Distinct();
            return "Pack containing " + string.Join(" ", distinctItems);
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
                Console.WriteLine("8. Distinct items in pack");
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
