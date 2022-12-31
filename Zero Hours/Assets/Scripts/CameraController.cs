using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float xOffset = 0.09f;
    public float yOffset = 0.34f;
    public float zOffset = -5.12f;

    private float xPlayer = 0;
    private float yPlayer = 0;
    private float zPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        xPlayer = player.transform.position.x;
        yPlayer = player.transform.position.y;
        zPlayer = player.transform.position.z; 

       
        
        transform.position = new Vector3(xPlayer + xOffset, yPlayer + yOffset, zPlayer + zOffset);
        transform.rotation = player.transform.rotation;

         Debug.Log(zPlayer);
         
    }
}
