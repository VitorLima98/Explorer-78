using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by O_LAG
//you can use this code in your games , but remember please to reference in credits;
//Think about donating a symbolic amount too, it helps me pay the bills.
public class GenerateWaves : MonoBehaviour
{
    
    public int Resolution = 100;
    public float Speed = 1f;
    public float Frequency = 1f;
    public float Amplitude = 1f;
    public bool Pattern;
    public int CurrentLevel;

    private LineRenderer lineRenderer;
    private float offset = 0f;

    void Start()
    {
        InitializeLineRenderer();
        MoveWave();
        if (Pattern)
            GenerateRandomPattern();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Pattern)
            MoveWave();
     
    }

    // Initialize Line Renderer component
    void InitializeLineRenderer()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = Resolution;
    }

    // Generate random wave pattern
    void GenerateRandomPattern()
    {
        Frequency = Random.Range(-0.7f, 7f);
        Amplitude = Random.Range(0f, 1.60f);
        UpdateVisual();
    }

    // Update wave visualization
    public void UpdateVisual()
    {
        offset += Time.deltaTime * Speed;
        SetLineRendererPositions();
    }

    // Move wave
    void MoveWave()
    {
        offset += Time.deltaTime * Speed;
        SetLineRendererPositions();
    }

    // Set Line Renderer positions
    void SetLineRendererPositions()
    {
        float point = 2f * Mathf.PI / Resolution;
        Vector3[] positions = new Vector3[Resolution];

        for (int i = 0; i < Resolution; i++)
        {
            float x = i * point;
            float y = Mathf.Sin((x * Frequency) + offset) * Amplitude;
            positions[i] = new Vector3(x, y, 0f);
        }

        lineRenderer.SetPositions(positions);
    }

    // Generate new level with modifier. make your modifiers :) 
    public void GenerateNewLevel(int modifier)
    {
        if (Pattern)
            GenerateRandomPattern();
    }
}