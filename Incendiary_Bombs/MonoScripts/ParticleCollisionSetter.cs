using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ParticleCollisionSetter : MonoBehaviour
{
    public ParticleSystem _particles;
    public GameObject AOEObject;
    internal bool hitalready = false;
    
    [SerializeField] private List<ParticleCollisionEvent>? _collisionEvents;

    private void Awake()
    {
        AOEObject = ZNetScene.instance.GetPrefab("incendiary_explosion");
    }

    void Start(){
        if(!_particles) _particles = gameObject.GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other){
        if (_particles == null)
        {
            return;
        }

        _collisionEvents = new List<ParticleCollisionEvent>();
        if (!other) return;
        var numCollisions = _particles.GetCollisionEvents(other, _collisionEvents);
        for (var i = 0; i < numCollisions; i++)
        {
            if(other.GetComponent<CaughtFire>())continue;
            if(hitalready)continue;
            if (other.transform.root.gameObject.GetComponent<Piece>() == null || other.gameObject.GetComponent<Destructible>() != null) continue;
            Random.InitState(i);
            var l = Random.Range(0, 10);
            if (l > 5) continue;
            var obj = Instantiate(AOEObject, other.transform.position, Quaternion.identity);
            var part = obj.transform.Find("particles").gameObject.GetComponentInChildren<ParticleCollisionSetter>();
            if(l < 3)part.enabled = false;
            hitalready = true;
            other.AddComponent<CaughtFire>();
        }
    }
}