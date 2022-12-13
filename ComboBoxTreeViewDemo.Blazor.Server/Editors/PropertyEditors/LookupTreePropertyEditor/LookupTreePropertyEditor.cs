using ComboBoxTreeViewDemo.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraPrinting.Native;

namespace ComboBoxTreeViewDemo.Blazor.Server.Editors.PropertyEditors.LookupTreePropertyEditor
{
    [PropertyEditor(typeof(Category), "LookupTreePropertyEditor", false)]
    public class LookupTreePropertyEditor : BlazorPropertyEditorBase, IComplexViewItem
    {
        public LookupTreePropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() => new LookupTreeAdapter(new LookupTreeModel());

        internal CollectionSourceBase collectionSource;
        LookupEditorHelper helper;

        private IObjectSpace objectSpace;
        private XafApplication application;

        #region IComplexViewItem Members
        void IComplexViewItem.Setup(IObjectSpace objectSpace,
    XafApplication application)
        {
            this.objectSpace = objectSpace;
            this.application = application;

            helper = new LookupEditorHelper(application, objectSpace, MemberInfo.MemberTypeInfo, Model);

        }
        #endregion

        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            ((LookupTreeAdapter)Control).ComponentModel.Categories = objectSpace.GetObjects<Category>();

            ListView listView = helper.CreateListView(CurrentObject);
            collectionSource = listView.CollectionSource;
            collectionSource.CollectionChanged += CollectionSource_CollectionChanged;
        }

        //HACK: This event fires every time the datasource from the View is refreshed. In order to avoid Disposed object error from the DxTreeView component,
        //a reset of its datasource is necessary
        private void CollectionSource_CollectionChanged(object sender, EventArgs e)
        {
            ((LookupTreeAdapter)Control).ComponentModel.Categories = objectSpace.GetObjects<Category>();
        }
    }
}
