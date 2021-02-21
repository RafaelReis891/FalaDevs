using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop_Instance : MonoBehaviour
{
    public GameObject Ball;
    public int maxBalls = 1000;
    public float timeRespaw = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create_Player", 0, timeRespaw);
    }

    public void Create_Player()
    {
        GameObject player = Instantiate(Ball, transform.position, Quaternion.identity);
    }
}
