using UnityEngine;

public class CarouselBehavior : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
