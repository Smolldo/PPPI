using gonyk5;

ClientWeather client = new ClientWeather("4bf8c68da4ca8c58f09e6ef424b2e9d1");

Console.WriteLine("Snihurivka:\n");
WeatherModel result = await client.Get();

result.PrintResult();

Console.WriteLine("\n\nTernopil:\n");

WeatherModel result2 = await client.Post("Ternopil");

result2.PrintResult();