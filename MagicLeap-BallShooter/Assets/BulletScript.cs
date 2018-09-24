using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public GameObject Particles;
    bool _collisionDone;


    private void OnCollisionEnter(Collision collision)
    {
        if(!_collisionDone)
        {
            _collisionDone = true; // the spatial mapper object redraws meshed room objects several times, this stops multiple collisions with same object.
            Instantiate(Particles, collision.contacts[0].point, transform.rotation);
        }
        Debug.Log(collision.gameObject.name);    
    }
}
