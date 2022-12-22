using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;


public class GameController: MonoBehaviour
{
    public static GameController Singleton;
    public XMLBridge xmlBridge;

    public XmlDocument rootDocument;
    public List<ContentData> allData;

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
    }

    public void Init()
    {
        rootDocument = new XmlDocument();
        allData = new List<ContentData>();
        LoadDataFromPath(@"C:\Users\Axolotl\Downloads\english.xml");
    }

    public void LoadDataFromPath(string path)
    {
        xmlBridge.LoadData(path,ref rootDocument,ref allData);
    }
}