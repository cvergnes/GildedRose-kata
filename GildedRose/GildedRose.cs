using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    public const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    public const string AgedBrie = "Aged Brie";
    public const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        this._items = items.Select(item => item).ToList();
    }
    
    public IReadOnlyCollection<Item> Items => _items.Select(item => item).ToList();

    private bool IsProductWithDecreasedQuality(Item item)
    {
        return item.Name != AgedBrie && item.Name != BackstagePassesToATafkal80EtcConcert ;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            _items[i].SellIn = ComputeSellIn(_items[i]);
            _items[i].Quality = ComputeQuality(_items[i]);
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

    private int ComputeQuality(Item item)
    {
        var quality = item.Quality;
        if (item.Name != AgedBrie && item.Name != BackstagePassesToATafkal80EtcConcert)
        {
            if (quality > 0)
            {
                if (item.Name != SulfurasHandOfRagnaros)
                {
                    quality -= 1;
                }
            }
        }
        else
        {
            if (quality < 50)
            {
                quality +=  1;
                if (item.Name == BackstagePassesToATafkal80EtcConcert)
                {
                    if (item.SellIn < 10)
                    {
                        if (quality< 50)
                        {
                            quality+= 1;
                        }
                    }

                    if (item.SellIn < 5)
                    {
                        if (quality < 50)
                        {
                            quality += 1;
                        }
                    }
                }
            }
        }
        
        if (item.SellIn < 0)
        {
            if (item.Name != AgedBrie)
            {
                if (item.Name != BackstagePassesToATafkal80EtcConcert)
                {
                    if (quality > 0)
                    {
                        if (item.Name != SulfurasHandOfRagnaros)
                        {
                            quality -= 1;
                        }
                    }
                }
                else
                {
                    quality -= quality;
                }
            }
            else
            {
                if (quality < 50)
                {
                    quality += 1;
                }
            }
        }

        return quality;
    }
}