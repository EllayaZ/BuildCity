using UnityEngine;
using UnityEngine.UI;

public class Day_Night : MonoBehaviour
{
    [SerializeField] private GameObject sun;
    [SerializeField] private Slider mainSlider;

    private float currentPosition;


    private void Awake()
    {
        currentPosition = mainSlider.value;
        mainSlider.onValueChanged.AddListener(OnSliderChanged);

    }

    private void OnSliderChanged(float value)
    {
        float rate = value - currentPosition;
        sun.transform.Rotate(Vector3.right * rate * 180);
        currentPosition = value;

    
    }
}



