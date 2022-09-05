using System.Net.Http.Headers;
using System.Net.Http.Json;
using TestCRUDApi;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7172");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatin/json"));

HttpResponseMessage response = await client.GetAsync("api/issue");
if (response.IsSuccessStatusCode)
{
    var issues = await response.Content.ReadFromJsonAsync<IEnumerable<IssueData>>();
    foreach (var issue in issues)
    {
        Console.WriteLine("Id: {0}", issue.Id);
        Console.WriteLine("Title: {0}", issue.Title);
        Console.WriteLine("Description: {0}", issue.Description);
        Console.WriteLine("Priority: {0}", issue.Priority);
        Console.WriteLine("IssueType: {0}", issue.IssueType);
        Console.WriteLine("Created: {0}", issue.Created);
        Console.WriteLine("Completed: {0}", issue.Completed);
    }
}
else
{
    Console.WriteLine("No Results");
}