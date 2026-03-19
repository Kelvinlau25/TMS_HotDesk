using Object;
using System.Collections.Generic;
using System.Web;

namespace Control
{
    /// <summary>
    /// Component Binding 
    /// ----------------------------------------------
    /// C.C.Yeon    16 April 2012   initial version
    /// </summary>
    public class Binding
    {
        public static void BindDropDownListResource(System.Web.UI.WebControls.DropDownList DDL, string ResourceName, string Text = "", string Value = "")
        {
            // FIX: Replace Binder.Deserializer with a method that converts the resource string to List<Binder>
            var resourceString = HttpContext.GetGlobalResourceObject("SearchSource", ResourceName) as string;
            List<Binder> binders = DeserializeBinderList(resourceString);
            DDL.DataSource = binders;
            DDL.DataTextField = "Text";
            DDL.DataValueField = "Value";
            DDL.DataBind();
            AddList(DDL, Text, Value);
        }

        public static void BindDropDownList(System.Web.UI.WebControls.DropDownList DDL, List<Binder> list, string Text = "", string Value = "")
        {
            if (list.Count > 0)
            {
                DDL.DataSource = list;
                DDL.DataTextField = "Text";
                DDL.DataValueField = "Value";
                DDL.DataBind();
            }
            AddList(DDL, Text, Value);
        }

        private static void AddList(System.Web.UI.WebControls.DropDownList ddl, string Text, string Value)
        {
            if (Value != string.Empty)
            {
                ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem(Text, Value));
            }
        }

        // Add this method to handle deserialization of the resource string to List<Binder>
        private static List<Binder> DeserializeBinderList(string resourceString)
        {
            // Example: If resourceString is a JSON array, use System.Text.Json or Newtonsoft.Json
            // return JsonConvert.DeserializeObject<List<Binder>>(resourceString);
            // For now, return an empty list if resourceString is null or empty
            if (string.IsNullOrEmpty(resourceString))
            {
                return new List<Binder>();
            }
            // TODO: Implement actual deserialization logic based on your resource format
            return new List<Binder>();
        }
    }
}
