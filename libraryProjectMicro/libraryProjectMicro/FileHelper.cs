namespace libraryProjectMicro;

class FileHelper
{

    public string Path { get; }
    public FileHelper(string path)
    {
        Path = path;
    }
    public string Read()
    {
        using StreamReader sr = new StreamReader(Path);
        return sr.ReadToEnd();
    }
    public void Append(string text)
    {
        using StreamWriter sw = new StreamWriter(Path, true);
        sw.WriteLine(text);
    }

    public void replace(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path, false))
        {
            sw.WriteLine(text);
        }
    }
}

