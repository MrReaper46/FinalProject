using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePet(StatsManager petStats)
    {
        BinaryFormatter formater = new();
        string currentPet = PetManager.Instance.PetName;
        string path = Application.persistentDataPath + $"/{currentPet}stats.pet";
        FileStream stream = new(path, FileMode.Create);
        PetManager data = new();

        formater.Serialize(stream, data);
        stream.Close();
    }
}
