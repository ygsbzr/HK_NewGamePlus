using Modding;

namespace MoreGeo
{
	public class AAA_MoreGeo : Mod, ITogglableMod, IMod,IGlobalSettings<GlobalSettings>
	{
		public GlobalSettings gs = new GlobalSettings();

		public GlobalSettings OnSaveGlobal() => gs;
		public void OnLoadGlobal(GlobalSettings s) => gs = s;

		public override string GetVersion() => $"{gs.Multiplier}x";

		public override void Initialize() => On.GeoControl.Start += Start;

        private void Start(On.GeoControl.orig_Start orig, GeoControl self)
        {
            for(int i=0;i<self.sizes.Length;i++)
            {
				self.sizes[i].value*=gs.Multiplier;
            }
			orig(self);
        }

        public void Unload() => On.GeoControl.Start -= Start;

	}
}
