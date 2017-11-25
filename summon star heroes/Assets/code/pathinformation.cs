using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathinformation : MonoBehaviour
{
    public Transform location;
    public movement walkDirection;
    public bool stop;
    void Start()
    {
        location = gameObject.transform;
    }
}
