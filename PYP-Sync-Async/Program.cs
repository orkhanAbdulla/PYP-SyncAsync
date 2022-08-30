using System.ComponentModel;
using System.Diagnostics;

List<string> list = new List<string>() { "https://medium.com/", "https://medium.com/swlh/introduction-to-javascript-basics-cf901c05ca47", "https://medium.com/tag/cpp", "https://medium.com/tag/java" };


await ReadWebSiteAsync();
await GetWebSiteAsync();

async Task ReadWebSiteAsync()
{
    var totalTime = new Stopwatch();
    totalTime.Start();
    HttpClient client = new HttpClient();
	foreach (var item in list)
	{
        var time = new Stopwatch();
        time.Start();
        var content=await client.GetStringAsync(item);
        time.Stop();
        Console.WriteLine($"WebSite{item},Line:{content.Length} Timer:{time.ElapsedMilliseconds}");
    }
    totalTime.Stop();
    Console.WriteLine($"All time:{totalTime.ElapsedMilliseconds}");
    Console.WriteLine(new String('-', 50));
}
async Task GetWebSiteAsync()
{
    
    List<Task<string>> tasks = new List<Task<string>>();
    var totalTime = new Stopwatch();
    totalTime.Start();
    foreach (var item in list)
    {
        HttpClient client = new HttpClient();
        tasks.Add(client.GetStringAsync(item));
    }
    await Task.WhenAll(tasks);
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"WebSite:{list[i]},Line:{tasks[i].Result.Length}");
    }
    totalTime.Stop();
    Console.WriteLine($"AllTime{totalTime.ElapsedMilliseconds}");
    Console.WriteLine(new String('-', 50));

}
