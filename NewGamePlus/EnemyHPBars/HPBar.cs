using System.Collections;
using Modding;
using UnityEngine;
using UnityEngine.UI;

namespace EnemyHPBar
{
	public class HPBar : MonoBehaviour
	{
		private CanvasRenderer bg_cr, fg_cr, mg_cr, ol_cr;

		public Image health_bar, hpbg;

		public float currHP, maxHP;
		public int oldHP;

		public HealthManager hm;

		public Vector2 objectPos, screenScale;

		CanvasRenderer GetCanvasRenderer(GameObject parent, Sprite sprite, Vector2 scale)
			=> CanvasUtil.CreateImagePanel(
				parent,
				sprite,
				new CanvasUtil.RectData(
					Vector2.Scale(
						new Vector2(
							sprite.texture.width,
							sprite.texture.height
						),
						scale
					),
					new Vector2(0, 32)
				)
			).GetComponent<CanvasRenderer>();

		public void Awake()
		{
			Modding.Logger.Log($@"Creating hpbar for {gameObject.name}");

			screenScale = new Vector2(Screen.width / 1280f * 0.025f, Screen.height / 720f * 0.025f);

			bg_cr = GetCanvasRenderer(EnemyHPBar.canvas, EnemyHPBar.bg, screenScale * EnemyHPBar.instance._globalSettings.bgScale);
			fg_cr = GetCanvasRenderer(EnemyHPBar.canvas, EnemyHPBar.mg, screenScale * EnemyHPBar.instance._globalSettings.fgScale);
			mg_cr = GetCanvasRenderer(EnemyHPBar.canvas, EnemyHPBar.mg, screenScale * EnemyHPBar.instance._globalSettings.mgScale);
			ol_cr = GetCanvasRenderer(EnemyHPBar.canvas, EnemyHPBar.ol, screenScale * EnemyHPBar.instance._globalSettings.olScale);

			hpbg = mg_cr.GetComponent<Image>();
			hpbg.type = Image.Type.Filled;
			hpbg.fillMethod = Image.FillMethod.Horizontal;
			hpbg.preserveAspect = false;

			health_bar = fg_cr.GetComponent<Image>();
			health_bar.type = Image.Type.Filled;
			health_bar.fillMethod = Image.FillMethod.Horizontal;
			health_bar.preserveAspect = false;

			bg_cr.GetComponent<Image>().preserveAspect = false;
			ol_cr.GetComponent<Image>().preserveAspect = false;

			hm = gameObject.GetComponent<HealthManager>();

			SetHPBarAlpha(0);
			maxHP = hm.hp;
			currHP = hm.hp;

			GameManager.instance.StartCoroutine(WorkWithNG_Plus());
		}

		private IEnumerator WorkWithNG_Plus()
		{
			yield return null;

			hm = gameObject.GetComponent<HealthManager>();
			SetHPBarAlpha(0f);
			maxHP = hm.hp;
			currHP = hm.hp;
		}

		private void SetHPBarAlpha(float alpha)
		{
			bg_cr.SetAlpha(alpha);
			fg_cr.SetAlpha(alpha);
			mg_cr.SetAlpha(alpha);
			ol_cr.SetAlpha(alpha);
		}

		private void DestroyHPBar()
		{
			Destroy(fg_cr.gameObject);
			Destroy(bg_cr.gameObject);
			Destroy(mg_cr.gameObject);
			Destroy(ol_cr.gameObject);
			Destroy(hpbg);
			Destroy(health_bar);
		}

		private void MoveHPBar(Vector2 position)
		{
			fg_cr.transform.position = position;
			mg_cr.transform.position = position;
			bg_cr.transform.position = position;
			ol_cr.transform.position = position;
		}

		private void OnDestroy()
		{
			Modding.Logger.LogDebug($@"Destroying enemy {gameObject.name}");
			SetHPBarAlpha(0);
			DestroyHPBar();
			Modding.Logger.LogDebug($@"Destroyed enemy {gameObject.name}");
		}

		private void OnDisable()
		{
			Modding.Logger.LogDebug($@"Disabling enemy {gameObject.name}");
			SetHPBarAlpha(0);
			Modding.Logger.LogDebug($@"Disabled enemy {gameObject.name}");
		}

		private void FixedUpdate()
		{
			if (currHP > hm.hp)
			{
				currHP -= 0.5f;
			}
			else
			{
				currHP = hm.hp;
			}

			Modding.Logger.LogDebug($@"Enemy currHP {hm.hp} and maxHP {maxHP}");
			health_bar.fillAmount = hm.hp / maxHP;

			hpbg.fillAmount = currHP / maxHP;

			if (health_bar.fillAmount < 1f)
			{
				SetHPBarAlpha(1);
			}

			if (gameObject.name == "New Game Object" && currHP <= 0)
			{
				Modding.Logger.LogDebug($@"Placeholder killed");
				Destroy(gameObject);
			}

			if (currHP <= 0f)
			{
				SetHPBarAlpha(0);
			}

			oldHP = hm.hp;
		}

		private void LateUpdate()
		{
			objectPos = gameObject.transform.position + Vector3.up * 1.5f;
			MoveHPBar(objectPos);
		}
	}
}