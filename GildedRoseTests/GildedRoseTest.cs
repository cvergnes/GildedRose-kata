using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GildedRoseKata;
using VerifyTests;
using VerifyXunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    
    [Theory]
    [InlineData("+5 Dexterity Vest", 10, 20)]    
    [InlineData("Aged Brie", 2, 0)]
    [InlineData("Elixir of the Mongoose", 5, 7)]
    [InlineData("Sulfuras, Hand of Ragnaros", 0, 80)]
    [InlineData("Sulfuras, Hand of Ragnaros", -1, 80)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 49)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 49)]
    [InlineData("Conjured Mana Cake", 3, 6)]
    public Task GivenItem_WhenUpdateQualityTenTimes_ShouldMatchSnapshot(string itemName, int sellIn, int quality)
    {
        IList<Item> Items = new List<Item> { new Item {Name = itemName, SellIn = sellIn, Quality = quality} };
        GildedRose app = new GildedRose(Items);
        Enumerable.Range(0, 30).ToList().ForEach(_ => app.UpdateQuality());
        return Verifier.Verify(Items).UseParameters(Items.First().ToString());
    }
}