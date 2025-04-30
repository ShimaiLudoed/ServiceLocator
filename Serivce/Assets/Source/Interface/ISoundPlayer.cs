using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundPlayer : IService
{
  public void PlayOpenSound();
  public void PlayCloseSound();
}
