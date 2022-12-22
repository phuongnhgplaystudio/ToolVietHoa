using System.Collections;
using System.Collections.Generic;
//using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Reader : MonoBehaviour
{
    public static Reader Instance;

    public const string originalPath = @"D:\program\ExportTool-v1.15.14\ExportTool-v1.15.14\englishPak\Localization\English\english.xml";
    public const string resultPath = @"D:\UnityProjects\ToolVietHoa\Assets\Storage\translation.xml";
    public Button confirmButton;

    public List<string> stringList = new List<string> ();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LoadData(originalPath);
    }

    XmlDocument rawData = new XmlDocument();
    public List<ContentData> allData = new List<ContentData>();

    public void LoadData(string path)
    {
        rawData.Load(path);
        var xmlNodeList = rawData.SelectNodes("contentList/content");
        for (int i = 0; i < xmlNodeList.Count; i++)
        {
            var xmlNode = xmlNodeList.Item(i);
            //Console.WriteLine(xmlNode.Attributes[1].Value);
            allData.Add(new ContentData(xmlNode.Attributes[0].Value, Int32.Parse(xmlNode.Attributes[1].Value), xmlNode.InnerText, xmlNode));
        }
    }

    public void Save(string path)
    {
        rawData.Save(path);
    }

    public string? FindByText(string text)
    {
        if (rawData is null)
        {
            return default;
        }

        return allData.Find(predicate => predicate.Content == text)?.Id;
    }
}

[System.Serializable]
public class ContentData
{
    public string Content
    {
        get => _content;
        set => _parentNode.InnerText = value;
    }

    public string Id => _id;
    private readonly string _id;
    private int _version;
    private readonly string _content;
    private readonly XmlNode _parentNode;
    public ContentData(string id, int version, string content, XmlNode parentNode)
    {
        this._id = id;
        this._version = version;
        this._content = content;
        this._parentNode = parentNode;
    }
}
