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
        private bool _collectingChildren; // Children might re-render themselves arbitrarily. We only want to capture them at a defined time.

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                //imitate re-render on data getting callback
                StateHasChanged();
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