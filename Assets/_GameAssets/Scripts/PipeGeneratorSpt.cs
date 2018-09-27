using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneratorSpt : MonoBehaviour {

    [SerializeField] Transform prefabTuberia;
    [Header("CANTIDAD DE TUBERIAS")]
    [SerializeField] float ratioGeneracionTuberias = 1f;

    // Use this for initialization
    void Start () {

        InvokeRepeating("GeneratePipe", 0, ratioGeneracionTuberias);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void GeneratePipe () {
        //Generador de tuberias
        if (GameConfig.IsPlaying())
        {
            Instantiate(prefabTuberia, transform.position, Quaternion.identity);
        }
        
    }
}
