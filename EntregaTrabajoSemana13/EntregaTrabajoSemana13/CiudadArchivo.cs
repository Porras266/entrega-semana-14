﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace EntregaTrabajoSemana13
{
    internal class Ciudad_Archivo
    {
        public void GUardarArchivo(List<Ciudad> ciudades, string RutaArchivo)
        {
            using (FileStream archivo = new FileStream(RutaArchivo, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivo))
                {
                    foreach (Ciudad c in ciudades)
                    {
                        escritor.Write(c.ID);
                        escritor.Write(c.Nombre.Length);
                        escritor.Write(c.Nombre.ToCharArray());

                    
                    }
                
                }
            
            }
        
        }

        public List<Ciudad> CargarCiudades(string rutaArchivo)
        { 
            List<Ciudad> ciudades = new List<Ciudad>();
            if (!File.Exists(rutaArchivo))
            { 
                return ciudades;
            }

            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivo))
                {
                    while (archivo.Position != archivo.Length)
                    {
                        int id = lector.ReadInt32();
                        int Tamaño = lector.ReadInt32();
                        char[] nombreArray = lector.ReadChars(Tamaño);
                        string nombre = new string(nombreArray);

                        Ciudad ciudad = new Ciudad();
                        ciudad.ID = id;
                        ciudad.Nombre = nombre;
                        ciudades.Add(ciudad);
                    }            
                }            
            }
            return ciudades;
        }
    }  
}