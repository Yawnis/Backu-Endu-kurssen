using System.Threading.Tasks;
using System;

namespace Teht1
{
    public interface ICityBikeDataFetcher
    {
        Task<int> GetBikeCountInStation(string stationName);
    }
}