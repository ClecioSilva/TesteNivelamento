using Newtonsoft.Json.Linq;

public class Program
{
    public static async Task Main()
    {
        await GetGoalsScored("Paris Saint-Germain", 2013);
        await GetGoalsScored("Chelsea", 2014);
    }

    static async Task GetGoalsScored(string teamName, int year)
    {
        using (var httpClient = new HttpClient())
        {
            var apiUrl = $"https://jsonmock.hackerrank.com/api/football_matches?team1={teamName}&year={year}";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(jsonString);

                int totalGoals = 0;
                foreach (var match in jsonObject["data"])
                {
                    totalGoals += (int)match["team1goals"];
                }

                Console.WriteLine($"Team {teamName} scored {totalGoals} goals in {year}");
            }
            else
            {
                Console.WriteLine($"Failed to fetch data for {teamName} in {year}");
            }
        }
    }
}