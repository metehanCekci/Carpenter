using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

[RequireComponent(typeof(Slider))]

public class sliderScript : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }
    public AudioMixer mixer;

    [SerializeField]
    public Text volumeLabel;
    [SerializeField]
    public string volumeName;
    public float defaultValue = 100f;
    private void Start()
    {
        // Load the saved slider value from PlayerPrefs
        float savedValue = PlayerPrefs.GetFloat(volumeName, defaultValue);
        slider.value = savedValue;

        UpdateValueOnChange(slider.value);
        // Add listener to the slider value change event
        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }

    public void UpdateValueOnChange(float value)
    {
        if (mixer != null)
            mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);

        if (volumeLabel != null)
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";

        // Save the changed value to PlayerPrefs
        PlayerPrefs.SetFloat(volumeName, value);
        PlayerPrefs.Save(); // Save immediately to ensure the value is stored
    }
}
