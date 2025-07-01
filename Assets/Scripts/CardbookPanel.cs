using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardbookPanel : MonoBehaviour
{
    public Image copyImage;        // ���� �̹���
    public Text descriptionText;   // ���� �ؽ�Ʈ

    // ī�� ���� ����
    private Dictionary<int, string> cardDescriptions = new Dictionary<int, string>()
    {
        { 0, "Ȳ�� ��ź\n���� Ȳ������ �Ǿ��ֽ��ϴ�.\n���� �ð��� 5�� ���ҽ�ŵ�ϴ�." },
        { 1, "��¿ �Ŵ���\n�Ŵ����� �������� ���� �ð��� 5�� ������ŵ�ϴ�." },
        { 2, "��¿ Ʃ��\nƩ���� �������� �� ���� ī�带 ǥ�����ݴϴ�." },
        { 3, "�ﵥ��ź\n���� �������� ���ö�Ʈ�Դϴ�.\n�Ͻ������� �ð��� ������ �帨�ϴ�." },
        { 4, "�����\n������ ���� 3�ʰ� ��� ī�尡 �����˴ϴ�." },
        { 5, "�ۼ���\n������ �� �Դϴ�." },
        { 6, "������\n��Ÿ���Ե� �߱��� ���մϴ�." },
        { 7, "�ɳ���\nŸĪ ���䳲�Դϴ�." },
        { 8, "������\n������ ����Ŀ�� �ð� �ֽ��ϴ�." },
        { 9, "���ֿ�\n3�� ���̽��Դϴ�." },
        { 10, "Counter Strike2\n�ۼ������� favorite �����Դϴ�." },
        { 11, "Red Dead Redemption2\n���������� favorite �����Դϴ�." },
        { 12, "Ratopia\n�ɳ������� favorite �����Դϴ�." },
        { 13, "Fear & Hunger Termina\n���������� favorite �����Դϴ�." },
        { 14, "Tails of Iron\n���ֿ����� favorite �����Դϴ�." },
        { 15, "�ۼ���_�ƹ�Ÿ\n�ۼ������� �������� �����ϴ�." },
        { 16, "������_�ƹ�Ÿ\n���ں����� �ƴմϴ�." },
        { 17, "�ɳ���_�ƹ�Ÿ\n�ǰ����� ���� ������ �����ϴ�." },
        { 18, "������_�ƹ�Ÿ\n�δ㽺���� �ڵ��Դϴ�." },
        { 19, "���ֿ�_�ƹ�Ÿ\n��Ӹ��Դϴ�." },
    };

    public void SetCard(Sprite sprite, int index)
    {
        copyImage.sprite = sprite;

        if (cardDescriptions.ContainsKey(index))
        {
            descriptionText.text = cardDescriptions[index];
        }
        else
        {
            descriptionText.text = "�� �� ���� ī���Դϴ�.";
        }
    }
}