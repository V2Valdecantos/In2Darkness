using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float defaultSpeed_ = 1;
    private float speed_ = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PLAYER INPUTS

        //MOVEMENTS
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speed_, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * speed_, transform.position.y, transform.position.z);
        }

        //SPRINT
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed_ *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed_ = defaultSpeed_;
        }
    }
}
