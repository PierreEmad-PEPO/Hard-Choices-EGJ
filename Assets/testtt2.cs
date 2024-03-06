using ArabicSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class testtt2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        string txt = GetComponent<UIDocument>().rootVisualElement.Q<Label>().text;
        var ar = ArabicFixer.Fix(txt);
        GetComponent<UIDocument>().rootVisualElement.Q<Label>().text = ar;
    }

    
}
