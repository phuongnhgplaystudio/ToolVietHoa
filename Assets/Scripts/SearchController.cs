using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;

public class SearchController : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public Transform searchResultPanel;
    public Transform searchResultContainer;
    public GameObject searchItem;

    public Button searchButton;

    public Button optionCaseSensitiveButton;
    public Button optionWholeWordOnlyButton;

    public Color choseColor;
    public bool optionCaseSensitive = false;
    public bool optionWholeWordOnly = false;

    public List<string> allDataLower = new List<string>();

    public List<SearchItem> searchItemList = new List<SearchItem>();
    public int poolIndex = 0;
    private void Awake()
    {
        searchButton.onClick.AddListener(delegate
        {
            OnClickSearchButton();
        });
    }

    public void OnClickSearchButton()
    {
        searchResultPanel.DOScaleY(1, 0.1f);
        
        string input = searchInputField.text;

        StartCoroutine(SearchContent(input.ToLower()));
    }

    public void Init()
    {
        StartCoroutine(InitLowerList());
        StartCoroutine(InitSearchItemList());
    }

    private IEnumerator InitLowerList()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        foreach (ContentData content in GameController.Singleton.allData)
        {
            allDataLower.Add(content.preCalculate.lower);
        }
        watch.Stop();
        Debug.Log($"InitLowerList() execution Time: {watch.ElapsedMilliseconds} ms");
        yield break;
    }
    private IEnumerator InitSearchItemList()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        for (int i = 1; i <= 5000; i++)
        {
            GameObject searchItemObj = Instantiate(searchItem, searchResultContainer);
            searchItemObj.SetActive(false);
            SearchItem searchItemScript = searchItemObj.GetComponent<SearchItem>();
            searchItemList.Add(searchItemScript);
        }
        watch.Stop();
        Debug.Log($"InitSearchItemList() execution Time: {watch.ElapsedMilliseconds} ms");
        yield break;
    }

    private IEnumerator SearchContent(string input)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        for (int i = 0; i < poolIndex; i++)
        {
            searchItemList[i].gameObject.SetActive(false);
        }
        poolIndex = 0;
        
        for(int i = 0; i < allDataLower.Count; i++)
        {
            if (!CheckContain(allDataLower[i], input))
            {
                continue;
            }
            //SearchItem searchItemScript = Instantiate(searchItem, searchResultContainer).GetComponent<SearchItem>();
            searchItemList[poolIndex].Setup(i, GameController.Singleton.allData[i].preCalculate.raw, input);
            poolIndex++;
        }
        watch.Stop();
        Debug.Log($"Searching for '{input}' takes: {watch.ElapsedMilliseconds} ms");
        yield return null;
    }

    private bool CheckContain(string container, string target)
    {
        return container.Contains(target);
    }

    public void OnDeselectSearchIF()
    {
        searchResultPanel.DOScaleY(0, 0.1f);
    }
}
