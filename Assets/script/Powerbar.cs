using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    
    private void  SetPower(int throwForce){
        slider.value = throwForce;
    }
    
}
