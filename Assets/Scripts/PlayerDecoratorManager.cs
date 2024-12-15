using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDecoratorManager : MonoBehaviour
{
    public void ApplyDecorator(IPlayerDecorator decorator)
    {
        decorator.Apply();
    }
}

