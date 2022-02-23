using Modding;
using UnityEngine;
using Modding.Delegates;
namespace HealthScale
{
	public class AAA_MoreHealth : Mod, ITogglableMod, IMod, Modding.ILogger,IGlobalSettings<GlobalSettings>
	{
		public GlobalSettings gs = new GlobalSettings();
		public GlobalSettings OnSaveGlobal() => gs;
		public void OnLoadGlobal(GlobalSettings s)=>gs = s;
		

		public override void Initialize()
		{
			Log($"Initializing with scale {gs.HealthScale}");
			ModHooks.OnEnableEnemyHook += new OnEnableEnemyHandler(ScaleEnemyHealth);
			ScaleHealthInternal();
		}

		public void Unload()
		{
			Log("Unloading...");
			ModHooks.OnEnableEnemyHook -= new OnEnableEnemyHandler(ScaleEnemyHealth);
			UndoHealthScale();
		}

		public override string GetVersion() => gs.HealthScale.ToString();

		private void ScaleHealthInternal()
		{
			HealthManager[] array = Object.FindObjectsOfType<HealthManager>();

			foreach (HealthManager obj in array) obj.hp = (int)(obj.hp * gs.HealthScale);
		}

		private bool ScaleEnemyHealth(GameObject go, bool isDead)
		{
			HealthManager component = go.GetComponent<HealthManager>();

			if (component == null) return isDead;

			switch (go.name)
			{
				case "False Knight New":
				case "False Knight Dream":
					ManualChanges.ChangeFKHealth(go, gs.HealthScale);
					break;

				case "Mantis Lord":
				case "Mantis Lord S1":
				case "Mantis Lord S2":
				case "Mantis Lord S3":
					component.hp = (int)(component.hp * System.Math.Sqrt(gs.HealthScale));
					break;

				case "Hollow Knight Boss":
					ManualChanges.ChangeTHKHealth(go, gs.HealthScale);
					break;

				case "Radiance":
				case "Absolute Radiance":
					ManualChanges.ChangeRadHealth(go, gs.HealthScale);
					break;

				case "Oro":
					ManualChanges.NailMasters(go, gs.HealthScale);
					break;
				case "HK Prime":
					ManualChanges.PV(go, gs.HealthScale);
					break;
				case "Grimm Boss":
				case "Nightmare Grimm Boss":
					ManualChanges.Grimms(go, gs.HealthScale);
					break;
				case "Dung Defender":
				case "White Defender":
					ManualChanges.DungDefender(go, gs.HealthScale);
					break;

				default:
					component.hp = (int)(component.hp * gs.HealthScale);
					break;
			}

			return isDead;
		}

		private void UndoHealthScale()
		{
			HealthManager[] array = Object.FindObjectsOfType<HealthManager>();

			foreach (HealthManager obj in array) obj.hp = (int)(obj.hp / gs.HealthScale);
		}
	}
}
