using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interagir : MonoBehaviour
{
    [SerializeField]
    GameObject BarraDeProgresso, BotaoInteragir;
    Objeto_Interagivel Atual;

    bool Interagindo = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (BotaoInteragir.activeSelf)
        {
            BotaoInteragir.transform.position = transform.GetChild(0).position;
            if (Input.GetKeyDown(KeyCode.F))
            {
                BotaoInteragir.SetActive(false);
                GetComponent<TopDownMovement>().enabled = false;
                BarraDeProgresso.SetActive(true);
                BarraDeProgresso.transform.position = transform.GetChild(0).position;
                StartCoroutine(ProgressoInteracao(Atual.DuraçãoAtividade));

            }
        }
    }

    IEnumerator ProgressoInteracao(float duracao)
    {
        //BarraDeProgresso.GetComponent<Slider>().maxValue = duracao;
        Time.timeScale = 6;
        do
        {
            yield return new WaitForSeconds(duracao / 40);
            BarraDeProgresso.GetComponent<Slider>().value += 1.0f/40;

        } while (BarraDeProgresso.GetComponent<Slider>().value < 1);


        GetComponent<TopDownMovement>().enabled = true;
        BarraDeProgresso.SetActive(false);
        BarraDeProgresso.GetComponent<Slider>().value = 0;
        Time.timeScale = 1;
        Atual.Interagir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Objeto_Interagivel>() == null) return;

        Atual = collision.GetComponent<Objeto_Interagivel>();

        BotaoInteragir.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Atual = null;
        BotaoInteragir.SetActive(false);
    }
}
