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

    private void Start()
    {
        StartCoroutine(ContarTempo());
    }

    IEnumerator ContarTempo()
    {
        do
        {
            yield return new WaitForSeconds(1);

            MudarEstamina(EstaminaPsegundo);
            MudarSanidade(EstressePsegundo);
            Minuto += 1;

            if((Minuto / 60) == 24)
            {
                Dia++;
                Minuto = 0;
            }

            AtualizarTempo();

        } while (Dia < 7);
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
    }

    public float Stamina()
    {
        return Estamina.value;
    }

    public float Sanity()
    {
        return Sanidade.value;
    }
}
