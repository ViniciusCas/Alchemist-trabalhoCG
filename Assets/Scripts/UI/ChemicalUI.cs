using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChemicalUI : MonoBehaviour
{
    public Text ChemicalIndicator;
    // Update is called once per frame
    void Awake()
    {
        ChemicalIndicator = GetComponent <Text> ();
    }
    void Update()
    {
        if(Player.usingSpell==0)        ChemicalIndicator.text = "Composto Quimico: Etileno (C2H4)";
        else if(Player.usingSpell==1)   ChemicalIndicator.text = "Composto Quimico: Sódio Metálico (Na)";
        else if(Player.usingSpell==2)   ChemicalIndicator.text = "Composto Quimico: Flúor (F)";
        else if(Player.usingSpell==3)   ChemicalIndicator.text = "Composto Quimico: Nitrato de Amônia (NH4NO3)";
        
    }
}
