using Modding;
using Modding.Delegates;
namespace MoreDamage
{
	public class AAA_MoreDamage : Mod, ITogglableMod, IMod, ILogger,IGlobalSettings<GlobalSettings>
	{
		private GlobalSettings gs = new GlobalSettings();

		private TakeDamageProxy damageProxy;

		private TakeHealthProxy healthProxy;

		public GlobalSettings OnSaveGlobal() => gs;
		public void OnLoadGlobal(GlobalSettings s) => gs = s;

		public override string GetVersion() => gs.ExtraDamage.ToString();

		public override void Initialize()
		{
			Log($"Initializing with scale {gs.ExtraDamage}");

			if (damageProxy == null) damageProxy = new TakeDamageProxy(ILoveDamage);
			if (healthProxy == null) healthProxy = new TakeHealthProxy(IReallyLoveDamage);

			ModHooks.TakeDamageHook += damageProxy;
			ModHooks.TakeHealthHook += healthProxy;
		}

		private int IncreaseDamage(int damage)
		{
			int num = damage + gs.ExtraDamage;

			LogDebug($"The damage was changed from {damage} to {num}");

			return num;
		}

		private int IReallyLoveDamage(int damage)
			=> gs.BadHook ? damage : IncreaseDamage(damage);

		private int ILoveDamage(ref int hazardtype, int damage)
			=> gs.BadHook ? IncreaseDamage(damage) : damage;

		public void Unload()
		{
			Log("Unloading...");

			ModHooks.TakeDamageHook -= damageProxy;
			ModHooks.TakeHealthHook -= healthProxy;
		}
	}
}
