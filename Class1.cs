using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace ContactFinderCodeActivity
{
    public class ContactFinder : CodeActivity
    {
        /// <summary>
        /// Activity paramtr:
        /// Parameter1Input - contact first field value
        /// Parameter1FieldNameInput - contact first field name
        /// Parameter2Input - contact second field value
        /// Parameter2FieldNameInput - contact second field name
        /// Output:
        /// StatusOutput - 1 - find, 2-not found, 3-more then 1 contact found
        /// ContactReferenceOutput - reference to contact
        /// </summary>
        [Input("String input")]
        public InArgument<string> Parameter1Input { get; set; }
        [Input("String input")]
        public InArgument<string> Parameter1FieldNameInput { get; set; }
        [Input("String input")]
        public InArgument<string> Parameter2Input { get; set; }
        [Input("String input")]
        public InArgument<string> Parameter2FieldNameInput { get; set; }
        [Output("Integer output")]
        public OutArgument<int> StatusOutput { get; set; }
        [Output("EntityReference output")]
        public OutArgument<int> ContactReferenceOutput { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
