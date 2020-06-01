using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGloveMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 15.949f;

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
