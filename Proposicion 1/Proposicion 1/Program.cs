/*
 * Creado por SharpDevelop.
 * Usuario: Jhonder Abreu
 * Fecha: 18/4/2026
 * Hora: 2:50 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace Proposicion_1
{
	class DesafiosIngenieria
{
    static void Main(string[] args)
    {
        // Validar Clave
			Console.WriteLine("Ejecutando El Primer Desafio");
			
			string cadena = "Jhonder;Clave123"; 
			string [] partes = cadena.Split(';');
			string clave = partes[1];
			
			if (clave.Contains("123"))
			{
				StreamWriter archivoSeguridad = new StreamWriter("Seguridad.txt", true);
				archivoSeguridad.WriteLine("Clave Débil Detectada");
				archivoSeguridad.Close();
				Console.WriteLine("Aviso De Seguridad Guardado");
			}
			
			
			// Clonar Imagen
			Console.WriteLine("Copiando La Foto...");
			
			if (File.Exists("avatar.jpg"))
			{
				FileStream origen = new FileStream("avatar.jpg", FileMode.Open);
				FileStream destino = new FileStream("respaldo.jpg", FileMode.Create);
				
				byte [] buffer = new byte[1024];
				int leido;
				
				while ((leido = origen.Read(buffer, 0, buffer.Length)) > 0)
				{
					destino.Write(buffer, 0, leido);
				}
				
				origen.Close();
				destino.Close();
				Console.WriteLine("La Imagen Se Copio Correctamente");
			}
			
			
			// Buscar y Borrar Archivos
			Console.WriteLine("Borrando Archivos Pesados");
			
			string carpetaActual = Directory.GetCurrentDirectory();
			string[] listaArchivos = Directory.GetFiles(carpetaActual);
			
			foreach (string archivo in listaArchivos)
			{
				FileInfo info = new FileInfo(archivo);
				
				if (info.Length > 5120)
				{
					if (info.Name != "Proposicion 1.exe" && info.Name != "avatar.jpg")
					{
						info.Delete();
						Console.WriteLine("Archivo Borrado: " + info.Name);
					}
				}
			}
			
			Console.WriteLine("Ya Se Terminaron Todos Los Procesos");
			Console.ReadLine();
    	}
	}
}