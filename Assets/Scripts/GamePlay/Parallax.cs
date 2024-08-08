using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private IParallaxStrategy parallaxStrategy;

    public void SetStrategy(IParallaxStrategy strategy)
    {
        parallaxStrategy = strategy;
    }

    private void Update()
    {
        parallaxStrategy?.Move(transform);
    }
}