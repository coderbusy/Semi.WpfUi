<Query Kind="Statements">
  <NuGetReference>LuYao.Common</NuGetReference>
  <Namespace>LuYao.Text</Namespace>
</Query>

var dir = Path.GetDirectoryName(Util.CurrentScriptPath);
string[] names =
[
	"Primary","Secondary","Tertiary","Quaternary",
	"Success","Warning","Danger",
	"Mark", "Underline","Delete",
	"Disabled",
	"Large","Small",
	"H1","H2","H3","H4","H5","H6"
];
var cs = new CSharpStringBuilder();
cs.AddUsing("Semi.WpfUi.Data", "System.Windows");

cs.AppendLine();
cs.SetNamespace("Semi.WpfUi.Attached");
cs.AppendLine();
using (cs.PublicClassScope("Classes"))
{
	foreach (var n in names)
	{
		cs.AppendLine();
		cs.AppendLine($"public static readonly DependencyProperty {n}Property = DependencyProperty.RegisterAttached(");
		using (cs.Tab()) cs.AppendLine(string.Format("\"{0}\", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));", n));
		cs.AppendLine();
		cs.AppendLine($"public static void Set{n}(DependencyObject element, bool value)");
		using (cs.Tab()) cs.AppendLine($"=> element.SetValue({n}Property, ValueBoxes.BooleanBox(value));");
		cs.AppendLine();
		cs.AppendLine($"public static bool Get{n}(DependencyObject element)");
		using (cs.Tab()) cs.AppendLine($"=> (bool)element.GetValue({n}Property);");
		cs.AppendLine();
	}
}
var str = cs.ToString();
File.WriteAllText(Path.Combine(dir, "Classes.cs"), str, Encoding.UTF8);