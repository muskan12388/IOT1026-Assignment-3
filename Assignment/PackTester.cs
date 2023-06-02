namespace Assignment;

static class PackTester
{
    public static void AddEquipment(Pack pack)
    {
        bool addMoreItems = true;
        do
        {
            Console.WriteLine(pack);
            //asking item to add
            //user will have to say any number inbetween the given range

            Console.WriteLine("Select any number reflected to the item you want to add?");
            Console.WriteLine("1 - Arrow");
            Console.WriteLine("2 - Bow");
            Console.WriteLine("3 - Rope");
            Console.WriteLine("4 - Water");
            Console.WriteLine("5 - Food");
            Console.WriteLine("6 - Sword");
            Console.WriteLine("7 - Put all of your items packed and go.");

            try
            {
                //Read the user's input and convert it to an integer

                int choice = Convert.ToInt32(Console.ReadLine());


                // Create a new InventoryItem based on the user's choice
                // using a switch statement
                InventoryItem value2 = GetValue2(choice);
                InventoryItem value1 = value2;
                InventoryItem value = value1;
                InventoryItem newItem = value;

                // Check if the item can be added to the pack
                if (!pack.Add(newItem))
                {
                    Console.WriteLine("This item wouldn't fit in the pack.");
                }
            }


            catch (FormatException)
            {
                Console.WriteLine("Invalid selection. Please enter a valid number.");
            }

            
            // If the user enters an int that is not covered by our switch statement
            // we break out of the loop (good design choice?)

            catch (System.Runtime.CompilerServices.SwitchExpressionException)
            {
                Console.WriteLine("Moving forward!");
                addMoreItems = false;
            }
            
        } while (addMoreItems);

        static InventoryItem GetValue2(int choice)
        {
            return choice switch
            {
                1 => new Arrow(),// Create an instance of the Arrow class
                2 => new Bow(), // Create an instance of the Bow class
                3 => new Rope(), // Create an instance of the rope class
                4 => new Water(), // Create an instance of the water class
                5 => new Food(), // Create an instance of the food class
                6 => new Sword(),  // Create an instance of the sword class
                _ => throw new ArgumentException("Invalid choice") // Default case
            };
        }
    }
}