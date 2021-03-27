using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ressources : MonoBehaviour
{
    Text text;
    public int current_max_capacity; //  Current capacity for this.ressource => public because we can put in unity the value for this ressource
    private int _current_ressource = 0; // Current value of ressource
    //private float _multiplicator = 1; // Multiplicator value of ressource
    public string ressource_name;

    public void increase_value(int value) { // Increase the current value of the ressource
        this._current_ressource += value;
        if (this.current_max_capacity <= this._current_ressource) {
            this._current_ressource = this.current_max_capacity;
        }
        text.text = ressource_name  + " " + _current_ressource.ToString() + "/" + current_max_capacity.ToString();
    }

    public void decrease_value(int value) { // Decrease the current value of the ressource
        this._current_ressource -= value;
        if (this._current_ressource <= 0) {
            this._current_ressource = 0;
        }
    }

    public void increase_capacity(int value) { // Increase the current max capacity of the ressource
        this.current_max_capacity += value;
    }

    public void decrease_capacity(int value) { // Decrease the current max capacity of the ressource
        this.current_max_capacity -= value;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = ressource_name  + " " + _current_ressource.ToString() + "/" + current_max_capacity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
