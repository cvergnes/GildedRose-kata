namespace GildedRoseKata;

public interface IStrategy
{
    void UpdateItem();
}

public class StrategySulfurasHandOfRagnaros(Item _) : IStrategy
{
    public void UpdateItem()
    {
        
    }
}

public class StrategyAgedBrie(Item item) : IStrategy
{
    public void UpdateItem()
    {
        item.SellIn--;
        item.IncrementQuality();
        if (item.SellIn < 0) item.IncrementQuality();
    }
}

public class StrategyBackstagePassesToATafkal80EtcConcert(Item item) : IStrategy
{
    public void UpdateItem()
    {
        item.SellIn--;
        item.IncrementQuality();
        if (item.SellIn < 10) item.IncrementQuality();
        if (item.SellIn < 5) item.IncrementQuality();
        if (item.SellIn < 0) item.Quality = 0;
    }
}

public class StrategyDefault(Item item) : IStrategy
{
    public void UpdateItem()
    {
        item.SellIn--;
        item.DecrementQuality();

        if (item.SellIn < 0)
        {
            item.DecrementQuality();
        }
    }
}

public static class StrategyExtensions
{
    public static void IncrementQuality(this Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }
    
    public static void DecrementQuality(this Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }
    }
}

