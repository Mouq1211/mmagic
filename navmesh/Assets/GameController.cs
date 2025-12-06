using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text _Vida;
    public Text _Kills;

    private int qtd_inimigos;
    public void setVida(float value) 
    {
        _Vida.text = value.ToString();
    }

    public void setKills()
    {
        qtd_inimigos += 1;
        _Kills.text = qtd_inimigos.ToString();
    }
}
