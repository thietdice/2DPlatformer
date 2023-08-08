using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Follower : MonoBehaviour
{
    [SerializeField] private GameObject[] wp;
    private int CurrentWayPointIndex = 0;
    // Start is called before the first frame update
    [SerializeField] private float speed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(wp[CurrentWayPointIndex].transform.position, transform.position) < .1f)
        {
            CurrentWayPointIndex++;
            if (CurrentWayPointIndex >= wp.Length)
            {
                CurrentWayPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wp[CurrentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
