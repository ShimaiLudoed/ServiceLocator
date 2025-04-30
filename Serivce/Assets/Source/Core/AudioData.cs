using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class AudioData : MonoBehaviour
    {
        [field: SerializeField] public AudioClip CloseClip { get; private set; }
        [field: SerializeField] public AudioClip OpenClip { get; private set; }
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
    }
}