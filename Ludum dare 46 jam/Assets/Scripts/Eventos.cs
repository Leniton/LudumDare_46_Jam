using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    public delegate void OnInteraction();
    public static event OnInteraction E;
}
