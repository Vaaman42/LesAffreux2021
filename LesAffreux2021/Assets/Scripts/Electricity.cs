using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electricity : MonoBehaviour
{

    private int ElectricityCount = 150;

    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
        text.text = ElectricityCount.ToString();
    }

}
