using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return direction; }
        set { _direction = value; }
    }
   
    void Start() // Start is called before the first frame update
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update() // Update is called once per frame
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void Movement() //mover
    {

    }

    void Jump() //pular
    {

    }

    void Attack() //atacar
    {

    }
}
