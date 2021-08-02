﻿using Modding;

namespace MoreDamage
{
	public class AAA_MoreDamage : Mod, ITogglableMod, IMod, ILogger
	{
		private GlobalSettings gs = new GlobalSettings();

		private static AAA_MoreDamage Instance;

		private TakeDamageProxy damageProxy;

		private TakeHealthProxy healthProxy;

		public override ModSettings GlobalSettings { get => gs; set => gs = (GlobalSettings)value; }

		public override string GetVersion() => gs.ExtraDamage.ToString();

		public override void Initialize()
		{
			if (Instance == null) Instance = this;

			Log($"Initializing with scale {gs.ExtraDamage}");

			damageProxy = new TakeDamageProxy(ILoveDamage);
			healthProxy = new TakeHealthProxy(IReallyLoveDamage);

			ModHooks.Instance.TakeDamageHook += damageProxy;
			ModHooks.Instance.TakeHealthHook += healthProxy;
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

			ModHooks.Instance.TakeDamageHook -= damageProxy;
			ModHooks.Instance.TakeHealthHook -= healthProxy;
		}
	}
}