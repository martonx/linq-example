using CandyStat;

var candies = await FileService.ReadCandiesAsync();
var distinctedCandies = candies.DistinctBy(candy => candy.Id);

Console.WriteLine($"Összesen mennyi féle cukorkánk van? {distinctedCandies.Count()}");
Console.WriteLine($"Összesen mennyi értékben van cukorkánk? {candies.Sum(candy => candy.StockValue)}");

var cheapestCandy = distinctedCandies.MinBy(candy => candy.UnitPrice);
Console.WriteLine($"Melyik a legolcsóbb cukorka? {cheapestCandy.Name} {cheapestCandy.UnitPrice}");

var mostExpansiveCandy = distinctedCandies.MaxBy(candy => candy.UnitPrice);
Console.WriteLine($"Melyik a legdrágább cukorka? {mostExpansiveCandy.Name} {mostExpansiveCandy.UnitPrice}");

/*
 * 1,Cukor 1,100,299 - 29900
 * 1,Cukor 1,100,299 - 29900 - 59800
 * 2,Cukor 2,200,199 - 39800 - 39800
 */

var groupedCandies = candies.GroupBy(candy => candy.Id);
var summedCandiesByStockValue = groupedCandies.Select(group => new
{
    Id = group.Key,
    SummedStockValue = group.Sum(c => c.StockValue)
});
var lowestStockValue = summedCandiesByStockValue.MinBy(candy => candy.SummedStockValue);
var lowestStockValueCandy = distinctedCandies.Single(candy => candy.Id == lowestStockValue.Id);
Console.WriteLine($"Melyikből van a legkevesebb értékű készletünk? {lowestStockValueCandy.Name} {lowestStockValueCandy.StockValue}");

var highestStockValue = summedCandiesByStockValue.MaxBy(candy => candy.SummedStockValue);
var highestStockValueCandy = distinctedCandies.Single(candy => candy.Id == highestStockValue.Id);
Console.WriteLine($"Melyikből van a legtöbb értékű készletünk? {highestStockValueCandy.Name} {highestStockValueCandy.StockValue}");

var countedCandies = groupedCandies.Select(group => new
{
    Id = group.Key,
    Length = group.Count()
});
var mostFrequentCandyGroup = countedCandies.MaxBy(candy => candy.Length);
var mostFrequentCandy = distinctedCandies.Single(candy => candy.Id == mostFrequentCandyGroup.Id);
Console.WriteLine($"Melyik cukorka fordul elő a legtöbb sorban? {mostFrequentCandy.Name} {mostFrequentCandyGroup.Length}");
