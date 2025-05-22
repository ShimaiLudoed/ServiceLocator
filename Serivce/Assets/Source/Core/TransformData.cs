using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformData : MonoBehaviour
{
    [field: SerializeField] public Transform Player { get; private set; }
    [field: SerializeField] public Transform Michen { get; private set; }

    private void Update()
    {
        Debug.Log(Michen.transform.position);  
    }
}
