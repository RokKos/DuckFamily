using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDucks : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> ducks = null;
    void Start()
    {
        var numDucks = PlayerPrefs.GetInt("DucksFound", 7);

        for (int i = 0; i < numDucks; i++)
        {
            ducks[i].SetActive(true);
        }
        
        for (int i = numDucks; i < ducks.Count; i++)
        {
            ducks[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
