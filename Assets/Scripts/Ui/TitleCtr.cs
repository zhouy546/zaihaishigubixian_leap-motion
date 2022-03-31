using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCtr : MonoBehaviour
{
    public static TitleCtr instance;

    public Image title_img;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void changeTitle(Sprite sprite)
    {
        title_img.sprite = sprite;
    }
}
