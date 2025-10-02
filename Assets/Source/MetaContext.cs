using System.IO;
using UnityEngine;

namespace Source
{
    public class MetaContext : IProgressionContext
    {
        public bool HasProgress => Save != null;
        public int Progress { get; private set; } = 0;
        public GameSave Save { get; private set; }
        private readonly string _savePath = Path.Combine(Application.persistentDataPath, "Save.json");

        public MetaContext()
        {
            if (File.Exists(_savePath))
            {
                Save = JsonUtility.FromJson<GameSave>(File.ReadAllText(_savePath));
            }
        }
    }
}