using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardbookPanel : MonoBehaviour
{
    public Image copyImage;        // 복사 이미지
    public Text descriptionText;   // 설명 텍스트

    // 카드 설명 사전
    private Dictionary<int, string> cardDescriptions = new Dictionary<int, string>()
    {
        { 0, "황금 르탄\n몸이 황금으로 되어있습니다.\n제한 시간을 5초 감소시킵니다." },
        { 1, "어쩔 매니저\n매니저의 권한으로 제한 시간을 5초 정지시킵니다." },
        { 2, "저쩔 튜터\n튜터의 권한으로 한 쌍의 카드를 표시해줍니다." },
        { 3, "삼데비스탄\n가장 기초적인 임플란트입니다.\n일시적으로 시간이 느리게 흐릅니다." },
        { 4, "삼륜안\n동술을 통해 3초간 모든 카드가 공개됩니다." },
        { 5, "송성현\n프린스 송 입니다." },
        { 6, "김현수\n안타깝게도 야구를 못합니다." },
        { 7, "심낙형\n타칭 테토남입니다." },
        { 8, "박준현\n분위기 메이커를 맡고 있습니다." },
        { 9, "차주원\n3조 에이스입니다." },
        { 10, "Counter Strike2\n송성현님의 favorite 게임입니다." },
        { 11, "Red Dead Redemption2\n김현수님의 favorite 게임입니다." },
        { 12, "Ratopia\n심낙형님의 favorite 게임입니다." },
        { 13, "Fear & Hunger Termina\n박준현님의 favorite 게임입니다." },
        { 14, "Tails of Iron\n차주원님의 favorite 게임입니다." },
        { 15, "송성현_아바타\n송성현님은 임포스터 였습니다." },
        { 16, "김현수_아바타\n사자보이즈 아닙니다." },
        { 17, "심낙형_아바타\n피곤한지 눈에 초점이 없습니다." },
        { 18, "박준현_아바타\n부담스러운 코디입니다." },
        { 19, "차주원_아바타\n대머리입니다." },
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
            descriptionText.text = "알 수 없는 카드입니다.";
        }
    }
}