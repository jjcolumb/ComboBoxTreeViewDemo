using ComboBoxTreeViewDemo.Blazor.Server.Editors.PropertyEditors.LookupTreePropertyEditor;
using ComboBoxTreeViewDemo.Module.BusinessObjects;
using ComboBoxTreeViewDemo.Blazor.Server;
using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Core;
using DevExpress.Pdf.Native.DocumentSigning;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ComboBoxTreeViewDemo.Blazor.Server.Components
{
    public class ComboBoxTreeViewBase : ComponentBase
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; } = null!;
        
        [Parameter]
        public LookupTreeModel ComponentModel { get; set; }

        protected DxDropDown ComboBoxDropDown;
        protected DxTreeView ComboBoxTreeView;


        protected bool DropDownIsOpen { get; set; } = false;
        protected Category ComboBoxValue { get; set; }

        protected void OnDropDownVisibleChanges(bool value)
        {
            if (value)
            {
                DropDownIsOpen = !DropDownIsOpen;
            }
        }

        protected void OnComboBoxTreeViewSelectionChanged(TreeViewNodeEventArgs e)
        {
            Category selectedCategory = e.NodeInfo?.DataItem as Category;
            ComponentModel.Value = selectedCategory;
            ComponentModel.SetValueFromUI(selectedCategory);

            ComboBoxDropDown.CloseAsync();
        }

        protected void OnComboBoxValueChanged(Category category)
        {
            
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //GetWithfromFather();
        }

        protected async Task GetWithfromFather()
        {
            await JSRuntime.InvokeVoidAsync("SetTreeWidht");
        }
    }
}
