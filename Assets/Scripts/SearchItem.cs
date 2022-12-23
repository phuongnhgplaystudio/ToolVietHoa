using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchItem : MonoBehaviour
{
    public int index = 0;
    public TextMeshProUGUI contentText;
    public Button button;

    private void Awake()
    {
        button.onClick.AddListener(delegate
        {
            OnItemClick();
        });
    }
    public void Setup(int index, string text, string targetText = null)
    {
        gameObject.SetActive(true);
        this.index = index;
        if(targetText != null)
        {
            //text = Regex.Replace(text, targetText, "<color=red>" + targetText + "</color>", RegexOptions.IgnoreCase);
            text = text.Replace(targetText, "<color=red>" + targetText + "</color>");
        }
        contentText.text = text;
    }

    public void OnItemClick()
    {
        GameController.Singleton.originalTMP.SetText(GameController.Singleton.allData[index].preCalculate.raw);
    }
}
