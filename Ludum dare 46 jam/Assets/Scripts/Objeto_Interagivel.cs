using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_Interagivel : MonoBehaviour
{
    [Tooltip("Duração da atividade em segundos tempo real(o tempo acelera durante a atividade, lembre disso)")]
    public float DuraçãoAtividade;
    [Space]
    public float Estamina;
    public float Estresse;

    public float CoolDown;
    public float Alpha;

    [Space]
    [SerializeField] bool pulaTempo;
    [Tooltip("Minutos do jogo")][SerializeField] float quanto;

    [Space]
    public int Workcoin;
    public int lazycoin;

    public void Interagir()
    {
        UI_Control u = (UI_Control)FindObjectOfType(typeof(UI_Control));
        u.MudarEstamina(Estamina);
        u.MudarSanidade(Estresse);
        if (lazycoin > 0)
        {
            u.SpendLcoin(lazycoin);
        }else if(Workcoin > 0)
        {
            u.AddWCoin(Workcoin);
        }
        else
        {

        }


        if (pulaTempo)
        {
            Pulartempo();
        }

        //Ativo = false;
        StartCoroutine(Reativando(CoolDown));
    }

    void Pulartempo()
    {
        UI_Control u = (UI_Control)FindObjectOfType(typeof(UI_Control));
        u.Timeskip(Mathf.RoundToInt(quanto));
    }

    IEnumerator Reativando(float t)
    {
        Collider2D trigger = GetComponents<Collider2D>()[1];
        trigger.enabled = false;

        Color c = GetComponent<SpriteRenderer>().color;
        c.a = Alpha;
        GetComponent<SpriteRenderer>().color = c;
        yield return new WaitForSeconds(t);
        trigger.enabled = true;

        c.a = 1f;
        GetComponent<SpriteRenderer>().color = c;
    }
}
