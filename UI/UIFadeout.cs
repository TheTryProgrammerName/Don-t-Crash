using UnityEngine;

//��������� �������� ���������� ��� �������, ����� �� ������� �� ������� ������
public class UIFadeout : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;

    [SerializeField] private GameObject[] _windowElements;

    //�������� �������� ����� ����� ��� �������
    //������� ��������� �������: ����� spacing, ������� ���������� �� ������� ������
    //� ����� �������� ���������� �� �������� spacing - ��������� ���������

    public void OnScroll(Vector2 scrollDirection)
    {
        //������, �� ���������� �������� �������� ����� �������
    }

    private void positionTrack()
    {
        //������ � �������� fadeout ��� fadein
        //������ �������� � ������ ������� � ����� �� Y-�������� �� ��� ���
        //���� ��������� ������ �� ����� ����� ������ Y-������� (���� ��� � ����� ������� �� ������� ����)
        //� ��� ������ ��������� fadeout ��� fadein
    }

    private void fadeout()
    {

    }

    private void fadein()
    {

    }
}
