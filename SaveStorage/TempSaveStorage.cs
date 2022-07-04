using BattleRise.Models;

namespace SaveStorage
{
    public class TempSaveStorage
    {
        public void Save(Save save)
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(save);
            Console.WriteLine(jsonString);
        }

        public Save Load()
        {
            return null;
        }
    }
}