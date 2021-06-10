using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarController : MonoBehaviourPunCallbacks, IPunObservable
{
    private const float MaxStamina = 6f;

    [SerializeField]
    private Image staminaBar = default;

    private float currentStamina = MaxStamina;

    private void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            if (input.sqrMagnitude > 0f)
            {
                currentStamina = Mathf.Max(0f, currentStamina - Time.deltaTime);
                transform.Translate(6f * Time.deltaTime * input.normalized);
            }
            else
            {
                currentStamina = Mathf.Min(currentStamina + Time.deltaTime * 2, MaxStamina);
            }
        }

        //getInformation();

        // スタミナゲージを反映
        Debug.Log(currentStamina);
        staminaBar.fillAmount = currentStamina / MaxStamina;

    }

    public void getInformation()
    {
        var players = PhotonNetwork.PlayerList;
        foreach (var player in players)
        {
            Debug.Log($"{player.NickName}({player.ActorNumber})");
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentStamina);

        }
        else
        {
            currentStamina = (float)stream.ReceiveNext();
        }
    }
}