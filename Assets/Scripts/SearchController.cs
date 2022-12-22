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
    }

    private IEnumerator InitLowerList()
    {
        foreach (ContentData content in GameController.Singleton.allData)
        {
            allDataLower.Add(content.preCalculate.lower);
        }
        yield break;
    }

    private IEnumerator SearchContent(string input)
    {
        foreach(Transform child in searchResultContainer)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i < allDataLower.Count; i++)
        {
            if (!CheckContain(allDataLower[i], input))
            {
                continue;
            }
            SearchItem searchItemScript = Instantiate(searchItem, searchResultContainer).GetComponent<SearchItem>();
            searchItemScript.Setup(i, GameController.Singleton.allData[i].preCalculate.raw, input);
        }
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
