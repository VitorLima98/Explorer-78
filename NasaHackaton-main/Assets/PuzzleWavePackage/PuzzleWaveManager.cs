using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Code by O_LAG
//you can use this code in your games , but remember to reference in credits;
//Think about donating a symbolic amount too, it helps me pay the bills.
public class PuzzleWaveManager : MonoBehaviour
{
    // Public Variables
    public int PuzzleLevel;
    public GenerateWaves[] Waves;
    public Slider AmplitudeSlider;
    public Slider FrequencySlider;
    public Image CorrectIcon;
    public TMP_Text WrongIcon;//change if necesssary to put an image, the text it's just to demonstrate.
    public float AmplitudeMargin = 0.2f;
    public float FrequencyMargin = 0.5f;
    public GameObject father;
    public GameObject ui;
    private bool isAmplitudeCorrect = false;
    private bool isFrequencyCorrect = false;


    void Start()
    {
        InitializeWaveValues();
        HideWrongIcon();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaveValues();
    }

    // Check validity of puzzle level
    public void CheckLevelValidity()
    {
        bool isAmplitudeValid = IsAmplitudeValid();
        bool isFrequencyValid = IsFrequencyValid();

        if (isAmplitudeValid && isFrequencyValid)
        {
            CorrectIcon.enabled = true;
            GameManager.instance.Puzzlesequence[0] = true;
            ui.SetActive(false);
            father.SetActive(false);
            GameManager.instance.Nextpuzzle();
        }
        else
        {
            StartCoroutine(DisplayWrongIcon());
        }
    }

    // Update puzzle level
    public void UpdatePuzzleLevel()
    {
        PuzzleLevel++;
        StartCoroutine(ResetAfterDelay());
    }

    // Display wrong icon for a short duration
    IEnumerator DisplayWrongIcon()
    {
        ShowWrongIcon();
        yield return new WaitForSeconds(1f);
        HideWrongIcon();
    }

    // Delay before resetting the icons and adjusting waves
    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        ResetIconsAndWaves();
    }

    // Initialize wave values
    void InitializeWaveValues()
    {
        Waves[0].Frequency = FrequencySlider.value;
        Waves[0].Amplitude = AmplitudeSlider.value;
        HideWrongIcon();
    }

    // Update wave values
    void UpdateWaveValues()
    {
        Waves[0].Amplitude = AmplitudeSlider.value;
        Waves[0].Frequency = FrequencySlider.value;
        Waves[0].UpdateVisual();

    }

    // Check if the amplitude is within the valid range
    bool IsAmplitudeValid()
    {
        float amplitude = Waves[0].Amplitude;
        float targetAmplitude = Waves[1].Amplitude;
        return (amplitude >= (targetAmplitude - AmplitudeMargin)) && (amplitude <= (targetAmplitude + AmplitudeMargin));
    }

    // Check if the frequency is within the valid range
    bool IsFrequencyValid()
    {
        float frequency = Waves[0].Frequency;
        float targetFrequency = Waves[1].Frequency;
        return (frequency >= (targetFrequency - FrequencyMargin)) && (frequency <= (targetFrequency + FrequencyMargin));
    }

    // Reset icons and adjust waves after a delay
    void ResetIconsAndWaves()
    {
        HideCorrectIcon();
        HideWrongIcon();

        // Reset waves and generate new levels
        for (int i = 0; i < Waves.Length; i++)
        {
            Waves[i].CurrentLevel = PuzzleLevel;
            if (Waves[i].Pattern)
            {
                Waves[i].GenerateNewLevel(PuzzleLevel);
            }
        }

        // Reset flags and values
        isAmplitudeCorrect = false;
        isFrequencyCorrect = false;
        Waves[0].Frequency = 0;
        Waves[0].Amplitude = 0;
    }

    // Helper method to show the wrong icon
    void ShowWrongIcon()
    {
        WrongIcon.enabled = true;
    }

    // Helper method to hide the wrong icon
    void HideWrongIcon()
    {
        WrongIcon.enabled = false;
    }

    // Helper method to hide the correct icon
    void HideCorrectIcon()
    {
        CorrectIcon.enabled = false;
    }
}

