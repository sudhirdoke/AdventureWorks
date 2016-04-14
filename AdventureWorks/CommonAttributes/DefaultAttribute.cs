using System;


namespace AdventureWorks.CommonAttributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class DefaultAttribute : Attribute 
    {
        public DefaultAttribute(object @default)
        {
            if (@default == null)
                throw new ArgumentNullException("default");

            Default = @default;
        }

        public object Default
        {
            get;
            private set;
        }

        
    }
}