using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private Vector2 minValues;
    [SerializeField]private Vector2 maxValues;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = new Vector3( player.position.x, player.position.y, transform.position.z); 

        transform.position = new Vector3 
        (
            Mathf.Clamp(transform.position.x, minValues.x, maxValues.x),
            Mathf.Clamp(transform.position.y, minValues.y, maxValues.y),
            transform.position.z
        );
    }
}
