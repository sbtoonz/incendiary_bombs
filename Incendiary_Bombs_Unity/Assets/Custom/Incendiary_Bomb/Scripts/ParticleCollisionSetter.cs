using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleCollisionSetter : MonoBehaviour
{
    public ParticleSystem _particles;
    public List<ParticleCollisionEvent> _events;

    void Start(){
        if(!_particles) _particles = gameObject.GetComponent<ParticleSystem>();
        _events = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other){
        int numCollision = _particles.GetCollisionEvents(other, _events);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i =0;
        while( i< numCollision){
           
                    Debug.Log($"Found gameObject : {other.gameObject.name}");
                
            
            i++;
        }
    }
}