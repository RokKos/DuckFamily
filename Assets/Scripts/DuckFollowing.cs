﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFollowing : MonoBehaviour
{
    [SerializeField] private ParticleSystem feather_particles = null;
    
    NavMeshAgent m_Agent;

    private Transform playerTransform = null;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            m_Agent.destination = playerTransform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.tag.Equals("Player") && playerTransform == null)
        {
            var mamaObj = other.gameObject;
            var mamaDuck = mamaObj.GetComponentInParent<MamaDuck>();
            playerTransform = mamaDuck.GetLastDuckInLine();
            m_Agent.autoBraking = true;
        }

        if (other.tag.Equals("Spikes"))
        {
            var feather_obj = Instantiate(feather_particles, transform.position, Quaternion.identity);
            feather_obj.Play();
            Destroy(feather_obj.gameObject, 1.0f);
            Destroy(gameObject);
        }
    }
}
