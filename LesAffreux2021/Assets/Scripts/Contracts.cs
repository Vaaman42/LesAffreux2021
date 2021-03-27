using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contracts : MonoBehaviour
{
    [SerializeField]
    List<Ressource> ressources = new List<Ressource>();

    // Start is called before the first frame update
    void Start()
    {
        // Fill the List with object Ressource
        foreach (Ressource res in ressources) 
        {
            Debug.Log(res.ressource_name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
