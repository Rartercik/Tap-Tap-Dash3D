using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerSkin : MonoBehaviour
{
    [SerializeField] VerticalMovement _jumpProcessor;
    [SerializeField] PlayerEnding _dieProcessor;
    [SerializeField] ShopData _shop;
    [SerializeField] string _skinName;

    private void Awake()
    {
        if (_shop.Data.PlayerSkinName != _skinName)
        {
            gameObject.SetActive(false);
        }
        else
        {
            _jumpProcessor.MovementAnimator = GetComponent<Animator>();
            _dieProcessor.MovementAnimator = GetComponent<Animator>();
        }
    }
    public void EndGame()
    {
        _dieProcessor.RestartLevel();
    }
}
