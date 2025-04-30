using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundPlayer : ISoundPlayer
{
    private readonly AudioSource _source;
    private readonly AudioClip _openClip;
    private readonly AudioClip _closeClip;

    [Inject]
    public SoundPlayer(AudioData audioData)
    {
        _source = audioData.AudioSource;
        _openClip = audioData.OpenClip;
        _closeClip = audioData.CloseClip;
    }

    public void PlayOpenSound()
    {
        _source.PlayOneShot(_openClip);
    }

    public void PlayCloseSound()
    {
        _source.PlayOneShot(_closeClip);
    }
}
