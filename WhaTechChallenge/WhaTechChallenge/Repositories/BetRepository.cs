using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WhaTechChallenge.Models;

namespace WhaTechChallenge.Repositories
{
    class BetRepository : IBetRepository
    {
        const string SettledBetsFileName = "Settled.csv";
        const string UnsettledBetsFileName = "Unsettled.csv";

        public IEnumerable<SettledBetHistoryItem> GetSettledBetHistory()
        {
            using (var fileReader = File.OpenText(GetFilePath(SettledBetsFileName)))
            using (var csvReader = new CsvHelper.CsvReader(fileReader))
            {
                return csvReader.GetRecords<SettledBetHistoryItem>().ToList();
            }
        }

        public IEnumerable<UnsettledBetItemDto> GetUnsettledBets()
        {
            using (var fileReader = File.OpenText(GetFilePath(UnsettledBetsFileName)))
            using (var csvReader = new CsvHelper.CsvReader(fileReader))
            {
                return csvReader.GetRecords<UnsettledBetItemDto>().ToList();
            }
        }

        private static string GetFilePath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", fileName);
        }
    }
}