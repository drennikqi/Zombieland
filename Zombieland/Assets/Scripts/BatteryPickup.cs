using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(addIntensity);
            Destroy(gameObject);
        }
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
