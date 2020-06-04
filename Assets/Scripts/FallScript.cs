using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    public float velocity;

    // Update is called once per frame
    void Update()
    {
        Transform transform = GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x, transform.position.y - (velocity * Time.deltaTime));
    }
}
