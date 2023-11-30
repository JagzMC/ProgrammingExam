using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("Ball");
        BallController bac = obj.GetComponent<BallController>();
        if (!bac.GetIsFalling() && bac.GetGo())
        {
            if (bac.GetCurrentAxis() == 0) transform.position += new Vector3(bac.GetSpeed() / 30f, 0, 0);
            if (bac.GetCurrentAxis() == 1) transform.position += new Vector3(0, 0, bac.GetSpeed() / 30f);
        }
    }
}
