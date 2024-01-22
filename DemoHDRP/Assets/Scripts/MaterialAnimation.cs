using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimation : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public Material[] materials;

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Material mat in materials)
        {
            mat.mainTextureOffset += dir * speed * Time.deltaTime;
        }
    }
}
