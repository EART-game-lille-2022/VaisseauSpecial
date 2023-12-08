using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudoiManager : MonoBehaviour
{
    public static AudoiManager instance;
    public AudioSource _source;

    public static AudioClip CANNON_SHOOT;

    void Awake()
    {
        instance = this;
    }

    public void uihiruth(AudioClip toPlay)
    {

    }
}
