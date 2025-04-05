using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples {get; private set; }
    public int NumberOfMushrooms {get; private set; }
    public int NumberOfSamples {get; private set; }
    public int NumberOfMeat {get; private set; }
    public int NumberOfSurveys {get; private set; }

    public UnityEvent<PlayerInventory> OnAppleCollected;
    public UnityEvent<PlayerInventory> OnMushroomCollected;
    public UnityEvent<PlayerInventory> OnSampleCollected;
    public UnityEvent<PlayerInventory> OnMeatCollected;
    public UnityEvent<PlayerInventory> OnSurveyCollected;

    public void AppleCollected()
    {
        NumberOfApples++;
        OnAppleCollected.Invoke(this);
    }

    public void MushroomCollected()
    {
        NumberOfMushrooms++;
        OnMushroomCollected.Invoke(this);
    }

    public void SampleCollected()
    {
        NumberOfSamples++;
        OnSampleCollected.Invoke(this);
    }

    public void MeatCollected()
    {
        NumberOfMeat++;
        OnMeatCollected.Invoke(this);
    }

    public void SurveyCollected()
    {
        NumberOfSurveys++;
        OnSurveyCollected.Invoke(this);
    }
}
