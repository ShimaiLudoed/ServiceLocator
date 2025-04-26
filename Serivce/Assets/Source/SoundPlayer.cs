using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : ISoundPlayer
{
  private readonly AudioSource _source;
  private readonly AudioClip _openClip;
  private readonly AudioClip _closeClip;
  
  public SoundPlayer(AudioSource source, AudioClip openClip, AudioClip closeClip)
  {
    _source = source;
    _openClip = openClip;
    _closeClip = closeClip;
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
