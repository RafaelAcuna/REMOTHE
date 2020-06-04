using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class YogaVideoManager : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        player.clip = clips[Random.Range(0, clips.Length)];
        player.Play();
    }

    public void pauseVideo()
    {
        player.Pause();
    }

    public void resumeVideo()
    {
        player.Play();
    }
}
