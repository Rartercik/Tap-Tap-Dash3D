using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwitcherUI : MonoBehaviour
{
	[SerializeField] CheckerUI _mainChecker;
	[SerializeField] GameObject _button;
	[SerializeField] bool _isOn;
	
	private Animator _animator;
	
	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_animator.SetTrigger(_isOn ? "MomentalOn" : "MomentalOff");
		_mainChecker.AllSwitchActions += UpdateAnimatorState;
	}

	public void UpdateAnimatorState()
	{
		var currentAnimation = _animator.GetCurrentAnimatorStateInfo(0);

		var canAnimate = currentAnimation.IsName("ImageOn") || currentAnimation.IsName("ImageOff")
			|| currentAnimation.IsName("TextOn") || currentAnimation.IsName("TextOff");

		if (canAnimate)
		{
			_animator.SetTrigger(_isOn ? "Off" : "On");
			_isOn = !_isOn;
		}
	}
	public void ChangeButtonEnable()
	{
		_button.SetActive(_isOn);
	}
}
