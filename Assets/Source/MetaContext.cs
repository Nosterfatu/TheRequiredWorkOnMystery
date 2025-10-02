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
            Progress = progress;
        }

        public void SetLevel(GameSave level)
        {
            Save = level;
        }
    }
}