using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Fundidos: MonoBehaviour
{
    public Image fundido;

    public string[] escenas; 

    void Start()
    {
        fundido.CrossFadeAlpha(0,0.5f, false);
    }

}
