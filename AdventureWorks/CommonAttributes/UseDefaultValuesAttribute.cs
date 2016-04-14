using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.CommonAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =true)]
    public class UseDefaultValuesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var defaults = GetDefaults(filterContext);
            var actionParameters = filterContext.ActionParameters;
            foreach (var value in defaults)
                if (actionParameters[value.Key] == null)
                    actionParameters[value.Key] = value.Value;
        }

        internal static IDictionary<string, object> GetDefaults(ActionExecutingContext filterContext)
        {
            string key = filterContext.ActionDescriptor.ToString() + "_ParameterDefaults";

            // get from application storage
            IDictionary<string, object> defaults = filterContext.HttpContext.Application[key] as IDictionary<string, object>;

            if (defaults == null)
            {
                defaults = new Dictionary<string, object>(filterContext.ActionParameters.Count);
                foreach (var parameter in filterContext.ActionDescriptor.GetParameters())
                {
                    if (parameter.IsDefined(typeof(DefaultAttribute), false))
                    {
                        DefaultAttribute attr = parameter.GetCustomAttributes(typeof(DefaultAttribute), false)[0] as DefaultAttribute;
                        string parameterName = parameter.ParameterName;
                        string actionName = filterContext.ActionDescriptor.ActionName;

                        try
                        {
                            defaults.Add(parameterName, attr.Default); //ConvertParameterType(attr.Default, parameter.ParameterType, parameterName, actionName));
                        }
                        catch (Exception exc)
                        {
                            throw new InvalidOperationException($"The value of the DefaultAttribute could not be converted to the parameter '{parameterName}' in action '{actionName}'.", exc);
                        }
                    }
                }

                // add to application storage
                filterContext.HttpContext.Application[key] = defaults;
            }

            return defaults;
        }
    }
}