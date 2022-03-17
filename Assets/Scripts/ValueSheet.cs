using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  enum State { Selection, VideoPlay,PB }
public enum SelectionMune { Left,Right,Idle}

public static class ValueSheet 
{
    public static Dictionary<string, Videoinfo> udp_VideoinfoPairs = new Dictionary<string, Videoinfo>();

    public static Videoinfo currentOnPlayVideoInfo;

    public static UiNode currentUiNode;

    public static string volumeup;

    public static string volumedown;

    public static State GameState = State.PB;

    public static bool MouseDebug = false;

    public static int reslutionX = 1920;

    public static int reslutionY = 1080;

    public static string ProgramName= "LuoTianZaiHaiShiGuBiXian";
}

public class Videoinfo
{
    public string udp;

    public string url;

    public bool isloop;

    public bool isScreenProtect;

    public Videoinfo()
    {

    }

    public Videoinfo(string _udp, string _url, bool _isLoop, bool _isScreenProtect)
    {
        udp = _udp;
        url = _url;
        isloop = _isLoop;
        isScreenProtect = _isScreenProtect;
    }
}