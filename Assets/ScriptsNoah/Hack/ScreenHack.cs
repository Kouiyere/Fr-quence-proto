using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScreenHack : MonoBehaviour
{
    private HackObject hackObject;
    private VideoPlayer videoPlayer;
    public VideoClip video1;
    public VideoClip video2;

    private void Start()
    {
        hackObject = GetComponent<HackObject>();
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (hackObject.isHacked)
        {
            videoPlayer.clip = video1;
        }
        else
        {
            videoPlayer.clip = video2;
        }
    }
}