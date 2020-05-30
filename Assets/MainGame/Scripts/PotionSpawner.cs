using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject potion;
    public GameObject healFX;
    public float chance = .1f;
    public float maxHealth = 3f;
    public void Spawn()
    {
        if (Random.Range(0f, 1f) < chance && PlayerStats.Instance.Health <= maxHealth)
        {
            Instantiate(potion, new Vector3(Random.Range(-8f, 8f), 2f, 198f), Quaternion.identity).GetComponent<Potion>().healFX = healFX;
        }
    }
}
