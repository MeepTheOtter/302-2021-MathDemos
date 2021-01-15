using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public GameObject startObject;
    public GameObject endObject;

    public float percent = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoTheLerp();
    }

    private void DoTheLerp()
    {
        transform.position = AnimMath.Lerp(startObject.transform.position, endObject.transform.position, percent);
    }

    private void OnValidate()
    {
        DoTheLerp();
    }
}
