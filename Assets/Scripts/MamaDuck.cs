﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class MamaDuck : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup TargetGroup;
    [SerializeField] private float scaleFactor = 20f;
    [SerializeField] private float minVal = 0.8f;
    [SerializeField] private float sinEffect = 0.8f;
    private List<GameObject> ducksFolowing;

    private Vector3 prevPos;
    private float scaleValue = 0.0f;
    private NavMeshAgent navMeshAgent = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ducksFolowing = new List<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        prevPos = transform.position;
    }

    private void Update()
    {
        var currentPos = transform.position;
        
        scaleValue += ((currentPos - prevPos).magnitude + navMeshAgent.speed) * Time.deltaTime;
        var scale = transform.localScale;
        scale.y = minVal + sinEffect * Math.Abs(Mathf.Sin(scaleValue * scaleFactor * Mathf.Deg2Rad));
        transform.localScale = scale;

        prevPos = currentPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ducklings"))
        {
            var duckling = other.GetComponentInParent<DuckFollowing>();
            if (!ducksFolowing.Contains(duckling.gameObject))
            {
                ducksFolowing.Add(duckling.gameObject);
                TargetGroup.AddMember(duckling.transform, 0.8f, 0.5f);
            }
        }
    }
    
    public Transform GetLastDuckInLine()
    {
        
        // TODO(Rok Kos): Fix tommorow
        return gameObject.transform;
        if (ducksFolowing.Count <= 1)
        {
            return gameObject.transform;
        }

        return ducksFolowing.Last().transform;
    }
}
