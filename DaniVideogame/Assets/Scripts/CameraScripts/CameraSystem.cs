using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public GameObject player;
    public float yAxis, zAxis;

    private void Start()
    {
        gameObject.transform.parent = null;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 
                                                        yAxis, player.transform.position.z + zAxis);
    }
}
