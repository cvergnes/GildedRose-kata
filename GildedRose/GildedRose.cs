using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    private const string AgedBrie = "Aged Brie";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private readonly List<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items.Select(item => item).ToList();
    }

    public void UpdateQuality()
    {
        _items.Select(GetStrategy).ToList().ForEach(strategy => strategy.UpdateItem());
    }

    private IStrategy GetStrategy(Item item)
    {
        switch (item.Name)
        {
            case AgedBrie:
                return new StrategyAgedBrie(item);
            case BackstagePassesToATafkal80EtcConcert:
                return new StrategyBackstagePassesToATafkal80EtcConcert(item);
            case SulfurasHandOfRagnaros:
                return new StrategySulfurasHandOfRagnaros(item);
            default:
                return new StrategyDefault(item);
        }
    }
}
