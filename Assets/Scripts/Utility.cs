using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static float Maping(float value, float inputMin, float inputMax, float outputMin, float outputMax, bool clamp)
    {
        float outVal = ((value - inputMin) / (inputMax - inputMin) * (outputMax - outputMin) + outputMin);

        if (clamp)
        {
            if (outputMax < outputMin)
            {
                if (outVal < outputMax) outVal = outputMax;
                else if (outVal > outputMin) outVal = outputMin;
            }
            else
            {
                if (outVal > outputMax) outVal = outputMax;
                else if (outVal < outputMin) outVal = outputMin;
            }
        }


        return outVal;
    }

    public static bool IsPull3DconnexBtn()
    {

        return false;
    }

    public static bool IsGrab(float INDEX)
    {
        if(INDEX == 1)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    public static void  MoveLeft()
    {
        EventCenter.Broadcast(EventDefine.UiMoveLeft);
    }

    public static void MoveRight()
    {
        EventCenter.Broadcast(EventDefine.UiMoveRight);
    }


    public static void SwitchGameState(State _State)
    {
        ValueSheet.GameState = _State;
    }

    private static bool timeLock = false;
    public static SelectionMune moveDirection(float X)
    {
            if (X > 1)
            {
                return SelectionMune.Right;
            }
            else if (X < -1)
            {
                return SelectionMune.Left;
            }
            else
            {
                return SelectionMune.Idle;
            }

    }

}
