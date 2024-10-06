using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetSystem", menuName = "CreatePlanet/Add New Planet", order = 2)]
public class PlanetSystem : ScriptableObject
{
    public string PlanetName;
    public string Mass;
    public string Radius;
    public string OrbitalPeriod;
    public RenderTexture render;
    public string description;
    public string atmosphere;
    public string type;
    public string discoveryMethod;
}
