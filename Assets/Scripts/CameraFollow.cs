/*
    A script for a camera to smooth follow whatever it's target is.
    Script is customizable in the editor. 
    Variables are public, for in another script you may want to change the target, offset, or even speed of the follow

                                                    Nostro Vostro(Trevor)
*/
using UnityEngine;
using System.Collections;

namespace RPG.Camera
{
    public class CameraFollow : MonoBehaviour
    {

        public Transform target;

        public float speed;

        public float xOffset;
        public float yOffset;

        void FixedUpdate()
        {
            if(target.gameObject != null)
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x+xOffset, speed*Time.deltaTime), 
                                             Mathf.Lerp(transform.position.y, target.position.y+yOffset, speed *Time.deltaTime) , transform.position.z);
        }
    }
}