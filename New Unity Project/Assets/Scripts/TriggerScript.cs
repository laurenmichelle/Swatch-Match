using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject cubes1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cubes1.SetActive(true);
        Debug.Log("You have triggered the cube");
    }

    private void OnTriggerExit(Collider other) 
    {
        cubes1.SetActive(false);
        Debug.Log("you have left the trigger");
    }
}
