using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
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
    
}
