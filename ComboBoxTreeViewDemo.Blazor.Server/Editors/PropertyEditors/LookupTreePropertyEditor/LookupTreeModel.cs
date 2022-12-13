using ComboBoxTreeViewDemo.Module.BusinessObjects;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.Persistent.BaseImpl;
using System.Collections;

namespace ComboBoxTreeViewDemo.Blazor.Server.Editors.PropertyEditors.LookupTreePropertyEditor
{
    public class LookupTreeModel : ComponentModelBase
    {
        public Category Value
        {
            get => GetPropertyValue<Category>();
            set => SetPropertyValue(value);
        }

        public IList<Category> Categories
        {
            get => GetPropertyValue<IList<Category>>();
            set => SetPropertyValue(value);
        }
        

        public bool ReadOnly
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }

        public void SetValueFromUI(Category value)
        {
            SetPropertyValue(value, notify: false, nameof(Value));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }
}
