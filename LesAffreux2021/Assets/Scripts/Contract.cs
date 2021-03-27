using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Contract_type { capacity, value }

//Exemple avec panneau solaire
public class Contract : MonoBehaviour
{   
    public string _name; // Nom du contrat
    public Ressource ressource_used; //Plastic
    public int qty_used; // Qty used 
    public Ressource ressource_gained; //Electricity
    public int qty_gained; //qty of ressource gained
    
    [SerializeField]
    private Contract_type type;

    public void on_sign_contract()
    {
        ressource_used.decrease_value(qty_used);
        if (type == Contract_type.capacity) ressource_gained.increase_capacity(qty_gained);
        else ressource_gained.increase_value(qty_gained);
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
