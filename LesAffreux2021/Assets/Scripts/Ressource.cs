using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ressource
{
    private int Capacity; //  Current capacity for this.ressource => public because we can put in unity the value for this ressource
    private int CurrentValue; // Current value of ressource
    //private float _multiplicator = 1; // Multiplicator value of ressource

    public Ressource(int capacity, int value)
    {
        Capacity = capacity;
        CurrentValue = value;
    }

    public int GetCurrentValue()
    {
        return CurrentValue;
    }
    public int GetCapacity()
    {
        return Capacity;
    }

    public void IncreaseValue(int value) 
    { // Increase the current value of the ressource
        CurrentValue += value;
        if (Capacity <= CurrentValue) 
        {
            CurrentValue = Capacity;
        }
    }

    public void DecreaseValue(int value) 
    { // Decrease the current value of the ressource
        CurrentValue -= value;
        if (CurrentValue <= 0) 
        {
            CurrentValue = 0;
        }
    }

    public void IncreaseCapacity(int value) 
    { // Increase the current max capacity of the ressource
        Capacity += value;
    }

    public void DecreaseCapacity(int value) 
    { // Decrease the current max capacity of the ressource
        Capacity -= value;
    }
}
