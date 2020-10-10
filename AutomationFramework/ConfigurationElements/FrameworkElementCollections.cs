using System.Configuration;

namespace AutomationFramework.ConfigurationElements
{

    /* Description
    */

    [ConfigurationCollection(typeof(FrameworkElements), AddItemName = "testSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class FrameworkElementCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new FrameworkElements();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as FrameworkElements).TestName;
        }

        public new FrameworkElements this[string type] => (FrameworkElements)base.BaseGet(type);
    }
}
