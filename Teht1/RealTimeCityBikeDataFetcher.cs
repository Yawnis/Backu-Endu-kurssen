using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teht1
{
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        public async Task<int> GetBikeCountInStation(string stationName)
        {
            try
            {
                if (stationName.Any(char.IsDigit))
                {
                    throw new ArgumentException();
                }
                HttpClient client = new HttpClient();
                string message = await client.GetStringAsync("https://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
                BikeRentalStationList bikeling = JsonConvert.DeserializeObject<BikeRentalStationList>(message);
                int bikes = 0;
                bool found = false;

                foreach (var station in bikeling.stations)
                {
                    if (station.name == stationName)
                    {
                        bikes = station.bikesAvailable;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new NotFoundException(stationName);
                }
                return bikes;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid argument, fool: " + ex.Message);
                return 0;
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Not found: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}