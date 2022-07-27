using BattleRise.Models;
using BattleRise.Models.SaveToFile;
using Newtonsoft.Json;
using System.Text.Json;

namespace BattleRise.SaveStorage
{
    public class TempSaveStorage
    {
        private List<SSave> sSaves = new List<SSave>();
        public void Save(Save save)
        {
            LoadSaves();
            sSaves.Add(SaveConverter.ToSSave(save));
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(sSaves, options);
            File.WriteAllText(@"D:\BattleRiseSaves.json", json);
        }

        public Save Load(int userId)
        {
            LoadSaves();
            var savesOfId = sSaves.Where(s => s.GetUserId() == userId);
            if (savesOfId.Count()==0 || savesOfId==null)
            {
                return null;
            }
            else
            {
                var s = SaveConverter.ToSave(savesOfId.Last());
                return s;
            }
        }

        public void LoadSaves()
        {
            if (File.Exists("D:\\BattleRiseSaves.json")) 
            {
                sSaves = JsonConvert.DeserializeObject<List<SSave>>(File.ReadAllText("D:\\BattleRiseSaves.json")).ToList();
            }
        }
    }
}