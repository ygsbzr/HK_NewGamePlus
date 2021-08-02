using Modding;
using UnityEngine;

namespace HealthScale
{
	public class AAA_AllEnemyHealthScale : Mod, ITogglableMod, IMod, Modding.ILogger
	{
		public GlobalSettings gs = new GlobalSettings();

		internal static AAA_AllEnemyHealthScale Instance;

		public override ModSettings GlobalSettings { get => gs; set => gs = (GlobalSettings)value; }

		public override void Initialize()
		{
			if (Instance == null) Instance = this;

			Log($"Initializing with scale {gs.HealthScale}");
			ModHooks.Instance.OnEnableEnemyHook += new OnEnableEnemyHandler(ScaleEnemyHealth);
			ScaleHealthInternal();
		}

		public void Unload()
		{
			Log("Unloading...");
			ModHooks.Instance.OnEnableEnemyHook -= new OnEnableEnemyHandler(ScaleEnemyHealth);
			UndoHealthScale();
		}

		public override string GetVersion() => gs.HealthScale.ToString();

		public override int LoadPriority() => 100;

		private void ScaleHealthInternal()
		{
			HealthManager[] array = Object.FindObjectsOfType<HealthManager>();
			foreach (HealthManager obj in array)
			{
				obj.hp = (int)(obj.hp * gs.HealthScale);
			}
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
			foreach (HealthManager obj in array)
			{
				obj.hp = (int)(obj.hp / gs.HealthScale);
			}
		}
	}
}
