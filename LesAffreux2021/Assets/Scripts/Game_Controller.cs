using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public static Game_Controller Instance;
    private bool canSkipDay = false;
    public GameObject Contracts;
    public List<Contract> ContractsPrefab = new List<Contract>();
    private List<Contract> SignedContracts = new List<Contract>();
    private List<Contract> CurrentContracts = new List<Contract>();
    public GameObject Pen;
    private Transform PenStartPosition;
    public TextMeshPro DaysLeft;
    private int DaysLeftCount;
    public Transform ContractOffset;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        PenStartPosition = Pen.transform;
        NewContracts();
        DaysLeftCount = 5;
        DaysLeft.text = DaysLeftCount.ToString();
    }

    public bool CanSkipDay()
    {
        return canSkipDay;
    }

    public void OnNextDay()
    {
        if (DaysLeftCount > 0)
        {
            DaysLeftCount--;
        }
        else
        {
            DaysLeftCount = Random.Range(5, 11);
            Ressource_Controller.Instance.IncreaseRessource(Ressource_Type.Population, Random.Range(1, 11));
        }
        DaysLeft.text = DaysLeftCount.ToString();
        canSkipDay = false;
        Debug.Log("Can Skip Day? " + canSkipDay);
        Ressource_Controller.Instance.NextDay();
        //Pen.transform.position = new Vector3(PenStartPosition.position.x, PenStartPosition.position.y, PenStartPosition.position.z);
        NewContracts();
    }

    private void ClearCurrentContracts()
    {
        int n = Contracts.transform.childCount;
        Debug.Log("child: " + n);
        for (int i = n; i > 0; i--)
        {
            Debug.Log(CurrentContracts[i - 1].Signed);
            Contracts.transform.GetChild(i-1).gameObject.SetActive(CurrentContracts[i-1].Signed);
        }
        Contracts.transform.DetachChildren();
        CurrentContracts.Clear();
    }

    private void NewContracts()
    {
        CurrentContracts.Add(Instantiate(GetRandomGameObject(ContractsPrefab),  Contracts.transform));
        CurrentContracts.Add(Instantiate(GetRandomGameObject(ContractsPrefab),  Contracts.transform));
    }

    public void OnSignature(Contract contract)
    {
        Debug.Log("OnSignature After");
        Debug.Log("CanSkipDay? " + canSkipDay);
        canSkipDay = true;
        SignedContracts.Add(contract);
        ClearCurrentContracts();
    }

    public Contract GetRandomGameObject(List<Contract> objects)
    {
        Contract contract = objects[Random.Range(0, objects.Count)];
        contract.Offset = ContractOffset;
        return contract;
    }
}
