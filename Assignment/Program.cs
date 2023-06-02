using System;

namespace Assignment
{
    static class Program
    {
        static void Main()
        {
           // Define the maximum capacity of the pack
            const int PackMaxItems = 10; // Maximum number of items the pack can hold
            const float PackMaxVolume = 20; // Maximum volume the pack can hold
            const float PackMaxWeight = 30;  // Maximum weight the pack can hold

            // Create a new pack with the specified maximum capacity
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            // Call the method to add equipment to the pack
            PackTester.AddEquipment(pack);
        }
    }
}