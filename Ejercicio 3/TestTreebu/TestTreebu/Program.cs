using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class ExchangeRateApi
{
    private const string ApiBaseUrl = "https://api.exchangeratesapi.io/";

    public async Task GetExchangeRatesLastYear()
    {
        foreach (var currencyPair in new[] { "USDCOP", "EURCOP", "MXNCOP", "COPUSD", "COPMXN", "COPEUR" })
        {
            var rates = await GetExchangeRates(currencyPair, DateTime.Now.AddYears(-1), DateTime.Now);
            PrintExchangeRates(currencyPair, rates);
        }
    }

    public async Task CheckAndUpdateExchangeRates()
    {
        foreach (var currencyPair in new[] { "USDCOP", "EURCOP", "MXNCOP", "COPUSD", "COPMXN", "COPEUR" })
        {
            var currentRate = await GetLatestExchangeRate(currencyPair);
            var lastSavedRate = LoadLastSavedRateFromDatabase(currencyPair);

            if (lastSavedRate == null || currentRate != lastSavedRate)
            {
                SaveExchangeRateToDatabase(currencyPair, currentRate);
                Console.WriteLine($"Updated exchange rate for {currencyPair}: {currentRate}");
            }
            else
            {
                Console.WriteLine($"Exchange rate for {currencyPair} has not changed.");
            }
        }
    }

    public async Task ConvertUSDToOtherCurrencies()
    {
        var usdAmount = 25;
        var currencies = new[] { "EUR", "MXN", "COP" };

        foreach (var currency in currencies)
        {
            var rate = await GetLatestExchangeRate($"USD{currency}");
            var convertedAmount = usdAmount * rate;

            Console.WriteLine($"USD {usdAmount} is equal to {convertedAmount} {currency} at the current exchange rate.");
        }
    }

    private async Task<double> GetLatestExchangeRate(string currencyPair)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetStringAsync($"{ApiBaseUrl}latest?base={currencyPair.Substring(0, 3)}&symbols={currencyPair.Substring(3)}");
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeRateData>(response);
            return data.Rates[currencyPair.Substring(3)];
        }
    }

    private async Task<Dictionary<DateTime, Dictionary<string, double>>> GetExchangeRates(string currencyPair, DateTime startDate, DateTime endDate)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"{ApiBaseUrl}history?start_at={startDate:yyyy-MM-dd}&end_at={endDate:yyyy-MM-dd}&base={currencyPair.Substring(0, 3)}&symbols={currencyPair.Substring(3)}");

                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<HistoricalExchangeRateData>(response);

                if (data == null)
                {
                    Console.WriteLine("La deserialización devolvió null. Verifica el formato de la respuesta JSON.");
                    throw new InvalidOperationException("La deserialización devolvió null. Verifica el formato de la respuesta JSON.");
                }

                return data.Rates;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en GetExchangeRates: {ex.Message}");
            throw;
        }
    }

    public void PrintExchangeRates(string currencyPair, Dictionary<DateTime, Dictionary<string, double>> exchangeRates)
    {
        Console.WriteLine($"Exchange Rates for {currencyPair}:");

        foreach (var rate in exchangeRates)
        {
            Console.WriteLine($"Date: {rate.Key}");
            foreach (var symbolRate in rate.Value)
            {
                Console.WriteLine($"  {symbolRate.Key}: {symbolRate.Value}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }


    private double? LoadLastSavedRateFromDatabase(string currencyPair)
    {
        return null;
    }

    private void SaveExchangeRateToDatabase(string currencyPair, double rate)
    {
        Console.WriteLine($"Guardando tasa de cambio para {currencyPair}: {rate}");
    }


}

class ExchangeRateData
{
    public Dictionary<string, double> Rates { get; set; }
}

class HistoricalExchangeRateData
{
    public Dictionary<DateTime, Dictionary<string, double>> Rates { get; set; }
}

class Program
{
    static async Task Main()
    {
        var exchangeRateApi = new ExchangeRateApi();

        // 1. Extraer y presentar de manera legible la información del último año
        await exchangeRateApi.GetExchangeRatesLastYear();

        // 2. Consultar y actualizar el valor actual
        await exchangeRateApi.CheckAndUpdateExchangeRates();

        // 3. Convierta USD 25 en cada una de las siguientes monedas
        await exchangeRateApi.ConvertUSDToOtherCurrencies();
    }
}


