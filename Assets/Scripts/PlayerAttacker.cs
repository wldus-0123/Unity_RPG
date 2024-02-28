using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] LayerMask layerMask;
	[SerializeField] float range;
	[SerializeField] float angle;
	[SerializeField] int damage;

	private float cosRange;

	private void Awake()
	{
		cosRange = Mathf.Cos(Mathf.Deg2Rad * angle);
	}

	//[SerializeField] Weapon weapon;


	//public void EnableWeapon()
	//{
	//	weapon.EnableWeapon();
	//}

	//public void DisableWeapon()
	//{
	//	weapon.DisableWeapon();
	//}

	private void Attack()
	{
		int rand = Random.Range(0, 2);
		if ( rand == 0 )
		{
			animator.SetTrigger("Attack1");
		}
		else
		{
			animator.SetTrigger("Attack2");
		}

	}

	Collider [] colliders = new Collider [20];
	private void AttackTiming()
	{
		int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
		for ( int i = 0; i < size; i++ )
		{
			Vector3 dirToTarget = ( colliders [i].transform.position - transform.position ).normalized;
			//if ( Vector3.Angle(transform.forward, dirToTarget) > angle )
			//	continue;

			if ( Vector3.Dot(dirToTarget, transform.forward) < cosRange )
				continue; // 내적 사용 : 이게 더 빠름

			IDamagable damagable = colliders [i].GetComponent<IDamagable>();
			if ( damagable != null )
			{
				damagable.TakeDamage(damage);
			}
		}
	}

	private void OnAttack( InputValue value )
	{
		Attack();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
