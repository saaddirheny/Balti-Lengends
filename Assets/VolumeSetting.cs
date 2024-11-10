using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    private void Start()
    {
      if(PlayerPrefs.HasKey("MusicVolume"))
      {
LoadVolume();

      }
      else{
        SetMusicVolume();
        
      }

      if(PlayerPrefs.HasKey("SFXVolume"))
      {
LoadVolume();

      }
      else{
        SetSFXVolume();
        
      }
       
    }

   [SerializeField] private AudioMixer myMixer;
   [SerializeField] private Slider musicSlider;
   [SerializeField] private Slider SFXSlider;
  
   public void SetMusicVolume()
   {
    float volume = musicSlider.value;
    
    myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    PlayerPrefs.SetFloat("MusicVolume" , volume);
   }

    public void SetSFXVolume()
   {
    float volume = SFXSlider.value;
    
    myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
    PlayerPrefs.SetFloat("SFXVolume" , volume);
   }

private void LoadVolume()
{
    musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    SetMusicVolume();
    SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    SetSFXVolume();
} 

}
