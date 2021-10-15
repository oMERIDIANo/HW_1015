using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Ammo_Count;
    public int MaxHealth = 100;
    public int Health = 100;
    public int num_of_enemies = 21;
    public int boss_health = 100;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        Ammo_Count = 0;
        num_of_enemies = 21;
        lives = 3;
        MaxHealth = 100;
        Health = 100;
        lives = 3;

        if (instance == null)
        {
            instance = this;
        }

        if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
