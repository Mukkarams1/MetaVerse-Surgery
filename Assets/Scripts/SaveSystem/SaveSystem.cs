using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] LocationPrefab locationMarkerPrefab;

    //Angled brackets not allowed in desc, replace the
    //parenthesis in (Fish) with angled brackets
    public static List<LocationPrefab> locationMarkers = new List<LocationPrefab>();

    //Rename your strings according to what your saving
    public string Marker_SUB; // = "/player" + GameManager.instance.currentPlayername.ToString();
    public string Marker_COUNT_SUB; // = "/marker.count" + GameManager.instance.currentPlayername.ToString();
    public static SaveSystem instance;


    //Use if Android
    //void OnApplicationPause(bool pause)
    //{
    //    SaveFish();
    //}

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
 
    public void setPath()
    {
        if (GameManager.instance.currentPlayername != "" && GameManager.instance.currentSelectedDisease != "")
        {
            Marker_SUB = "/" + GameManager.instance.currentPlayername.ToString() + GameManager.instance.currentSelectedDisease.ToString();
            Marker_COUNT_SUB = "/marker.count" + GameManager.instance.currentPlayername.ToString() + GameManager.instance.currentSelectedDisease.ToString();
        }
    }

    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + Marker_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + Marker_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;

        FileStream countStream = new FileStream(countPath, FileMode.Create);

        formatter.Serialize(countStream, locationMarkers.Count);
        countStream.Close();

        for (int i = 0; i < locationMarkers.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            MarkerData data = new MarkerData(locationMarkers[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + Marker_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + Marker_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;
        int markerCount = 0;
        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);

            markerCount = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }
        else
        {
            Debug.LogError("Path not found in " + countPath);
        }


        for (int i = 0; i < markerCount; i++)
        {
            if (File.Exists(path + i))
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                MarkerData data = formatter.Deserialize(stream) as MarkerData;

                stream.Close();

                Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);

                LocationPrefab marker = Instantiate(locationMarkerPrefab, position, Quaternion.identity);

                marker.name = data.name;
            }
            else
            {
                Debug.LogError("Path not found in " + (path + i));
            }
        }
    }
    public void ClearAllData()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            var savedFiles = Directory.GetFiles(Application.persistentDataPath);
            foreach(var file in savedFiles)
            {
                File.Delete(file);
            }
        }
    }
}