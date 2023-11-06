using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager that handles the state of the players health and remaing lives.
/// </summary>
public class HealthManager : MonoBehaviour
{
    private int lives = 9;
    private int health = 10;
    private int maxHealth = 10;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Get the remaining number of lives that the playe has remaining.
    /// </summary>
    /// <returns></returns>
    public int GetLivesRemaining()
    {
        return lives;
    }

    /// <summary>
    /// Returns the players current health.
    /// </summary>
    /// <returns></returns>
    public int GetHealth()
    {
        return health;
    }

    /// <summary>
    /// Decreases a players health by the given amount. 
    /// </summary>
    /// <param name="damage"> The amount to decrease the players health by </param>
    public void DealDamage(int damage)
    {
        health -= damage;
    }

    /// <summary>
    /// Resets the players health back to the maximum health value.
    /// </summary>
    public void ResetHealth()
    {
        health = maxHealth;
    }

}
