using BattleRise.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace BattleRise.SaveStorage
{
    public class TempSaveStorage
    {
        private List<Save> saves = new List<Save>();
        public void Save(Save save)
        {
            LoadSaves();
            saves.Add(save);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(saves, options);
            File.WriteAllText(@"D:\BattleRiseSaves.json", json);
        }

        public Save Load(int userId)
        {
            LoadSaves();
            var savesOfId = saves.Where(s => s.GetUserId() == userId);
            if (savesOfId.Count()==0 || savesOfId==null)
            {
                return null;
            }
            else
            {
                return savesOfId.Last();
            }
        }

        public void LoadSaves()
        {
            if (File.Exists("D:\\BattleRiseSaves.json")) 
            {
                saves = JsonConvert.DeserializeObject<List<Save>>(File.ReadAllText("D:\\BattleRiseSaves.json")).ToList();
            }
        }
    }
}