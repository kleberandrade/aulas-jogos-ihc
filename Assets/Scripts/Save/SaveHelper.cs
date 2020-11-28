using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveHelper
{
    public static void Save<T>(T data, string file) where T : IDataSavable
    {
        var path = $"{Application.persistentDataPath}/{file}";
        var stream = new FileStream(path, FileMode.Create);
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static T Load<T>(string file) where T : IDataSavable
    {
        var path = $"{Application.persistentDataPath}/{file}";
        if (File.Exists(path))
        {
            var stream = new FileStream(path, FileMode.Open);
            var formatter = new BinaryFormatter();
            var data = (T)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }

        return default;
    }
}
