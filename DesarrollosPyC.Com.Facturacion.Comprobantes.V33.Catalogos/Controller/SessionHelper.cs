using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller
{
    public class SessionHelper
    {
        /// <summary>
        /// Sesión fabricada
        /// </summary>
        static ISessionFactory Session { get; set; }
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        static SessionHelper()
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                string datapath = path + "\\App_Data";
                if (!System.IO.Directory.Exists(datapath))
                {
                    System.IO.Directory.CreateDirectory(datapath);
                    using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.App_Data.cfdi33.db"))
                    {
                        using (System.IO.FileStream file = System.IO.File.Create(datapath + "\\cfdi33.db", (int)stream.Length))
                        {
                            byte[] bytesInStream = new byte[stream.Length];
                            stream.Read(bytesInStream, 0, bytesInStream.Length);
                            file.Write(bytesInStream, 0, bytesInStream.Length);
                            file.Close();
                        }
                    }
                }

                Session = FluentNHibernate.Cfg.Fluently.Configure()
                    .Database(FluentNHibernate.Cfg.Db.SQLiteConfiguration.Standard
                        .UsingFile( datapath + "\\cfdi33.db")
                        )
                    .Mappings(m => m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.Load("DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos")))
                    .BuildSessionFactory();
            }
            catch(Exception ex)
            {
            }
        }
        
        /// <summary>
        /// Genera una nueva sesión en base de datos
        /// </summary>
        /// <returns>Sessión</returns>
        public static ISession GetNewSession()
        {
            return Session.OpenSession();
        }

        /// <summary>
        /// Recupera la sesión actual con la base de datos
        /// </summary>
        /// <returns>Sesión</returns>
        public static ISession GetCurrentSession()
        {
            return Session.GetCurrentSession();
        }

        /// <summary>
        /// Sesión con base de datos
        /// </summary>
        static ISession session;
        /// <summary>
        /// Sesión con base de datos
        /// </summary>
        public static ISession _Session
        {
            get
            {
                if (session == null)
                {
                    session = GetNewSession();

                    session.CacheMode = CacheMode.Normal;
                    session.FlushMode = FlushMode.Always;
                }

                return session;
            }
        }
    }
}