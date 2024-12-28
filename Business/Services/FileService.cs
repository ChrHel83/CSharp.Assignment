namespace Business.Services;

public class FileService
{
    private readonly string _directoryName;
    private readonly string _filePath;

    public FileService(string directoryName = "Json_lists", string fileName = "contactList.json")
    {
        _directoryName = directoryName;
        _filePath = Path.Combine(directoryName, fileName);

    }
    public void SaveContentToFile(string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            if (!Directory.Exists(_directoryName))
            {
                Directory.CreateDirectory(_directoryName);
            }

            File.WriteAllText(_filePath, content);
        }
    }

    public string? GetContentFromFile()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }
        return null;
    }
}
