using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFollowing : MonoBehaviour
{
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
        if (other.tag.Equals("Player"))
        {
            playerTransform = other.transform;
            m_Agent.autoBraking = true;
            m_Agent.isStopped = false;
        }
    }
}
