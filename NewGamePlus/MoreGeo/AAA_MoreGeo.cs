using Modding;

namespace MoreGeo
{
	public class AAA_MoreGeo : Mod, ITogglableMod, IMod,IGlobalSettings<GlobalSettings>
	{
		public GlobalSettings gs = new GlobalSettings();

		public GlobalSettings OnSaveGlobal() => gs;
		public void OnLoadGlobal(GlobalSettings s) => gs = s;

		public override string GetVersion() => $"{gs.Multiplier}x";

		public override void Initialize() => On.HeroController.AddGeo += AddGeo;

		public void Unload() => On.HeroController.AddGeo -= AddGeo;

		private void AddGeo(On.HeroController.orig_AddGeo orig, HeroController self, int amount) => orig.Invoke(self, amount * gs.Multiplier);
	}
}
