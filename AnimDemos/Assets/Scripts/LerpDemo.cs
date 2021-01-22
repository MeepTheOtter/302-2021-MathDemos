using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public GameObject startObject;
    public GameObject endObject;

    [Range(-1, 2)] public float percent = 0;

    public float animLength = 2;
    private float animTime = 0;
    private bool isAnimPlaying = false;

    public AnimationCurve animationCurve;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAnimPlaying) {
            animTime += Time.deltaTime;

            percent = animTime / animLength;
            percent = Mathf.Clamp(percent, 0, 1);

            percent = animationCurve.Evaluate(percent);

            //percent = percent * percent * (3 - 2 * percent);

            DoTheLerp();

            if (percent >= 1) isAnimPlaying = false;
        }
        
    }

    private void DoTheLerp()
    {
        transform.position = AnimMath.Lerp(startObject.transform.position, endObject.transform.position, percent);
    }

    public void PlayTween() 
    {
        isAnimPlaying = true;
        animTime = 0;    
    }

    private void OnValidate()
    {
        DoTheLerp();
    }
}
