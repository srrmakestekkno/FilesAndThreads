using HandleData.Interfaces;
using HandleData.Model;
using HandleData.Proxy;
using System.Text.Json;

namespace HandleData.Services
{
    public class DataService
    {
        private IFileHandler _fileHandler;
        private readonly IExternalApiProxy _externalApiProxy;

        private const int ChunkSize = 100;

        public DataService(IFileHandler fileHandler, IExternalApiProxy externalApiProxy)
        {
            _fileHandler = fileHandler;
            _externalApiProxy = externalApiProxy;
        }

        //public async Task GetDataFromFile
        // Todo rearrange the code, make interfaces

        public async Task<Data?[][]> UpdateFileWithNewData()
        {
            var linesFromFile = new List<string>(); // TODO replace with real data from file.

            var totalCalls = linesFromFile.Count;

            List<Task<Data?[]>> chunkTasks = new();

            for (int i = 0; i < totalCalls; i+= ChunkSize)
            {
                int remainingCalls = totalCalls - 1;
                int callsInThisChunk = Math.Min(ChunkSize, remainingCalls);

                chunkTasks.Add(MakeApiCalls(i, callsInThisChunk, linesFromFile));
            }

            Data?[][] results = await Task.WhenAll(chunkTasks);

            return results;
        }

        private async Task<Data?[]> MakeApiCalls(int startIndex, int callsInChunk, List<string> linesFromFile)
        {
            Data? data = new();
            Data?[] results = new Data?[callsInChunk];

            for (int i = 0; i < callsInChunk; i++)
            {
                var line = linesFromFile[startIndex + i];
                string[] splittedLine = line.Split(";");
                string organizationNum = splittedLine[0];

                var response = await _externalApiProxy.GetAsync(organizationNum);

                if (response is not null && response.IsOk)
                {
                    results[i] = response;
                }
            }
            return results;
        }        
    }
}
