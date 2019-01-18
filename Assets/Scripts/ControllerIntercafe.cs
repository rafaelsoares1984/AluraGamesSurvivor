public class ControllerIntercafe : MonoBehaviour 
{
    private ControllerPlayer scriptControllerPlayer;
    public Slider SliderLifePlayer;

    void Start () {
        scriptControllerPlayer = GameObject.FindWithTag("Player").GetComponent<ControllerPlayer>();
        SliderLifePlayer.maxValue = scriptControllerPlayer.lifePlayer;
        UpdateSliderLifePlayer();
    }
    
    public void UpdateSliderLifePlayer ()
    {
        SliderLifePlayer.value = scriptControllerPlayer.lifePlayer;
    }
    
}
