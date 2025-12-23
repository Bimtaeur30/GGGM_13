using System.Collections;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private YHWPlayer player;
    [SerializeField] private SizeDown sizeDown;
    [SerializeField] EquipNormalHelmet normalHelmet;
    [SerializeField] private EquipIronHelmet ironHelmet;

    private void Start()
    {
        sizeDown._onSizeDown += PlayerSizeDown;
        normalHelmet._onEquipHelmet += () => player.HeadCollider.GetComponent<PlayerHitBox>().SetLeather();
        ironHelmet._onEquipIronHelmet += () => player.HeadCollider.GetComponent<PlayerHitBox>().SetIron();
    }

    public void PlayerSizeDown(float downSize, float time)
    {
        StartCoroutine(SizeDown(downSize, time));
    }

    private IEnumerator SizeDown(float downSize, float time)
    {
        player.transform.localScale = new Vector3(downSize, downSize, 0);
        yield return new WaitForSeconds(time);
        gameObject.transform.localScale = new Vector3(1, 1, 0);

    }
}
