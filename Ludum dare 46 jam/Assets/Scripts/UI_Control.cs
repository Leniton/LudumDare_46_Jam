using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Control : MonoBehaviour
{
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

            Minuto += 1;

            if((Minuto / 60) == 24)
            {
                Dia++;
                Minuto = 0;
            }

            AtualizarTempo();

        } while (Dia < 40);
    }

    void AtualizarTempo()
    {
        Tempo.text = Mathf.FloorToInt(Minuto/60).ToString("D2") +":"+ (Minuto%60).ToString("D2");
        Dias.text = "Dia: " + Dia;
    }

    public void MudarSanidade(float Quantidade)
    {
        Sanidade.value += Quantidade;
    }

    public void MudarEstamina(float Quantidade)
    {
        Estamina.value += Quantidade;
    }
}
