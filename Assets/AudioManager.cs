using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("....Audio Source...")]
 [SerializeField] AudioSource musicSource;
  [SerializeField] AudioSource sfxSource;
  
  
  [Header("....Audio Clips...")]

  public AudioClip background;
  public AudioClip oya;
  public AudioClip Tourism;
public static AudioManager instance;
private void Awake()
{
   if(instance == null)
   {
      instance = this;
   DontDestroyOnLoad(gameObject);
   }
   else{
    Destroy(gameObject);
   }
}
 
  private void Start()
  {
    musicSource.clip = background;
    musicSource.Play();
  }
 public void PlaySFX(AudioClip clip)
 {
    sfxSource.PlayOneShot(clip);
 }
}
