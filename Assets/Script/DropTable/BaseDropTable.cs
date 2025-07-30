using System.Collections.Generic;

public abstract class BaseDropTable
{
    public float weight;
}

public static class DropTableExtensions
{
    public static bool TryGetDropTable<T>(this List<T> tables, out T selected) where T : BaseDropTable
    {
        selected = null;
        
        float totalWeight = 0f;
        foreach (var table in tables)
            totalWeight += table.weight;

        if (totalWeight <= 0f)
            return false;

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float accumulatedWeight = 0f;

        foreach (var table in tables)
        {
            accumulatedWeight += table.weight;
            if (randomValue <= accumulatedWeight)
            {
                selected = table;
                return true;
            }
        }

        return false;
    }
}