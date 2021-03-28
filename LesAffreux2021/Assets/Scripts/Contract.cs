using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Contract_type { capacity, production }

//Exemple avec panneau solaire
public class Contract : MonoBehaviour
{   
    public string _name; // Nom du contrat
    public TextMeshPro ContractName;
    public TextMeshPro ressource_used_text;
    public Ressource_Type ressource_used; //Plastic
    public int qty_used; // Qty used 
    public TextMeshPro ressource_gained_text;
    public Ressource_Type ressource_gained; //Electricity
    public int qty_gained; //qty of ressource gained
    public TextMeshPro Signature;
    
    [SerializeField]
    private Contract_type type;

    void Start()
    {
        ContractName.text = _name;
        ressource_used_text.text = Translate(ressource_used) + " x" + qty_used;
        ressource_gained_text.text = Translate(ressource_gained) + " x" + qty_gained;
    }

    public void on_sign_contract()
    {
        Ressource_Controller.Instance.NumberOfBuildings++;
        Ressource_Controller.Instance.DecreaseRessource(ressource_used, qty_used);
        if (type == Contract_type.capacity) 
            Ressource_Controller.Instance.IncreaseCapacity(ressource_used, qty_used);
        else 
            Ressource_Controller.Instance.IncreaseProduction(ressource_used, qty_used);
        Signature.gameObject.SetActive(true);
    }

    private string Translate(Ressource_Type type)
    {
        string trType = "";
        switch (type)
        {
            case Ressource_Type.Electricity:
                trType = "Electricité";
                break;
            case Ressource_Type.Oxygen:
                trType = "Oxygène";
                break;
            case Ressource_Type.Food:
                trType =  "Nourriture";
                break;
            case Ressource_Type.Population:
                trType =  "Population";
                break;
            case Ressource_Type.Plastic:
                trType = "Plastique";
                break;
        }
        return trType;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pen")
            on_sign_contract();
    }
}
