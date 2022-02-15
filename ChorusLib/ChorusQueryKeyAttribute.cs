using System;

namespace ChorusLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ChorusQueryKeyAttribute : Attribute
    {
        public string Key { get; }
        public bool Quoted { get; set; }

        public ChorusQueryKeyAttribute(string key)
        {
            this.Key = key;
            this.Quoted = false;
        }
    }
}