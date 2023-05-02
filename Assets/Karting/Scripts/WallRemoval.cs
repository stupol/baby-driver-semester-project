using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemoval : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collision collision){
        if (collision.gameObject.name == "KartClassic_Player"){
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    
}
