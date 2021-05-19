using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarManager : MonoBehaviour
{
    public Image[] bars;
    public Sprite bar;
    public FloatValue energyBars;
    public FloatValue playerCurrentHealth;
    private int count = 0;
    // Start is called before the first frame update
    
   
    void Start()
    {
        InitBars();
    }
    public void InitBars()
    {
        for(int i = 0; i < 10; i++)
        {
            bars[i].gameObject.SetActive(false);
           // bars[i].sprite = bar;
        }
    }

    public void UpdateBars()
    {
        //float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        // count++;
        Debug.Log(playerCurrentHealth.RuntimeValue);
        //Debug.Log(playerCurrentHealth.RuntimeValue);
        //Debug.Log(tempHealth);
        if (count <= 9)
        {

            bars[count].gameObject.SetActive(true);
            bars[count].sprite = bar;


        }
        count++;
    }
}
