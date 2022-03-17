using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaCtr : MonoBehaviour
{
    public static MediaCtr instance;

    MediaPlayer mediaplayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        mediaplayer = this.GetComponent<MediaPlayer>();
       // EventCenter.AddListener(EventDefine.ini, Ini);
        mediaplayer.Events.AddListener(MediaEvent);

        EventCenter.AddListener(EventDefine.ToVideoState, LoadVideo);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ini()
    {
        //string screenProtectKey = getScreenProtectUDP();
        //if (screenProtectKey != "null")
        //{
        //    LoadVideo(ValueSheet.udp_VideoinfoPairs[screenProtectKey]);
        //}
    }

    private string getScreenProtectUDP()
    {
        foreach (var item in ValueSheet.udp_VideoinfoPairs)
        {
           if(item.Value.isScreenProtect)
            {
                return item.Key;
            }
        }
        return "null";
    }

    public void LoadVideo()
    {
        ValueSheet.currentOnPlayVideoInfo = ValueSheet.udp_VideoinfoPairs[ValueSheet.currentUiNode.id.ToString()];

        mediaplayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, ValueSheet.currentOnPlayVideoInfo.url, true);

        mediaplayer.Control.SetLooping(ValueSheet.currentOnPlayVideoInfo.isloop);

        mediaplayer.Play();
    }

    public void VolumeDown()
    {
        float currentVolume = mediaplayer.m_Volume;

        float newVolume = Mathf.Clamp01(currentVolume -= 0.1f);

        mediaplayer.Control.SetVolume(newVolume);
    }

    public void VolumeUp()
    {
        float currentVolume = mediaplayer.m_Volume;

        float newVolume = Mathf.Clamp01(currentVolume += 0.1f);

        mediaplayer.Control.SetVolume(newVolume);
    }

    public void MediaEvent(MediaPlayer mediaplayer, MediaPlayerEvent.EventType eventType,ErrorCode errorCode)
    {
        if(eventType == MediaPlayerEvent.EventType.Started)
        {
            Debug.Log("开始播放");
        }
        if (eventType == MediaPlayerEvent.EventType.FinishedPlaying)
        {
            Debug.Log("停止播放");

            EventCenter.Broadcast(EventDefine.ToSelectionState);
            //if (!ValueSheet.currentOnPlayVideoInfo.isloop&&!ValueSheet.currentOnPlayVideoInfo.isScreenProtect)
            //{
            //    Debug.Log("回到屏保");
            //    string screenProtectKey = getScreenProtectUDP();
            //    if (screenProtectKey != "null")
            //    {
            //        LoadVideo(ValueSheet.udp_VideoinfoPairs[screenProtectKey]);
            //    }
            //}
        }
    }

}
