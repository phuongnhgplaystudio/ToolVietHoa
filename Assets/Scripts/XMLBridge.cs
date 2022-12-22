using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class XMLBridge : MonoBehaviour
{
    public void LoadData(string path, ref XmlDocument document, [NotNull] ref List<ContentData> allData)
    {
        document.Load(path);
        var xmlNodeList = document.SelectNodes("contentList/content");
        for (int i = 0; i < xmlNodeList.Count; i++)
        {
            var xmlNode = xmlNodeList.Item(i);
            allData.Add(new ContentData(xmlNode.Attributes[0].Value, Int32.Parse(xmlNode.Attributes[1].Value), xmlNode.InnerText, xmlNode));
        }
    }

    public void SaveToPath(string path, XmlDocument document)
    {
        document.Save(path);
    }
}