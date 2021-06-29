using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColors : MonoBehaviour
{
    public float R;
    public float G;
    public float B;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        RandomizeColor();
    }

    // Update is called once per frame
    void RandomizeColor()
    {
        R = Random.Range(0f, 1f);
        G = Random.Range(0f, 1f);
        B = Random.Range(0f, 1f);

        GetComponent<Image>().color = new Color(R, G, B, 1);
    }
    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = Random.Range(1.5f, 5);
            RandomizeColor();
        }
    }
}
