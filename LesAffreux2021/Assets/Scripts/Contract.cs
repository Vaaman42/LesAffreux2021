using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Contract_type { capacity, value }

//Exemple avec panneau solaire
public class Contract : MonoBehaviour
{   
    public string _name; // Nom du contrat
    public TextMeshPro ressource_used_text;
    public Ressource ressource_used; //Plastic
    public TextMeshPro qty_used_text;
    public int qty_used; // Qty used 
    public TextMeshPro ressource_gained_text;
    public Ressource ressource_gained; //Electricity
    public TextMeshPro qty_gained_text;
    public int qty_gained; //qty of ressource gained
    
    [SerializeField]
    private Contract_type type;

    public void on_sign_contract()
    {
        ressource_used.DecreaseValue(qty_used);
        if (type == Contract_type.capacity) ressource_gained.IncreaseCapacity(qty_gained);
        else ressource_gained.IncreaseValue(qty_gained);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
