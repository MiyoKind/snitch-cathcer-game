using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax3d : MonoBehaviour
{
    // Start is called before the first frame update
    Material mate;
    float dist;

    [Range(0f, 0.5f)]
    public float speed = 0.2f;

    void Start()
    {
        mate = GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        dist += Time.deltaTime * speed;
        mate.SetTextureOffset("_MainTex", Vector2.right * dist);
    }
}
