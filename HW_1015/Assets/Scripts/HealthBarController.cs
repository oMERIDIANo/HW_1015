using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = GameManager.instance.MaxHealth = 100;
        slider.value = GameManager.instance.Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.instance.Health;
    }

}
