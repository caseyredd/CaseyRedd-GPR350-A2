using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;



public static class Integrator
{

    static public void Integrate(Particle2D Component, float dT)
    {
        Component.transform.position = Component.transform.position + new Vector3(Component.velocity.x, Component.velocity.y, 0) * dT;
        Component.velocity = Component.velocity * Mathf.Pow(Component.damping, dT);
        Component.velocity = Component.velocity + Component.acceleration * dT;
    }

}
