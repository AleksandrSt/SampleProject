using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SampleProject.Sample.Components
{
    // This is used to move its body rendering to the end of the render queue so we can collect
    // the list of child components first.
    public class Defer : ComponentBase
	{
		[Parameter]
		public RenderFragment ChildContent { get; set; }

		protected override void BuildRenderTree( RenderTreeBuilder builder )
		{
			builder.AddContent( 0, ChildContent );
		}
	}
}
