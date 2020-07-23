using Exiled.API.Interfaces;

namespace Pro079Template
{
    public sealed class Pro079PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;

		// Recommended stuff you should have, but not needed.
		public int Cooldown { get; set; } = 30;
		public int Cost { get; set; } = 50;
		public int Level { get; set; } = 2;

		// Language Options
		public Pro079PluginTranslations Translations { get; set; } = new Pro079PluginTranslations();		
	}

	public sealed class Pro079PluginTranslations
    {
		// Language options, again, not needed, but recommended. Watch out for \n's, test everything by yourself but I'd say use blabla = @"My Default String"

		// REMEMBER: When changing the name of the variables, use Ctrl+R Ctrl+R!

		public string TemplateCmd { get; set; } = "gate";
		// Only use this if your plugin needs extra arguments: this is just visual.
		public string TemplateExtra { get; set; } = "<a/b>";
		// Really recommended, and if you check the Command class you will see why.
		public string TemplateUsage { get; set; } = "Opens or shut a certain gate (A or B)";
		// This will only be used in case someone inputs the command wrongly (a.k.a. there's an error from the user)
		public string TemplateUsageError { get; set; } = "Usage: .079 gate (a/b) - Cost: $min AP";
		public string TemplateReady { get; set; } = "<b><color=\"green\">Gate command ready</color></b>";
	}

    public sealed class Pro079UltimateConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;

		// Recommended stuff you should have, but not needed.
		public int Cost { get; set; } = 50;
		public int Cooldown { get; set; } = 60;

		public Pro079UltimateTranslations Translations = new Pro079UltimateTranslations();
    }

	public sealed class Pro079UltimateTranslations
    {
		public string Info { get; set; } = "This bad boy can basically destroy every single door";
		public string Yeetus { get; set; } = "yoyoyo you yeeted the doors, absolute mad man";
	}
}
