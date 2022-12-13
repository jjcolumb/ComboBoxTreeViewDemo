using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ComboBoxTreeViewDemo.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Category : BaseObject
    {
        public Category(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        Category parent;
        [Association("CategoryParent-CategoryChildren")]
        public Category Parent
        {
            get => parent;
            set => SetPropertyValue(nameof(Parent), ref parent, value);
        }

        [Association("CategoryParent-CategoryChildren")]
        public XPCollection<Category> Children
        {
            get
            {
                return GetCollection<Category>(nameof(Children));
            }
        }
    }
}