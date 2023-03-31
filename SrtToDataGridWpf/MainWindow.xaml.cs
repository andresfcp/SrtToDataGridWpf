using SrtToDataGridWpf.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace SrtToDataGridWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarSrt();
        }

        private void CargarSrt()
        {
            //creamos una lista de Subtitulos, en la cual vamos a guardar los datos del srt
            List<Subtitulos> subtitulos = new List<Subtitulos>();

            using (StreamReader sr = new StreamReader("media\\archivo.srt", Encoding.Latin1))
            {
                string? line;

                // Mientras haya líneas por leer en el archivo SRT
                while ((line = sr.ReadLine()) != null)
                {
                    // Si la línea leida es un número de secuencia
                    if (int.TryParse(line, out int id))
                    {
                        // Leemos la siguiente línea que contiene el tiempo de inicio y fin del subtítulo
                        string? tiempo = sr.ReadLine();

                        // Dividimos el tiempo en las partes de inicio y fin utilizando el carácter " --> "
                        string[] partes = tiempo?.Split(new[] { " --> " }, StringSplitOptions.None) ?? new string[0];

                        // Creamos un nuevo objeto Subtitulos con las propiedades de Id, Inicio y Fin
                        Subtitulos subtitulo = new Subtitulos
                        {
                            Id = id,
                            Inicio = partes.Length > 0 ? partes[0] : null,
                            Fin = partes.Length > 1 ? partes[1] : null,
                            Subtitulo = null
                        };

                        // Leemos las líneas de texto del subtítulo hasta que encontremos una línea en blanco o lleguemos al final del archivo
                        string texto = string.Empty;
                        while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
                        {
                            texto += line + "\n";
                        }

                        // Asignamos la propiedad Subtitulo con la primera línea del texto y la propiedad TextoCompleto con todo el texto del subtítulo
                        subtitulo.Subtitulo = texto.Trim();

                        // Agregamos el objeto Subtitles a la lista de subtítulos
                        subtitulos.Add(subtitulo);
                    }
                }
            }
            // Se hace la asignación de la lista de subtitulos al dataGrid
            dataGrid.ItemsSource = subtitulos;

        }
    }
}
