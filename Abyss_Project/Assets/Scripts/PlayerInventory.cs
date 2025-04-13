using UnityEngine;
using UnityEngine.Events;
using SmallHedge.SoundManager;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples {get; private set; }
    public int NumberOfMushrooms {get; private set; }
    public int NumberOfSamples {get; private set; }
    public int NumberOfMeat {get; private set; }
    public int NumberOfSurveys {get; private set; }
    public int NumberOfSwords {get; private set; }

    public UnityEvent<PlayerInventory> OnAppleCollected;
    public UnityEvent<PlayerInventory> OnMushroomCollected;
    public UnityEvent<PlayerInventory> OnSampleCollected;
    public UnityEvent<PlayerInventory> OnMeatCollected;
    public UnityEvent<PlayerInventory> OnSurveyCollected;
    public UnityEvent<PlayerInventory> OnSwordCollected;

    public void AppleCollected()
    {
        NumberOfApples++;
        OnAppleCollected.Invoke(this);
        SoundManager.PlaySound(SoundType.COLLECT);
    }

    public void MushroomCollected()
    {
        NumberOfMushrooms++;
        OnMushroomCollected.Invoke(this);
        SoundManager.PlaySound(SoundType.COLLECT);
    }

    public void SampleCollected()
    {
        NumberOfSamples++;
        OnSampleCollected.Invoke(this);
        SoundManager.PlaySound(SoundType.COLLECT);
    }

    public void MeatCollected()
    {
        NumberOfMeat++;
        OnMeatCollected.Invoke(this);
        SoundManager.PlaySound(SoundType.COLLECT);
    }

    public void SurveyCollected()
    {
        NumberOfSurveys++;
        OnSurveyCollected.Invoke(this);
        SoundManager.PlaySound(SoundType.COLLECT);
    }

    public void SwordCollected()
    {
        NumberOfSwords++;
        OnSwordCollected.Invoke(this);
        SoundManager.PlaySound(SoundType.COLLECT);
    }
}
