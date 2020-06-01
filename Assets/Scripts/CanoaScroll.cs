using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoaScroll : MonoBehaviour
{
    Material mat;
    Vector2 offset;

    public float xVelocity, yVelocity;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += offset * Time.deltaTime;
    }
}
