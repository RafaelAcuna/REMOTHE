using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip click;
    public AudioClip lifeLost;
    public AudioClip gameOver;
    public AudioClip ballKick;
    public AudioClip netHit;
    public AudioClip gloveCatch;
    public AudioClip celebration;
    public AudioClip splash;
    public AudioClip collect;

    public void playClick()
    {
        source.PlayOneShot(click);
    }

    public void playLifeLost()
    {
        source.PlayOneShot(lifeLost);
    }

    public void playGameOver()
    {
        source.PlayOneShot(gameOver);
    }

    public void playBallKick()
    {
        source.PlayOneShot(ballKick);
    }

    public void playNetHit()
    {
        source.PlayOneShot(netHit);
    }

    public void playGloveCatch()
    {
        source.PlayOneShot(gloveCatch);
    }

    public void playCelebration()
    {
        source.PlayOneShot(celebration);
    }

    public void playSplash()
    {
        source.PlayOneShot(splash);
    }

    public void playCollect()
    {
        source.PlayOneShot(collect);
    }
}
