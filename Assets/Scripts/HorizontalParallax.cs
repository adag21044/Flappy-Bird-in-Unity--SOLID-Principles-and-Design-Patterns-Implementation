using UnityEngine;
public class HorizontalParallax : IParallaxStrategy
{
    private float speed;

    public HorizontalParallax(float animationSpeed)
    {
        speed = animationSpeed;
    }

    public void Move(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}