using UnityEngine;

public class DeveloperWindowLocker : MonoBehaviour
{
    [SerializeField] private GameObject _openButton;

    private int _rightTop, _rightBottom, _leftBottom;
    private int _needRightTop = 3, _needRightBottom = 4, _needLeftBottom = 5;

    public void OnClick(string ButtonName)
    {
        if (ButtonName == "RightTop")
        {
            _rightTop++;
        }
        else if (ButtonName == "RightBottom")
        {
            _rightBottom++;
        }
        else
        {
            _leftBottom++;
        }

        TryOpen();
    }

    private void TryOpen()
    {
        if (_rightTop == _needRightTop & _rightBottom == _needRightBottom & _leftBottom == _needLeftBottom)
        {
            _openButton.SetActive(true);
        }
    }

    public void ResetLockValues()
    {
        _rightTop = 0;
        _rightBottom = 0;
        _leftBottom = 0;
    }
}
