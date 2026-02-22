using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    private const string AgedBrie = "Aged Brie";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        this._items = items.Select(item => item).ToList();
    }

    public IReadOnlyCollection<Item> Items => _items.Select(item => item).ToList();

    private bool IsProductWithDecreasedQuality(Item item)
    {
        return item.Name != BackstagePassesToATafkal80EtcConcert;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            item.SellIn = ComputeSellIn(item);
            item.Quality = ComputeQuality(item);
        }
    }

    private int ComputeSellIn(Item item)
    {
        if (item.Name != SulfurasHandOfRagnaros)
        {
            return item.SellIn - 1;
        }

        return item.SellIn;
    }

    private int IncrementQuality(int quality)
    {
        if (quality < 50)
        {
            return quality + 1;
        }

        return quality;
    }

    private int DecrementQuality(int quality)
    {
        if (quality > 0)
        {
            return quality - 1;
        }

        return quality;
    }

    private int ComputeQuality(Item item)
    {
        var quality = item.Quality;

        if (item.Name == SulfurasHandOfRagnaros)
        {
            return item.Quality;
        }

        if (item.Name == AgedBrie)
        {
            quality = IncrementQuality(quality);
            if (item.SellIn < 0) quality = IncrementQuality(quality);
            return quality;
        }

        if (item.Name == BackstagePassesToATafkal80EtcConcert)
        {
            quality = IncrementQuality(quality);
            if (item.SellIn < 10) quality = IncrementQuality(quality);
            if (item.SellIn < 5) quality = IncrementQuality(quality);
            if (item.SellIn < 0) quality = 0;
            return quality;
        }
        quality = DecrementQuality(quality);

        if (item.SellIn < 0)
        {
            quality = DecrementQuality(quality);
        }
        return quality;
    }
}