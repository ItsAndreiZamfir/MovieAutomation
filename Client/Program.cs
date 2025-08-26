using System.Net.Http;
using System.Net.Http.Json;
using Movies;

try
{
    var movieRepository = new MovieRepository();
    var movieService = new MovieService();
    bool result = await movieService.CheckMovieTitleFilter("War of the Worlds");
    Console.WriteLine($"Result: {result}");


}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}
finally
{
    Console.WriteLine("End of program, press any key to exit...");
    Console.ReadKey();
}

