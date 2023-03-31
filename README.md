# Srt To DataGrid WPF

Ejemplo simple para cargar un archivo srt de subtitulos en un DataGrid en un proyecto de WPF.

Lo primero que debemos tener en cuenta es que necesitamos una clase para maenjar los subtítulos.
```csharp
internal class Subtitulos
{
	public int? Id { get; set; }
	public string? Inicio { get; set; }
	public string? Fin { get; set; }
	public string? Subtitulo { get; set; }
}
```

En el archivo XAML debemos agregar dentro de la etiqueta Grid:
```xml
<DataGrid x:Name="dataGrid" AutoGenerateColumns="False" AlternatingRowBackground="LightGreen"
                  FontFamily="Arial Unicode MS">
	<DataGrid.Columns>
		<DataGridTextColumn Header="Id" Binding="{Binding Id}" />
		<DataGridTextColumn Header="Inicio" Binding="{Binding Inicio}" />
		<DataGridTextColumn Header="Fin" Binding="{Binding Fin}" />
		<DataGridTextColumn Header="Subtitulo" Binding="{Binding Subtitulo}">
	</DataGridTextColumn>
</DataGrid.Columns>
```

En el código de C# se encuentra todo muy bien explicado.
