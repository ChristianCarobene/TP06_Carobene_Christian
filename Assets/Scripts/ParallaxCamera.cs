using UnityEngine;

[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovementX, float deltaMovementY);
    public ParallaxCameraDelegate onCameraTranslate;

    private float oldPositionX;
    private float oldPositionY;

    void Start()
    {
        oldPositionX = transform.position.x; 
        oldPositionY = transform.position.y;
    }

    void Update()
    {

        if (onCameraTranslate != null)
        {
            float deltaX = 0;
            float deltaY = 0;

            if (transform.position.x != oldPositionX)
            {
                deltaX = oldPositionX - transform.position.x;
                oldPositionX = transform.position.x;
            }
            if (transform.position.y != oldPositionY)
            {
                deltaY = oldPositionY - transform.position.y;
                oldPositionY = transform.position.y;
            }
            onCameraTranslate(deltaX, deltaY);

            
        }
    }
}
