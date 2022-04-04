using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InformationTransferer))]
[RequireComponent(typeof(CenterConcentrator))]
public class LevelStation : MonoBehaviour
{
    public int Level;
    public Transform CollectablesParent;

    [SerializeField] GameObject _player;
    [SerializeField] StartPositor _playerStart;
	[SerializeField] Text _levelNumber;
	[SerializeField] GameObject _effects;

    private InformationTransferer _informationTransferer;
    private CenterConcentrator _centerConcentrator;
    private PlayerMovement _playerMovement;
	private Animator _comingAnimation;
	
	private void Start()
	{
        _informationTransferer = GetComponent<InformationTransferer>();
        _centerConcentrator = GetComponent<CenterConcentrator>();

		_playerMovement = _player.GetComponent<PlayerMovement>();

		_levelNumber.text = Level.ToString();
		_comingAnimation = GetComponent<Animator>();
		
		if(StartLevel.Level == Level)
		{
            _player.transform.position = _playerStart.transform.position;
            _informationTransferer.TransferInformation(_player);
		}
	}

    private void OnCollisionEnter(Collision other)
    {
    	if(other.gameObject.TryGetComponent<PlayerMovement>(out var p) && StartLevel.Level != Level)
    	{
    		_comingAnimation.SetTrigger("DoChange");
            _centerConcentrator.StartGoToCenter(_player);
            SwitchMovementEnabled(false);
    	}
    }
    
    public void StartEffects()
    {
    	_effects.SetActive(true);
    }

    public void InitializeLevel()
    {
        SwitchMovementEnabled(true);
        StartLevel.Level = Level;
        var saveString = string.Format("{0} {1}", SceneManager.GetActiveScene().buildIndex, Level);
        PlayerPrefs.SetString(saveString, saveString);
        _informationTransferer.TransferInformation(_player);
    }
    private void SwitchMovementEnabled(bool arg)
    {
        _playerMovement.enabled = arg;
        _playerMovement.Movement.enabled = arg;
        _playerMovement.RotationMovement.enabled = arg;
        _playerMovement.VerticalMovement.enabled = arg;
    }
}
