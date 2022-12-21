using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour
{
    public static Reader Instance;

    public string originalPath = "";
    public string resultPath = "";

    public List<string> stringList = new List<string> ();

    private void Awake()
    {
        Instance = this;
    }


}
