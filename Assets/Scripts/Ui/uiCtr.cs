using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiCtr : MonoBehaviour
{
    public Image m_image;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.UiMoveLeft, moveLeft);
        EventCenter.AddListener(EventDefine.UiMoveRight, moveRight);
        EventCenter.AddListener(EventDefine.ToVideoState, HideUI);
        EventCenter.AddListener(EventDefine.ToSelectionState, Showui);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void moveLeft()
    {
        ValueSheet.currentUiNode = ValueSheet.currentUiNode.next;

        Debug.Log("当前选择ID："+ValueSheet.currentUiNode.id);
    }

    private void moveRight()
    {
        ValueSheet.currentUiNode = ValueSheet.currentUiNode.pervious;

        Debug.Log("当前选择ID：" + ValueSheet.currentUiNode.id);
    }

    private void HideUI()
    {
        m_image.color = new Color(.5f, .5f, .5f, 0);
    }

    private void Showui()
    {
        m_image.color = new Color(.5f, .5f, .5f, 1);
    }
}
