using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherUI : MonoBehaviour
{
	[SerializeField] CheckerUI _mainChecker;
	[SerializeField] GameObject _button;
	[SerializeField] bool _isOn;
	
	private Animator _animator;
	
	void Awake()
	{
		_animator = GetComponent<Animator>();
		_animator.SetTrigger(_isOn ? "MomentalOn" : "MomentalOff");
		_mainChecker.AllSwitchActions += UpdateAnimatorState;
	}

	public void UpdateAnimatorState()
	{
		_animator.SetTrigger(_isOn ? "Off" : "On");
		_isOn = !_isOn;
	}
	public void ChangeButtonEnable()
	{
		_button.SetActive(_isOn);
	}
}
