using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TestSerialize
{
#if UNITY_EDITOR
    [SerializeField]
#else
    [NonSerialized]
#endif
    private Sprite devIcon;

}
