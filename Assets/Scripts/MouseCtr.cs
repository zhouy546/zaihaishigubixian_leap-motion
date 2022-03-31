using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCtr : MonoBehaviour
{
    public HandTest[] handTests;
    public Tick tick;
    private void Start()
    {
        EventCenter.AddListener(EventDefine.ToSelectionState,()=>Utility.SwitchGameState(State.Selection));
        EventCenter.AddListener(EventDefine.ToPBState, () => Utility.SwitchGameState(State.PB));
        EventCenter.AddListener(EventDefine.ToVideoState, () => Utility.SwitchGameState(State.VideoPlay));
    }


    private void Update()
    {
       // Debug.Log(ValueSheet.GameState);

        if (ValueSheet.GameState == State.Selection)
        {
            if ((handTests[0].LeapHand == null ? 1 : 0) * (handTests[1].LeapHand == null ? 1 : 0) == 1)
            {
                //tick.Func_StartCountDonw();
            }
            else
            {
                tick.Func_ResetTime();
            }
        }

    }

}
