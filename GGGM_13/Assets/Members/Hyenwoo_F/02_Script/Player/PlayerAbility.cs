using System.Collections;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private YHWPlayer player;
    private SizeDown sizeDown;
    private EquipLeatherArmor leatherArmor;
    private EquipIronArmor ironArmor;
    private EquipNormalHelmet normalHelmet;
    private EquipIronHelmet ironHelmet;

    private void Start()
    {
        sizeDown._onSizeDown += PlayerSizeDown;
        leatherArmor._onLeatherArmor += () => player.BodyCollider.GetComponent<PlayerHitBox>().SetLeather();
        ironArmor._onIronArmor += () => player.BodyCollider.GetComponent<PlayerHitBox>().SetIron();
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
