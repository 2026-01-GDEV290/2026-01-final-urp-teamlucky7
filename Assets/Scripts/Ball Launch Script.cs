using UnityEngine;

public class BallLaunchScript : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float radius = 1f;
    public float angle = 0f;
    public Transform spawnpoint;
    public float yoffset = 0.75f; 
    void Update()
    {
        //Calculate new position
        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = target.position.y + yoffset;
        float z = target.position.z + Mathf.Sin(angle) * radius;


        //Actually updates position
        transform.position = new Vector3(x,y,z);

        //increment angle to move object along circular path
        angle += speed * Time.deltaTime;
    }
}
