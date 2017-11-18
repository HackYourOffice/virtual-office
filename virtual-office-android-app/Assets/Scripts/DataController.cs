using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{

    private GameData data;

    private string poiDataFileName = "data.json";

    public GameData GetGameData()
    {
        return data;
    }
    public void LoadPoiData()
    {
        string filePath = Application.streamingAssetsPath + "/" + poiDataFileName;
        string jsonString;

        // Need to extract file from apk first
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }

            jsonString = reader.text;
        }
        else
        {
            jsonString = File.ReadAllText(filePath);
        }

        this.data = JsonUtility.FromJson<GameData>(jsonString);
    }
}

public class GameData
{
    public string name;
    public string myFavourite;

    public GameData(string name, string myFavourite)
    {
        this.name = name;
        this.myFavourite = myFavourite;
    }
}
