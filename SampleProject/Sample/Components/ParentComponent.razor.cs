using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;

namespace SampleProject.Sample.Components
{
    public partial class ParentComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private List<ChildComponentBase> _childComponents = new();
        private bool _firstRender = true;
        private bool _collectingChildren; // Children might re-render themselves arbitrarily. We only want to capture them at a defined time.

        protected async Task ProcessDataAsync()
        {
            if (_firstRender)
            {
                //imitating re-render just like it would be an async call
                await InvokeAsync(StateHasChanged);
                _firstRender = false;
            }
        }

        public void AddChild(ChildComponentBase child)
        {
            _childComponents.Add(child);
        }

        private void StartCollectingChildren()
        {
            _childComponents.Clear();
            _collectingChildren = true;
        }

        private void FinishCollectingChildren()
        {
            _collectingChildren = false;
        }
    }
}