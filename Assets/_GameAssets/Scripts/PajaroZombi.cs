using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PajaroZombi : MonoBehaviour {

    [SerializeField] ParticleSystem prefabExplosion;
    [SerializeField] Text marcadorPuntos;
    [SerializeField] float fuerza = 10f;
    [SerializeField] AudioSource audioBoom;
    [SerializeField] AudioSource audioJump;
    [SerializeField] AudioSource audioPoint;

    private Rigidbody rb;
    private int puntos = 0;
    
    void Start () {
        GameConfig.ArrancaJuego();
        rb = GetComponent<Rigidbody>();
        ActualizarMarcador();        
	}
	
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * fuerza);
            //Sonido Salto
            audioJump.Play();
        }
	}

    private void ActualizarMarcador()
    {
        marcadorPuntos.text = "Score: " + puntos.ToString();
        //Sonido Punto
        if (puntos > 0)
        {
            audioPoint.Play();
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        puntos++;
        ActualizarMarcador();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Sonido explosion
        audioBoom.Play();

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
