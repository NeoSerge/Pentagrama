using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionEntradas : MonoBehaviour
{
    [SerializeField] string nombreEscenaColision;

    private void OnCollisionEnter(Collision collision)
    {
        VariablesGlobales.DesactivaVariables();

        if (nombreEscenaColision == "PontAeri")
        {
            VariablesGlobales.toPontAeri = true;
        }

        if (nombreEscenaColision == "Bar")
        {
            VariablesGlobales.toBar = true;
        }

        if (nombreEscenaColision == "Escenary")
        {
            VariablesGlobales.toEscenary = true;
        }

        if (nombreEscenaColision == "Kafe")
        {
            VariablesGlobales.toKafe = true;
        }

        if (nombreEscenaColision == "Primavera")
        {
            VariablesGlobales.toPrimavera = true;
        }

        SceneManager.LoadScene("2_Lobby");
        
    }
}
