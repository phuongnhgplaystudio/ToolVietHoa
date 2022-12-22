using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using UnityEngine.Serialization;

[Serializable]
public class ContentData
{
    [JsonIgnore] public string Content
    {
        get => _content;
        set => _parentNode.InnerText = value;
    }

    [JsonIgnore] public string Id => _id;
    private readonly string _id;
    private int _version;
    private readonly string _content;
    public SearchPreCalculate preCalculate;
    [JsonIgnore] private readonly XmlNode _parentNode;
    
    public ContentData(string id, int version, string content, XmlNode parentNode)
    {
        _id = id;
        _version = version;
        _content = content;
        _parentNode = parentNode;
        preCalculate = new SearchPreCalculate(content);
    }
}
[Serializable]
public struct SearchPreCalculate
{
    public string lower;
    public string[] lowerWordList;
    public string raw;
    public string[] rawWordList;

    public SearchPreCalculate(string input)
    {
        lower = input.ToLower();
        lowerWordList = lower.Split(' ');
        raw = input;
        rawWordList = raw.Split(' ');
    }
}