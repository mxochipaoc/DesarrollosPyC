using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace DesarrollosPyC.DescargaCfdiSat
{
    /// <summary>
    /// Clase perteneciente al tratado de algunos elementos http
    /// </summary>
    public static class Helper_HtmlElements
    {
        /// <summary>
        /// Genera la función de javascript de recuperación de valor de etiqueta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string getElementValueById_Js_String(string id)
        {
            return @"
            (function() {
                var element = document.getElementById('" + id + @"');
                if (element != undefined) 
                    return element.value;
                else
                    return '';
            })();";
        }

        /// <summary>
        /// Genera la función de javascript de recuperación de contenido de etiqueta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string getElementInnnrHtmlById_Js_String(string id)
        {
            return @"
            (function() {
                var element = document.getElementById('"+ id+ @"');
                if (element != undefined) 
                    return element.innerHTML;
                else
                    return '';
            })();";
        }

        // <summary>
        /// Genera la función de javascript de recuperación de attributo de etiqueta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string getElementAttibuteById_Js_String(string id, string attribute)
        {
            return @"
            (function() {
                var element = document.getElementById('" + id + @"');
                if (element != undefined)  {
                    return element.getAttribute('" + attribute + @"');;
                }
                else
                    return '';
            })();";
        }

        /// <summary>
        /// Recupera el resultado de un javascript
        /// </summary>
        /// <param name="browser">Navegador</param>
        /// <param name="js">Script</param>
        /// <param name="timeout_seconds">Tiempo de expera del script</param>
        /// <returns>Valor recuperado</returns>
        public static object getJavascriptResponse_By_Js(ChromiumWebBrowser browser, string js, long timeout_seconds)
        {
            var task = browser.EvaluateScriptAsync(js, TimeSpan.FromSeconds(timeout_seconds));
            task.Wait();
            var response = task.Result;
            object value = response.Success ? (response.Result ?? "") : response.Message;
            return value;
        }

        /// <summary>
        /// Genera script de actualziación de valor de elemento html
        /// </summary>
        /// <param name="id">Id de elemento</param>
        /// <param name="new_value">Nuevo valor</param>
        /// <returns></returns>
        public static string getResultScriptUpdateElementValue(string id, string new_value)
        {
            return @"
            (function() {
                var element = document.getElementById('" + id + @"'); 
                if(element != undefined) {
                    element.value = '" + new_value + @"';
                    return true;
                }
                else
                    return false;
            })();"; 
        }
    }
}

