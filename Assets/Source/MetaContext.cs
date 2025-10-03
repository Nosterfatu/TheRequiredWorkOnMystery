using System.IO;
using UnityEngine;

namespace Source
{
    public class MetaContext : IProgressionContext, IProgressionManager
    {
        public bool HasProgress => Save != null;
        public int Progress { get; private set; } = PlayerPrefs.GetInt("Progress", 0);
        public GameSave Save { get; private set; }
        private readonly string _savePath = Path.Combine(Application.persistentDataPath, "Save.json");

        public MetaContext()
        {
            if (File.Exists(_savePath))
            {
                Save = JsonUtility.FromJson<GameSave>(File.ReadAllText(_savePath));
            }
        }

        public void SetProgress(int progress)
        {
            if (HasProgress && progress == Progress)
            {
                return;
            }
            
            if (Progress != progress)
            {
                PlayerPrefs.SetInt("Progress", progress);
                Progress = progress;
            }
        
            Reset();
     
        }

        public void SetLevel(GameSave level)
        {
            Save = level;
            File.WriteAllText(_savePath, JsonUtility.ToJson(Save));
        }

        public void Reset()
        {
            Save = new GameSave()
            {
                Progression = LevelsDict.Levels[Progress],
                MaxTurns = LevelsDict.Levels[Progress].Length,
                TurnCount = 0,
                Score = 0
            };
            
            File.WriteAllText(_savePath, JsonUtility.ToJson(Save));

        }
    }
}