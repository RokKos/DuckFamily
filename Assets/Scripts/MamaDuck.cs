using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MamaDuck : MonoBehaviour
{
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
            ducksFolowing.Add(other.gameObject);
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
