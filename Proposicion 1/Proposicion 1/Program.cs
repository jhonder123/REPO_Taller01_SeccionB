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
        // DESAFIO 1: EL VALIDADOR
			Console.WriteLine("Ejecutando El Primer Desafio");
			
			string cadena = "Jhonder;clave123"; 
			string [] partes = cadena.Split(';');
			string clave = partes[1];
			
			if (clave.Contains("123"))
			{
				StreamWriter archivoSeguridad = new StreamWriter("Seguridad.txt", true);
				archivoSeguridad.WriteLine("Clave Débil Detectada");
				archivoSeguridad.Close();
				Console.WriteLine("Aviso De Seguridad Guardado");
			}
			
			
			// DESAFIO 2: EL CLONADOR
			Console.WriteLine("Copiando La Foto...");
			
			if (File.Exists("avatar.jpg"))
			{
				FileStream origen = new FileStream("avatar.jpg", FileMode.Open);
				FileStream destino = new FileStream("respaldo.jpg", FileMode.Create);
				
				byte [] buffer = new byte[1024];
				int leido;
				
				// Este bucle copia byte a byte
				while ((leido = origen.Read(buffer, 0, buffer.Length)) > 0)
				{
					destino.Write(buffer, 0, leido);
				}
				
				origen.Close();
				destino.Close();
				Console.WriteLine("La Imagen Se Copio Correctamente");
			}
			
			
			// DESAFIO 3: EL BUSCADOR DE ARCHIVOS
			Console.WriteLine("Borrando Archivos Pesados");
			
			string carpetaActual = Directory.GetCurrentDirectory();
			string[] listaArchivos = Directory.GetFiles(carpetaActual);
			
			foreach (string archivo in listaArchivos)
			{
				FileInfo info = new FileInfo(archivo);
				
				// 5120 es el numero de bytes en 5KB
				if (info.Length > 5120)
				{
					// IMPORTANTE: No borrar el ejecutable ni la imagen original
					if (info.Name != "Proposicion 1.exe" && info.Name != "avatar.jpg")
					{
						info.Delete();
						Console.WriteLine("Archivo Borrado: " + info.Name);
					}
				}
			}
			
			Console.WriteLine("Ya Termino Todo El Proceso");
			Console.ReadLine(); // Para que no se cierre la ventana
    	}
	}
}