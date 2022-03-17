using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiNode : MonoBehaviour
{
    public int id;
    public UiNode next;
    public UiNode pervious;
    // Start is called before the first frame update
    void Start()
    {
        if (id == 0)
        {
            ValueSheet.currentUiNode = this;
        }
    }

    public void MoveLeft()
    {

    }

    public void MoveRight()
    {

    }
    // Update is called once per frame

}
