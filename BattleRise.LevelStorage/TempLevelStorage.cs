using BattleRise.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace BattleRise.LevelStorage
{
    public class TempLevelStorage
    {
        private List<Level> levels = new List<Level>();
        public void Save(Level level)
        {
            LoadLevels();
            levels.Add(level);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(levels, options);
            File.WriteAllText(@"D:\BattleRiseLevels.json", json);
        }

        public void LoadLevels()
        {
            if (File.Exists("D:\\BattleRiseLevels.json"))
            {
                levels = JsonConvert.DeserializeObject<List<Level>>(File.ReadAllText("D:\\BattleRiseSaves.json")).ToList();
            }
        }
    }
}