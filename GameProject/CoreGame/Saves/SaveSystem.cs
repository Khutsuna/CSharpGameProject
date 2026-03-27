using GameProject.CoreGame.Saves;
using System.Text.Json;

namespace GameProject.CoreGame
{
    public class SaveSystem
    {
        private const string SavePath = "save.json";

        public void Save(SaveData data)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(SavePath, json);
        }

        public SaveData Load()
        {
            string json = File.ReadAllText(SavePath);
            return JsonSerializer.Deserialize<SaveData>(json);
        }

        public bool SaveExists()
        {
            return File.Exists(SavePath);
        }
    }
}
