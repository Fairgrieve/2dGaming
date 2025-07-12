using UnityEngine;

public class AI : MonoBehaviour
{
    
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5.0f;
    

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }
}
