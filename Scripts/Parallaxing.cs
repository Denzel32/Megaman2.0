using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;
    public float parallaxScale;
    public float ParallaxReductionFactor;
    public float smoothing;

    private Vector3 _lastPosition;

    public void Start()
    {
        _lastPosition = transform.position;
    }

    public void Update()
    {
        var parallax = (_lastPosition.x - transform.position.x) * parallaxScale;

        for(int i = 0; i < backgrounds.Length; i++)
        {
            var backgroundTargetPosition = backgrounds[i].position.x + parallax * (i * ParallaxReductionFactor + 1);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, new Vector3(backgroundTargetPosition, backgrounds[i].position.y,backgrounds[i].position.z), smoothing * Time.deltaTime);
            
        }
        _lastPosition = transform.position;
    }
}