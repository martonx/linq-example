namespace CandyStat;

public static class FileService
{
    public static async Task<List<Candy>> ReadCandiesAsync()
    {
        var lines = await File.ReadAllLinesAsync("candies.csv");
        var candies = new List<Candy>();
        foreach (var line in lines.Skip(1))
        {
            var candyProperties = line.Split(',');
            var id = int.Parse(candyProperties[0]);
            var name = candyProperties[1];
            var quantity = int.Parse(candyProperties[2]);
            var unitPrice = int.Parse(candyProperties[3]);
            candies.Add(new Candy(id, name, quantity, unitPrice));
        }

        return candies;
    }
}
