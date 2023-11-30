using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] public GameObject diamond;
    
    private float x;
    private float z;
    private string dir;
    private int timer = 0;
    private bool diaSpawn;
    
    void Update()
    {
        if (tag.Equals("Falling")) timer++;
        if (timer >= 50) Fall();
        if (timer >= 500) Destroy(gameObject);
    }

    public void Activate()
    {
        if(dir.Equals("X")) transform.position = new Vector3(x, 0, z);
        else if (dir.Equals("Z")) transform.position = new Vector3(x, 0, z);
        if (diaSpawn) Create();
    }
    
    public void Create()
    {
        GameObject obj = Instantiate(diamond, new Vector3(x, 1.3f, z), Quaternion.identity);
        DiamondSpawner dia = obj.GetComponent<DiamondSpawner>();
        dia.SetX(x);
        dia.SetZ(z);
        dia.Activate();
    }

    public void Fall()
    {
        transform.position += new Vector3(0, -0.01f, 0);
    }

    public void SetX(float x)
    {
        this.x = x;
    }
    public void SetZ(float z)
    {
        this.z = z;
    }

    public void SetDir(string dir)
    {
        this.dir = dir;
    }

    public void SetDiaSpawn(bool diaSpawn)
    {
        this.diaSpawn = diaSpawn;
    }
}
