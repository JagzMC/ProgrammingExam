using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    
    private float x;
    private float z;
    
    public void Activate()
    {
        transform.position = new Vector3(x, 1f, z);
    }
    
    public void SetX(float x)
    {
        this.x = x;
    }
    public void SetZ(float z)
    {
        this.z = z;
    }

}
