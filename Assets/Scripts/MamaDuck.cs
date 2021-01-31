using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MamaDuck : MonoBehaviour
{
    [SerializeField] private GameObject Marker = null;
    [SerializeField] private CinemachineTargetGroup TargetGroup;
    [SerializeField] private float scaleFactor = 20f;
    [SerializeField] private float minVal = 0.8f;
    [SerializeField] private float sinEffect = 0.8f;
    private List<GameObject> ducksFolowing;

    private Vector3 prevPos;
    private float scaleValue = 0.0f;
    private NavMeshAgent navMeshAgent = null;

    [SerializeField] private Text duckFoundText = null;
    
    [SerializeField] private AudioSource quack;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ducksFolowing = new List<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        prevPos = transform.position;
        Marker.SetActive(false);
        duckFoundText.text = ducksFolowing.Count.ToString() + "/7"; 
    }

    private void Update()
    {
        if (navMeshAgent.hasPath)
        {
            Marker.SetActive(true);
            Marker.transform.position = navMeshAgent.destination;    
        }
        else
        {
            Marker.SetActive(false);
        }

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
                quack.Play();
                ducksFolowing.Add(duckling.gameObject);
                var numDucs = Math.Min(7, ducksFolowing.Count);
                duckFoundText.text =  numDucs.ToString() + "/7";
                TargetGroup.AddMember(duckling.transform, 0.8f, 0.5f);
            }
        } else if (other.tag.Equals("Finish") && ducksFolowing.Count == 5)
        {
            PlayerPrefs.SetInt("DucksFound", ducksFolowing.Count);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Finish");
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
