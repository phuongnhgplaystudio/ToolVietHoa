using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class SearchItem : MonoBehaviour
{
    public TextMeshProUGUI contentText;

    public void Setup(string text, string targetText = null)
    {
        if(targetText != null)
        {
            //text = Regex.Replace(text, targetText, "<color=red>" + targetText + "</color>", RegexOptions.IgnoreCase);
            text = text.Replace(targetText, "<color=red>" + targetText + "</color>");
        }
        contentText.text = text;
    }
}
