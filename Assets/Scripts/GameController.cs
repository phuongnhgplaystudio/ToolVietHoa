using System;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;


public class GameController: MonoBehaviour
{
    public static GameController Singleton;
    public XMLBridge xmlBridge;
    public SearchController searchController;

    public XmlDocument rootDocument;
    public List<ContentData> allData;

    public TextMeshProUGUI originalTMP;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        Init();
        searchController.Init();
    }

    public void Init()
    {
        rootDocument = new XmlDocument();
        allData = new List<ContentData>();
        LoadDataFromPath(@"D:\program\ExportTool-v1.15.14\ExportTool-v1.15.14\englishPak\Localization\English\english.xml");
        allData[1].Content = "<ÁBDKASJDH>";
        xmlBridge.SaveToPath(@"D:\program\ExportTool-v1.15.14\ExportTool-v1.15.14\assetrPAK\abc.xml",rootDocument);

    }

    public void LoadDataFromPath(string path)
    {
        xmlBridge.LoadData(path,ref rootDocument,ref allData);
    }

    public void Save100First()
    {
        xmlBridge.SaveToPath(@"D:\program\ExportTool-v1.15.14\ExportTool-v1.15.14\assetrPAK\abc.xml",rootDocument);
    }
}