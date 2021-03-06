using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaCtr : MonoBehaviour
{
    public static MediaCtr instance;

    public DisplayIMGUI displayIMGUI;

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
        EventCenter.AddListener(EventDefine.ToSelectionState, stopVideo);
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

    private void stopVideo()
    {
        mediaplayer.Stop();

        displayIMGUI._color = new Color(1, 1, 1, 0);
    }

    public void LoadVideo()
    {
        displayIMGUI._color = new Color(1, 1, 1, 1);

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
            Debug.Log("????????");
        }
        if (eventType == MediaPlayerEvent.EventType.FinishedPlaying)
        {
            Debug.Log("????????");

            EventCenter.Broadcast(EventDefine.ToSelectionState);
            //if (!ValueSheet.currentOnPlayVideoInfo.isloop&&!ValueSheet.currentOnPlayVideoInfo.isScreenProtect)
            //{
            //    Debug.Log("????????");
            //    string screenProtectKey = getScreenProtectUDP();
            //    if (screenProtectKey != "null")
            //    {
            //        LoadVideo(ValueSheet.udp_VideoinfoPairs[screenProtectKey]);
            //    }
            //}
        }
    }

}
