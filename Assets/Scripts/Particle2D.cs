using UnityEngine;

public class Particle2D : MonoBehaviour
{
    public Vector2 accumulatedForces = Vector3.zero;
    public Vector2 acceleration = Vector3.zero;
    public float damping = 0.0f;
    public Vector2 initLoc;
    public Vector2 moveLoc;
    public float inverseMass;
    public Vector2 velocity;
    public Vector2 currentLocation;
    void Start()
    {

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Integrator.Integrate(GetComponent<Particle2D>(), Time.deltaTime);
    }
}
