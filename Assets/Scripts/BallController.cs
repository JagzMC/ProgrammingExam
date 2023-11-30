
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{

    public GameObject plat;

    [SerializeField] public float speed;
    private int currentAxis = 1;
    private bool isGrounded;
    private bool isFalling;
    private bool gameOver;
    private bool go;
    private float lastX = 4;
    private float lastZ = 6;
    private int Block = 0;
    private int timer = 0;
    private int blockSpawn = 0;
    private int GOTimer = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Create();
        }
        
        
    }

    public void Create()
    {
        string n;
        GameObject obj = Instantiate(plat, new Vector3(0, 0, 0), Quaternion.identity);
        PlatformSpawner pts = obj.GetComponent<PlatformSpawner>();
        if (Random.Range(0, 2) == 0) n = "X";
        else n = "Z";
        if (Random.Range(0, 5) == 0) pts.SetDiaSpawn(true);
        Debug.Log("" + lastX + ", " + lastZ);
        pts.SetX(lastX);
        pts.SetZ(lastZ);
        pts.SetDir(n);
        if (n.Equals("X")) lastX += 2;
        else if (n.Equals("Z")) lastZ += 2;
        n = n + Block.ToString();
        pts.name = n;
        pts.Activate();
        Block++;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = false;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentAxis == 0) currentAxis = 1;
            else currentAxis = 0;
            go = true;
        }
        
        if (go)
        {
            blockSpawn++;
            if (blockSpawn >= 40)
            {
                Create();
                blockSpawn = 0;
            }
            if (isGrounded)
            {
                isFalling = false;
                timer = 0;
                if (currentAxis == 0) transform.position += new Vector3(speed / 30f, 0, 0);
                if (currentAxis == 1) transform.position += new Vector3(0, 0, speed / 30f);

            }
            else
            {
                timer++;
                if (timer >= 40)
                {
                    transform.position += new Vector3(0, -0.01f, 0);
                    isFalling = true;
                    gameOver = true;
                }
                else
                {
                    if (currentAxis == 0) transform.position += new Vector3(speed / 30f, 0, 0);
                    if (currentAxis == 1) transform.position += new Vector3(0, 0, speed / 30f);
                }
            }

            if (gameOver)
            {
                GOTimer++;
                if (GOTimer >= 500)
                {
                    go = false;
                    GameOver();
                }
            }
            else GOTimer = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Platform"))
        {
            isGrounded = true;
        }

        if (other.gameObject.tag.Equals("Diamond"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag.Equals("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag.Equals("Platform"))
        {
            isGrounded = false;
            other.gameObject.tag = "Falling";
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            go = true;
            GOTimer = 0;
        }
    }

    public int GetCurrentAxis()
    {
        return currentAxis;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public bool GetIsFalling()
    {
        return isFalling;
    }

    public bool GetGo()
    {
        return go;
    }
}
