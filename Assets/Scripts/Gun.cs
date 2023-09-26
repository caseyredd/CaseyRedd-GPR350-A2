using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// The direction of the initial velocity of the fired projectile. That is,
    /// this is the direction the gun is aiming in.
    /// </summary>
    public int weapon = 1;
    [SerializeField] GameObject weapon1;
    [SerializeField] GameObject weapon2;
    [SerializeField] GameObject weapon3;
    [SerializeField] GameObject weapon4;
    [SerializeField] GameObject spawnLocation;

    public Vector3 FireDirection
    {
        get
        {
            Vector3 velocity = spawnLocation.transform.position - transform.position;
            return velocity;
        }
    }

    /// <summary>
    /// The position in world space where a projectile will be spawned when
    /// Fire() is called.
    /// </summary>
    public Vector3 SpawnPosition
    {
        get
        { 
            return spawnLocation.transform.position;
        }
    }

    /// <summary>
    /// The currently selected weapon object, an instance of which will be
    /// created when Fire() is called.
    /// </summary>
    public GameObject CurrentWeapon
    {
        get
        {
            GameObject currentWeapon;
            switch (weapon)
            {
                case 1:
                    currentWeapon = weapon1;
                    return currentWeapon;
                case 2:
                    currentWeapon = weapon2;
                    return currentWeapon;
                case 3:
                    currentWeapon = weapon3;
                    return currentWeapon;
                case 4:
                    currentWeapon = weapon4;
                    return currentWeapon;
                default:
                    weapon = 1;
                    currentWeapon = weapon1;
                    return currentWeapon;
            }
            
        }
    }

    /// <summary>
    /// Spawns the currently active projectile, firing it in the direction of
    /// FireDirection.
    /// </summary>
    /// <returns>The newly created GameObject.</returns>
    public GameObject Fire()
    {
        GameObject projectile = GameObject.Instantiate(CurrentWeapon, SpawnPosition, Quaternion.identity);
        projectile.GetComponent<Particle2D>().velocity = FireDirection;
        return projectile;
    }

    /// <summary>
    /// Moves to the next weapon. If the last weapon is selected, calling this
    /// again will roll over to the first weapon again. For example, if there
    /// are 4 weapons, calling this 4 times will end up with the same weapon
    /// selected as if it was called 0 times.
    /// </summary>
    public void CycleNextWeapon()
    {
        weapon++;
        if (weapon > 4)
        {
            weapon = 1;
        }

    }

    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().wKey.IsPressed())
        {
            CycleNextWeapon();
        }
        if (InputSystem.GetDevice<Keyboard>().enterKey.IsPressed())
        {
            Fire();
        }
        if(InputSystem.GetDevice<Keyboard>().digit1Key.IsPressed())
        {
            gameObject.transform.Rotate(0, 0, 1);
        }
        if(InputSystem.GetDevice<Keyboard>().digit2Key.IsPressed())
        {
            gameObject.transform.Rotate(0, 0, -1);
        }
    }
    
}
