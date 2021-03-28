using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDay : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pen" && Game_Controller.Instance.CanSkipDay())
        {
            Game_Controller.Instance.OnNextDay();
            Debug.Log("NextDay");
        }
    }
}
