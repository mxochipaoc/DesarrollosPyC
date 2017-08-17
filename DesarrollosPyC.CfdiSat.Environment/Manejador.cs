using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.CfdiSat.Environment
{
    /// <summary>
    /// Manejador de carga automática de licencias
    /// </summary>
    public static class Manejador
    {
        /// <summary>
        /// Carga las licencias encontradas en la ruta especificada
        /// </summary>
        /// <param name="path">Ruta de licencias</param>
        public static void CargaLicencias(string path = "")
        {
            if (!System.IO.Directory.Exists(path))
            {
                if (!System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\Lics"))
                    System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\Lics");

                Aplicacion.DirectorioLicencias = System.IO.Directory.GetCurrentDirectory() + "\\Lics";
            }
            else
                Aplicacion.DirectorioLicencias = path;

            string[] lics = System.IO.Directory.GetFiles(Aplicacion.DirectorioLicencias, "*.lic", System.IO.SearchOption.TopDirectoryOnly);
            List<DesarrollosPyC.Com.Licencias.Class.Licencia> finds = new List<Com.Licencias.Class.Licencia>();
            foreach (var l in lics)
            {
                try
                {
                    string data = string.Empty;
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(l))
                    {
                        data = reader.ReadToEnd();
                        reader.Close();
                    }
                    if (!string.IsNullOrWhiteSpace(data))
                    {
                        var lic = DesarrollosPyC.Com.Licencias.Managers.M_Licencia.GeneraLicenciaObj(data.Split(new char[] { '\n' }));
                        if (lic != null)
                        {
                            lic.FechaCargaEnSistema = DateTime.Today;
                            var d = (lic.FechaCargaEnSistema.Value - lic.FechaEmision).Days;
                            if (d > lic.DiasOcupado)
                            {
                                lic.DiasOcupado = d;
                                string lines = DesarrollosPyC.Com.Licencias.Managers.M_Licencia.GeneraLicenciaFile(lic).ToString().Trim();
                                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(l))
                                {
                                    writer.Write(lines);
                                    writer.Flush();
                                    writer.Close();
                                }
                            }

                            if (lic.FechaVigencia >= DateTime.Today && lic.DiasOcupado <= (lic.FechaVigencia - lic.FechaEmision).Days)
                            {
                                finds.Add(lic);
                            }
                        }
                    }
                }
                finally
                {
                    // No hace nada
                }
            }

            Aplicacion.Licencias = finds.ToArray();
        }
    }
}
