using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interagir : MonoBehaviour
{
    [SerializeField]
    GameObject BarraDeProgresso, BotaoInteragir,Pop_Up;
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
            Pop_Up.transform.position = transform.GetChild(1).position;
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
        yield return new WaitForSeconds(1);

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

        Pop_Up.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Atual.name;
        Pop_Up.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Energy: " + Atual.Estamina;
        Pop_Up.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Stress" + Atual.Estresse;
        Pop_Up.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Duration: " + Atual.DuraçãoAtividade + "min";
        int h = Mathf.FloorToInt(Atual.CoolDown / 60);
        int m = (int)Atual.CoolDown % 60;
        Pop_Up.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Cooldown: " + h.ToString("D2") + ":" + m.ToString("D2");

        Pop_Up.SetActive(true);

        BotaoInteragir.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Atual == null) return;
        if (collision.GetComponent<Objeto_Interagivel>() != Atual) return;
        Atual = null;
        BotaoInteragir.SetActive(false);
        Pop_Up.SetActive(false);
    }
}
