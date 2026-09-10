using System;
using System.IO;
public class Journal()
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
    public void SaveToFile(string file)
    {
        string filename = Path.Combine("Entries", file);
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date},{entry._promptText},{entry._entryText}");
            }
        }
    }
    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string filename = Path.Combine("Entries",file);
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string date = parts[0];
            string prompt = parts[1];
            string entryText = parts[2];

            Entry loadEntry = new Entry();
            loadEntry._date = date;
            loadEntry._promptText = prompt;
            loadEntry._entryText = entryText;

            _entries.Add(loadEntry);
        }

    }


}
