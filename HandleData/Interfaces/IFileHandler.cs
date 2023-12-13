namespace HandleData.Interfaces
{
    public interface IFileHandler
    {
        /// <summary>
        /// Reads all data from file and returns a list with semicolon separated lines.
        /// </summary>
        /// <param name="path">Path to the fil.</param>
        /// <returns></returns>
        Task<List<string>> ReadFile(string path);

        /// <summary>
        /// Overwrtie the file with the new data.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="lines">Semi colon separated lines</param>
        /// <returns></returns>
        Task WriteFile(string path, List<string> lines);
        

    }
}
