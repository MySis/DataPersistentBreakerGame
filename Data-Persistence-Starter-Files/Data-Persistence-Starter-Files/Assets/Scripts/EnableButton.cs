using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    public Text nameHolder;
    public Button Start;
    // Update is called once per frame
    void Update()
    {
        if (nameHolder.text == "")
            Start.interactable = false;
        else if (nameHolder.text != null)
            Start.interactable = true;
    }
}
