using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using Smod2.Lang;
using Pro079Core;

// Change Pro079Template pressing Ctrl+R Ctrl+R in Visual Studio to whatever you like
namespace Pro079Template
{
	#region Command region
	[PluginDetails(
		author = "Joe",
		name = "Template Pro079",
		description = "This is the default template description for a generic Pro079 command.",
		id = "joe.pro079.template",
		configPrefix = "p079_joe",
		langFile = "pro079template",
		version = "1.0",
		SmodMajor = 3,
		SmodMinor = 5,
		SmodRevision = 0
		)]
	public class Pro079Plugin : Plugin
	{
		// Recommended stuff you should have, but not needed.
		[ConfigOption]
		public readonly bool enable = true;
		[ConfigOption]
		public readonly int cooldown = 30;
		[ConfigOption]
		public readonly int cost = 50;
		[ConfigOption]
		public readonly int level = 2;

		// Language options, again, not needed, but recommended. Watch out for \n's, test everything by yourself but I'd say use blabla = @"My Default String"
		
		// REMEMBER: When changing the name of the variables, use Ctrl+R Ctrl+R!

		[LangOption] // Recommended to have one, but please, DON'T use any other name that has already been used.
					 // Smod2 takes the "templatecmd" for every single file, so you *must* change this for safety reasons.
		public readonly string templatecmd = "gate";
		[LangOption] // Only use this if your plugin needs extra arguments: this is just visual.
		public readonly string templateExtra = "<a/b>";
		[LangOption] // Really recommended, and if you check the Command class you will see why.
		public readonly string templateUsage = "Opens or shut a certain gate (A or B)";
		[LangOption] // This will only be used in case someone inputs the command wrongly (a.k.a. there's an error from the user)
		public readonly string templateUsageError = "Usage: .079 gate (a/b) - Cost: $min AP";
		[LangOption]
		public readonly string templateReady = "<b><color=\"green\">Gate command ready</color></b>";

		public override void OnDisable() =>
			this.Info($"Disabled Pro079 {templatecmd.ToUpperInvariant()}");

		public override void OnEnable() =>
			this.Info($"Enabled Pro079 {templatecmd.ToUpperInvariant()}");
		public override void Register()
		{
			// This is how you register the command
			Pro079.Manager.RegisterCommand(new Pro079Command(this));
			// Since no event is registered, we don't need anything else
		}
	}
	#endregion

	#region Ultimate region
	[PluginDetails(
		author = "Joe",
		name = "Template Pro079 Ultimate",
		description = "This is the default template description for a generic Pro079 ultimate.",
		id = "joe.pro079.templateUltimate",
		configPrefix = "p079_joeult",
		langFile = "pro079template",
		version = "1.0",
		SmodMajor = 3,
		SmodMinor = 5,
		SmodRevision = 0
		)]
	public class Pro079UltimatePlugin : Plugin
	{
		// Recommended stuff you should have, but not needed.
		[ConfigOption]
		public readonly bool enable = true;
		[ConfigOption]
		public readonly int cost = 50;
		[ConfigOption]
		public readonly int cooldown = 60;

		[LangOption]
		public readonly string info = "This bad boy can basically destroy every single door", yeetus = "yoyoyo you yeeted the doors, absolute mad man";
		public override void OnDisable()
		{
			this.Info("Finally 079 will stop breaking the doors.");
		}

		public override void OnEnable()
		{
			Info("079 can now break doors with an ultimate, lol");
		}

		public override void Register()
		{
			// Proper way of registering a class with multiple interfaces.
			Pro079Ultimate ultimate = new Pro079Ultimate(this);
			AddEventHandlers(ultimate);
			Pro079.Manager.RegisterUltimate(ultimate);
		}
	}
	#endregion
}