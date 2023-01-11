using Microsoft.AspNetCore.Components;
using SampleProject.Sample.Data;

namespace SampleProject.Sample.Components
{
    public partial class ChildComponentBase
    {
        [CascadingParameter]
        public ParentComponent Parent { get; set; } = default !;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public SampleEnum SampleEnum { get; set; }
    }
}