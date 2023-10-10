using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleCollisionSetter : MonoBehaviour
{
    public ParticleSystem _particles;
    public List<ParticleCollisionEvent> _events;

    public GameObject AOEObject;

    void Start(){
        if(!_particles) _particles = gameObject.GetComponent<ParticleSystem>();
        _events = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other){
        int numCollision = _particles.GetCollisionEvents(other, _events);
        Collider rb = other.GetComponent<Collider>();
        int i =0;
        while( i< numCollision)
        {
            if (other.transform.root.gameObject.GetComponent<Piece>())
            {
                Debug.Log($"Fire hit piece {other.transform.root.gameObject.GetComponent<Piece>().m_name}");
            } ;
            i++;
        }
    }
}