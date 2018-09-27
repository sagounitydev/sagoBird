using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {

    [SerializeField]private int speed = 3;
    [Header ("LIMITE DE LAS TUBERIAS SUPERIOR")]
    [SerializeField] float LimiteSup = 2;
    [Header("LIMITE DE LAS TUBERIAS INFERIOR")]
    [SerializeField] float LimiteInf = -2;

    void Start() {

        float factorPosition = Random.Range(LimiteInf, LimiteSup);
        this.transform.position = new Vector3(transform.position.x, transform.position.y + factorPosition, transform.position.z);
    }
	
	void Update () {
        if (GameConfig.IsPlaying())
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < -30)
            {
                Destroy(this.gameObject);
            }
        }
	}
}
