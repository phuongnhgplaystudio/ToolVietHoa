using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using System;

public class SearchController : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public Transform searchResultPanel;
    public GameObject searchItem;

    public Button optionCaseSensitiveButton;
    public Button optionWholeWordOnlyButton;

    public Color choseColor;
    public bool optionCaseSensitive = false;
    public bool optionWholeWordOnly = false;

    private void Awake()
    {

    }

    public void OnSearchIFSelect()
    {
        searchResultPanel.DOScaleY(1, 0.25f).OnComplete(delegate
        {
            OnValueChangedIF();
        });
    }

    public void OnSearchIFDeselect()
    {
        searchResultPanel.DOScaleY(0, 0.1f);
    }

    public void OnValueChangedIF()
    {
        //Debug.Log("OnValueChanged");
        string currentText = searchInputField.text;
        foreach (Transform child in searchResultPanel)
        {
            Destroy(child.gameObject);
        }
        if (string.IsNullOrEmpty(currentText)) return;

        foreach (var stringData in Reader.Instance.stringList)
        {
            if (Contain(stringData, currentText))
            {
                GameObject searchItemObj = Instantiate(searchItem, searchResultPanel);
                searchItemObj.transform.SetAsLastSibling();
                SearchItem searchItemScript = searchItemObj.GetComponent<SearchItem>();
                if (searchItemScript != null)
                {
                    searchItemScript.Setup(stringData, currentText);
                }
            }
        }
    }

    public bool Contain(string container, string target)
    {
        if (optionWholeWordOnly)
        {
            if (Regex.Match(container, @"\b" + target + "\b", optionCaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return container.IndexOf(target, optionCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) >= 0;
    }

    public void OnClickButtonOptionCaseSensitive()
    {
        optionCaseSensitive = !optionCaseSensitive;
        if (optionCaseSensitive)
        {
            optionCaseSensitiveButton.GetComponent<Image>().color = choseColor;
        }
        else
        {
            optionCaseSensitiveButton.GetComponent<Image>().color = Color.white;
        }
        OnValueChangedIF();
        OnSearchIFSelect();
    }

    public void OnClickButtonOptionWholeWordOnly()
    {
        optionWholeWordOnly = !optionWholeWordOnly;
        if (optionWholeWordOnly)
        {
            optionWholeWordOnlyButton.GetComponent<Image>().color = choseColor;
        }
        else
        {
            optionWholeWordOnlyButton.GetComponent<Image>().color = Color.white;
        }
        OnValueChangedIF();
        OnSearchIFSelect();
    }
}
