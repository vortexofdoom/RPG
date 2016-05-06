using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// A script for a camera to smooth follow whatever it's target is. [NostroVostro]<para>
/// Script is customizable in the editor.</para>
/// Variables are public, for in another script you may want to change the target, offset, or even speed of the follow
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float speed;

    public float xOffset;
    public float yOffset;

    void FixedUpdate()
    {
        // For readability, probably best to have brackets for if statements that go over 1 physical line (Even if it is actually just 1 line of code)
        if (target.gameObject != null) { 
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x + xOffset, speed * Time.deltaTime),
                                            Mathf.Lerp(transform.position.y, target.position.y + yOffset, speed * Time.deltaTime), transform.position.z);
        }
    }
}