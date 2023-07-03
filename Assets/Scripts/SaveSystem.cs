using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{

    public static void SavePlayer(PlayerStats player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sth";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sth";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            if (data.achievements == null)
            {
                data.achievements = new System.Collections.Generic.HashSet<AchievementType>();
            }
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }

    }
    public static void ResetSave()
    {

        try
        {
            string path = Application.persistentDataPath + "/player.sth";
            File.Delete(path);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

}
