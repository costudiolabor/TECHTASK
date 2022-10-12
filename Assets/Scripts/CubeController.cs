using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speedObject = 1.0f;
    private float distanceMove = 5.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        //SetInit(speedObject, distanceMove);
    }

    private void Update()
    {
        CheckDistance();
        Movement();
    }


    public void SetInit(float speedObject, float distanceMove)
    {
        gameObject.SetActive(true);
        this.speedObject = speedObject;
        this.distanceMove = distanceMove;

        startPosition.x = Random.Range(-5, 5);
        transform.position = startPosition;
        endPosition = startPosition + Vector3.forward * distanceMove;
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, endPosition) < 0.001f) DisableObject();
    }

    private void Movement()
    {
        var step = speedObject * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

}
