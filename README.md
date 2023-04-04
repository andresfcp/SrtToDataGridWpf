![SrtToDataGrid](https://user-images.githubusercontent.com/65383172/229676504-fe0dc2d0-825c-4552-bbe8-a48f1b70ed08.jpg)
# Srt To DataGrid WPF

Ejemplo simple para cargar un archivo srt de subtitulos en un DataGrid en un proyecto de WPF.

## Qué es un SRT?
Un archivo SRT es un archivo de texto plano que permite utilizado para  añadir subtítulos a un vídeo después de producido.  Son muy útiles si quiero subtitular un video que he subido a YouTube o por ejemplo si deseas subtitular el video de una reunión de la junta directiva de la empresa.

En la actualidad son bastante útiles programas de inteligencia atrificial como Whisper de OpenAI, puede generar este tipo de archivos luego de procesar un audio o un video.

El siguiete es un ejemplo de cómo se peude ver un archivo SRT en su interior.



    1
    00:01:01,648 --> 00:01:04,732
    BUENOS DÍAS.
    BUENOS DÍAS A TODOS.
    
    2
    00:01:05,262 --> 00:01:08,650
    Damos inicio a la junta directiva número 234
    de Monster's Inc.
    
    3
    00:01:22,751 --> 00:01:26,296
    Vamos a leer el orden del día
    Primero.....

Si miramos el ejemplo anterior vemos que todo subtítulo comienza con un número, que nos indica el indice del subtítulo (2), luego está seguido por el tiempo de incio y final (00:01:05,262 --> 00:01:08,650), es decir en qué momento debe aparecer el subtítulo y en qué momento se debe ocultar y por último en una o varias líneas aparece el texto del subtítulo (Damos inicio a la junta directiva número 234|de Monster's Inc.).

## Comencemos
Este es un proyecto bastante simple y su código esta bien documentado para ser lo más fácil posible.

Ya que sabemos cómo está conformada la estructura de un archivo SRT, lo primero que debemos tener en cuenta es que necesitamos una clase para manejar los subtítulos, siendo esta lo más parecida a nuestra estructura del SRT.

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
