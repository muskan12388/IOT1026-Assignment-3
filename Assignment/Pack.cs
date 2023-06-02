namespace Assignment;

public class Pack
{
        private readonly List<InventoryItem> _items;  // List to store the inventory items

    private readonly int _maxCount;  // Maximum count of items allowed in the pack
    private readonly float _maxVolume; // Maximum volume allowed in the pack
    private readonly float _maxWeight; // Maximum weight allowed in the pack

    private float _currentVolume; // Current volume occupied in the pack
    private float _currentWeight; // Current weight occupied in the pack

    public float EPSILON { get; private set; } // A small value used for comparison

   
    public Pack() : this(10, 20, 30) { }  // Default constructor with default pack constraints

    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        if (maxCount < 0 || maxVolume < EPSILON || maxWeight < EPSILON)
        {
            throw new ArgumentOutOfRangeException($"An item can't have {maxCount} max count,  {maxVolume} maxvolume or {maxWeight} max weight");
        }
        _maxCount = maxCount;
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
        _items = new List<InventoryItem>(); // Initialize the list of items
        _currentVolume = 0f; // Initialize the current volume as 0
        _currentWeight = 0f; // Initialize the current weight as 0
    }

  
    public int GetMaxCount()
    {
        return _maxCount; // Return the maximum count of items allowed in the pack
    }

 
    public bool Add(InventoryItem item)
    {
        
        if (GetCurrentItemsCount() >= _maxCount)
        {
            Console.WriteLine("Cannot more items now because the array already put the maximum count of items into it.");
            return false;
        }

        float weight = item.GetWeight();
        float volume = item.GetVolume();
        _currentWeight += weight;
        _currentVolume += volume;

        
        if (_currentWeight > _maxWeight || _currentVolume > _maxVolume)
        {
            Console.WriteLine($"Cannot add this item:{item.GetName} because it will over max weight or max volume.");
            return false; // Unable to add item due to maximum count constraint
        }
        _items.Add(item); 
        return true;
    }

  
    public override string ToString()
    {
        return ($"Pack is currently at {GetCurrentItemsCount()}/{_maxCount} items, {_currentWeight}/{_maxWeight} weight, and {_currentVolume}/{_maxVolume} volume");
    }

   
    private int GetCurrentItemsCount()
    {
        return _items.Count;
    }
}


public class InventoryItem
{
    private readonly string _name;
    private readonly float _volume;
    private readonly float _weight;

    public InventoryItem(string name, float volume, float weight)
    {
        if (NewMethod(volume) || NewMethod1(weight))
        {
            throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException($"An item can't have empty name.");
        }
        _name = name;
        _volume = volume;
        _weight = weight;

        static bool NewMethod(float volume)
        {
            return volume <= 0f;
        }

        static bool NewMethod1(float weight)
        {
            return weight <= 0f;
        }
    }


    public float GetVolume()
    {
        return _volume;
    }

   
    public float GetWeight() // Get the weight of the item
    {
        return _weight;
    }

    
    public string GetName() // Name of the item
    {
        return _name;
    }
}


public class Arrow : InventoryItem 
{
    public Arrow() : base("Arrow", 0.05f, 0.1f) { }


    public Arrow(float volume, float weight) : base("Arrow", volume, weight) { }
}

public class Bow : InventoryItem
{
    public Bow() : base("Bow", 1f, 4f) { }
}

public class Rope : InventoryItem
{
    public Rope() : base("Rope", 1f, 1.5f) { }
}

public class Water : InventoryItem
{
    public Water() : base("Water", 2f, 3f) { }
}

public class Food : InventoryItem
{
    public Food() : base("Food", 1f, 0.5f) { }
}

public class Sword : InventoryItem
{
    public Sword() : base("Sword", 5f, 3f) { }
}