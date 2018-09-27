using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PajaroZombi : MonoBehaviour {

    [SerializeField] ParticleSystem prefabExplosion;
    [SerializeField] Text marcadorPuntos;
    [SerializeField] float fuerza = 10f;
    private int puntos = 0;
    private Rigidbody rb;

    //private AudioSource();

	void Start () {
        GameConfig.ArrancaJuego();
        rb = GetComponent<Rigidbody>();
        ActualizarMarcador();
        //AudioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * fuerza);
        }
	}

    private void ActualizarMarcador()
    {
        marcadorPuntos.text = "Score: " + puntos.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        puntos++;
        ActualizarMarcador();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //SONIDO COLISION
        //AudioSource
        
        //CREANDO PARTICULAS
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        //DESACTIVAR RENDER
        gameObject.SetActive(false);
        //PARAR TUBERIAS
        GameConfig.ParaJuego();
        //LLAMAR A FINALIZAR LA PARTIDA (TRAS 1 seg)
        Invoke("FinalizarPartida", 3f);    
    }

    private void FinalizarPartida()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }
}
