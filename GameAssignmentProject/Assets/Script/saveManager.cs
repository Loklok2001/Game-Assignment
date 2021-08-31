using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class saveManager : MonoBehaviour
{
    public static saveManager instance { get; private set; }


    //what we want to save
    public int currentHp;
    public int currentSample;

    private void Awake()
    {
        if (instance != null & instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
       if(File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            currentHp = data.currentHp;
            currentSample = data.currentSample;

            file.Close();

        }

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();
        data.currentHp = currentHp;
        data.currentSample = currentSample;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    public int currentHp;
    public int currentSample;
}
