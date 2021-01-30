using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class MamaDuck : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup TargetGroup;

    private List<GameObject> ducksFolowing;
    
    // Start is called before the first frame update
    void Start()
    {
        ducksFolowing = new List<GameObject>();
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
