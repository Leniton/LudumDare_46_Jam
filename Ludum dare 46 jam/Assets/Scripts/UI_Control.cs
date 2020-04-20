using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Control : MonoBehaviour
{
    [Header("Variáveis de balanceamento")]
    [SerializeField] float EstaminaPsegundo = -1;
    [SerializeField] float EstressePsegundo = 1;

    [Space]
    [SerializeField]
    Slider Sanidade, Estamina;
    [SerializeField]
    TextMeshProUGUI Dias, Tempo;
    int Dia,Minuto;

    public int WtoL = 5;
    int workcoin;
    int lazycoin;

    private void Start()
    {
        Dia = 1;
        Minuto = 7 * 60;
        StartCoroutine(ContarTempo());
    }

    IEnumerator ContarTempo()
    {
        do
        {
            yield return new WaitForSeconds(1);

            //MudarEstamina(EstaminaPsegundo);
            //MudarSanidade(EstressePsegundo * Dia);
            Minuto += 1;

            if ((Minuto / 60) >= 24)
            {
                Dia++;
                Minuto = 0;
            }

            AtualizarTempo();
            //print(GameObject.FindGameObjectWithTag("Finish"));
        } while ((Dia < 8) && Sanidade.value < Sanidade.maxValue);

        GameObject g = GameObject.FindGameObjectWithTag("Finish");
        g.transform.GetChild(0).gameObject.SetActive(true);

        if (Sanidade.value >= Sanidade.maxValue)
        {
            g.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "You lost....\n Your stress reached max level";
        }
        else
        {
            g.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Won!!!\n You survived the quarantine!";
        }
    }

    void AtualizarTempo()
    {
        Tempo.text = Mathf.FloorToInt(Minuto/60).ToString("D2") +":"+ (Minuto%60).ToString("D2");
        Dias.text = "Dia: " + Dia;
    }

    public void Timeskip(int time)
    {
        Minuto += time;
        if ((Minuto / 60) >= 24)
        {
            Dia += Mathf.FloorToInt((Minuto/60f)/24);
            Minuto = Minuto - Mathf.FloorToInt((Minuto/60)/24);
        }
        AtualizarTempo();
    }

    public void MudarSanidade(float Quantidade)
    {
        Sanidade.value += Quantidade;
    }

    public void MudarEstamina(float Quantidade)
    {
        Estamina.value += Quantidade;
        
        if(Estamina.value <= Estamina.minValue)
        {
            GameObject A = GameObject.FindGameObjectWithTag("AwakePoint");
            GameObject P = GameObject.FindGameObjectWithTag("Player");
            P.transform.position = A.transform.position;
            A.GetComponentInParent<Objeto_Interagivel>().Interagir();
        }
    }

    public float Stamina()
    {
        return Estamina.value;
    }

    public float Sanity()
    {
        return Sanidade.value;
    }

    public void AddWCoin(int n)
    {
        workcoin += n;
        if(workcoin > WtoL)
        {
            lazycoin += Mathf.FloorToInt(workcoin / WtoL);
            workcoin = workcoin % WtoL;
        }
    }

    public void SpendLcoin(int n)
    {
        lazycoin -= n;
    }
}
