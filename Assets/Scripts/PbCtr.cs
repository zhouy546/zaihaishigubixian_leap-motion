using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;

public class PbCtr : MonoBehaviour
{
    public DisplayUGUI displayUGUI;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.ToSelectionState, Hide);
        EventCenter.AddListener(EventDefine.ToPBState, Show);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        displayUGUI.color = new Color(1, 1, 1, 1);
    }

    public void Hide()
    {
        displayUGUI.color = new Color(1, 1, 1, 0);
    }
}
