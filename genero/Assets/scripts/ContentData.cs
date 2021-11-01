using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ContentData : MonoBehaviour
{

    public AllData allData;

    [Serializable]
    public class AllData
    {
        public DataContent[] data;
    }

    [Serializable]
    public class DataContent
    {
        public int year;
        public string type;
        public string[] other_types;
        public YearData[] content;
    }

    [Serializable]
    public class YearData
    {
        public string text;
        public string imageURL;
        public string videoURL;
    }

    void Awake()
    {
        StartCoroutine(LoadCountryCodes());
    }
    public IEnumerator LoadCountryCodes()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "data.json");

        WWW www = new WWW(filePath);
        yield return www;
        string dataAsJson = www.text;

        allData = JsonUtility.FromJson<AllData>(dataAsJson);
    }
}
