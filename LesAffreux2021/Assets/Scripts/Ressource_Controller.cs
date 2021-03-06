using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ressource_Controller : MonoBehaviour
{
    public static Ressource_Controller Instance;
    public Dictionary<Ressource_Type, Ressource> Ressources = new Dictionary<Ressource_Type, Ressource>();
    public Dictionary<Ressource_Type, int> Production = new Dictionary<Ressource_Type, int>();
    public Dictionary<Ressource_Type, int> DailyCost = new Dictionary<Ressource_Type, int>();

    public Slider sliderElectricity;
    public TextMeshPro CurrentElectricity;
    public TextMeshPro MaxElectricity;
    public Slider sliderFood;
    public TextMeshPro CurrentFood;
    public TextMeshPro MaxFood;
    public Slider sliderOxygen;
    public TextMeshPro CurrentOxygen;
    public TextMeshPro MaxOxygen;
    public Slider sliderPlastic;
    public TextMeshPro CurrentPlastic;
    public TextMeshPro MaxPlastic;
    public Slider sliderPopulation;
    public TextMeshPro CurrentPopulation;
    public TextMeshPro MaxPopulation;

    public int NumberOfBuildings = 5;

    // Start is called before the first frame update
    public void Start()
    {
        Instance = this;
        Ressources.Add(Ressource_Type.Electricity, new Ressource(100, 50));
        Ressources.Add(Ressource_Type.Food, new Ressource(100, 50));
        Ressources.Add(Ressource_Type.Oxygen, new Ressource(100, 50));
        Ressources.Add(Ressource_Type.Plastic, new Ressource(100, 50));
        Ressources.Add(Ressource_Type.Population, new Ressource(10, 5));

        Production.Add(Ressource_Type.Electricity, 10);
        Production.Add(Ressource_Type.Food, 10);
        Production.Add(Ressource_Type.Oxygen, 10);
        Production.Add(Ressource_Type.Plastic, 10);

        DailyCost.Add(Ressource_Type.Electricity, 1);
        DailyCost.Add(Ressource_Type.Food, 1);
        DailyCost.Add(Ressource_Type.Oxygen, 1);
        DailyCost.Add(Ressource_Type.Plastic, 0);

        UpdateUI();
    }

    public void IncreaseRessource(Ressource_Type type, int quantity)
    {
        Ressources[type].IncreaseValue(quantity);
        UpdateUI();
    }

    public void IncreaseCapacity(Ressource_Type type, int quantity)
    {
        Ressources[type].IncreaseCapacity(quantity);
        UpdateUI();
    }

    public void DecreaseRessource(Ressource_Type type, int quantity)
    {
        Ressources[type].DecreaseValue(quantity);
        UpdateUI();
    }

    public void DecreaseCapacity(Ressource_Type type, int quantity)
    {
        Ressources[type].DecreaseCapacity(quantity);
        UpdateUI();
    }

    public void IncreaseProduction(Ressource_Type type, int quantity)
    {
        Production[type] += quantity;
        UpdateUI();
    }

    public void NextDay()
    {
        IncreaseRessource(Ressource_Type.Electricity, Production[Ressource_Type.Electricity]);
        DecreaseRessource(Ressource_Type.Electricity, DailyCost[Ressource_Type.Electricity] * NumberOfBuildings);
        IncreaseRessource(Ressource_Type.Food, Production[Ressource_Type.Food]);
        DecreaseRessource(Ressource_Type.Food, DailyCost[Ressource_Type.Food] * Ressources[Ressource_Type.Population].GetCurrentValue());
        IncreaseRessource(Ressource_Type.Oxygen, Production[Ressource_Type.Oxygen]);
        DecreaseRessource(Ressource_Type.Oxygen, DailyCost[Ressource_Type.Oxygen] * NumberOfBuildings);
        IncreaseRessource(Ressource_Type.Plastic, Production[Ressource_Type.Plastic]);
        DecreaseRessource(Ressource_Type.Plastic, DailyCost[Ressource_Type.Plastic]);
        UpdateUI();
    }

    private void UpdateUI()
    {
        sliderElectricity.maxValue = Ressources[Ressource_Type.Electricity].GetCapacity();
        MaxElectricity.text = Ressources[Ressource_Type.Electricity].GetCapacity().ToString();

        sliderFood.maxValue = Ressources[Ressource_Type.Food].GetCapacity();
        MaxFood.text = Ressources[Ressource_Type.Food].GetCapacity().ToString();

        sliderOxygen.maxValue = Ressources[Ressource_Type.Oxygen].GetCapacity();
        MaxOxygen.text = Ressources[Ressource_Type.Oxygen].GetCapacity().ToString();

        sliderPlastic.maxValue = Ressources[Ressource_Type.Plastic].GetCapacity();
        MaxPlastic.text = Ressources[Ressource_Type.Plastic].GetCapacity().ToString();

        sliderPopulation.maxValue = Ressources[Ressource_Type.Population].GetCapacity();
        MaxPopulation.text = Ressources[Ressource_Type.Population].GetCapacity().ToString();

        sliderElectricity.value = Ressources[Ressource_Type.Electricity].GetCurrentValue();
        CurrentElectricity.text = Ressources[Ressource_Type.Electricity].GetCurrentValue() + " (" + (Production[Ressource_Type.Electricity] - DailyCost[Ressource_Type.Electricity]) + ")";

        sliderFood.value = Ressources[Ressource_Type.Food].GetCurrentValue();
        CurrentFood.text = Ressources[Ressource_Type.Food].GetCurrentValue() + " (" + (Production[Ressource_Type.Food] - DailyCost[Ressource_Type.Food]) + ")";

        sliderOxygen.value = Ressources[Ressource_Type.Oxygen].GetCurrentValue();
        CurrentOxygen.text = Ressources[Ressource_Type.Oxygen].GetCurrentValue() + " (" + (Production[Ressource_Type.Oxygen] - DailyCost[Ressource_Type.Oxygen]) + ")";

        sliderPlastic.value = Ressources[Ressource_Type.Plastic].GetCurrentValue();
        CurrentPlastic.text = Ressources[Ressource_Type.Plastic].GetCurrentValue() + " (" + (Production[Ressource_Type.Plastic] - DailyCost[Ressource_Type.Plastic]) + ")";

        sliderPopulation.value = Ressources[Ressource_Type.Population].GetCurrentValue();
        CurrentPopulation.text = Ressources[Ressource_Type.Population].GetCurrentValue().ToString();
    }
}
