using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChemicalUI : MonoBehaviour
{
    private Text ChemicalIndicator;

    void Awake()
    {
        ChemicalIndicator = GetComponent <Text>();
    }
    void Update()
    {
        if(Player.usingSpell==0)        ChemicalIndicator.text = "Composto Quimico: Sódio metálico (Na)";
        else if(Player.usingSpell==1)   ChemicalIndicator.text = "Composto Quimico: Amônia (HN3)";
        else if(Player.usingSpell==2)   ChemicalIndicator.text = "Composto Quimico: Óxido de ferro (Fe2O3)";
        else if(Player.usingSpell==3)   ChemicalIndicator.text = "Composto Quimico: Ácido cloridrico (HCl)";
    }
}
