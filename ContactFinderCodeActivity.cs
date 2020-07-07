using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;

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
        [RequiredArgument]
        [Input("String input")]
        public InArgument<string> Parameter1Input { get; set; }
        [RequiredArgument]
        [Input("String input")]
        public InArgument<string> Parameter1FieldNameInput { get; set; }
        [RequiredArgument]
        [Input("String input")]
        public InArgument<string> Parameter2Input { get; set; }
        [RequiredArgument]
        [Input("String input")]
        public InArgument<string> Parameter2FieldNameInput { get; set; }
        [Output("Integer output")]
        public OutArgument<int> StatusOutput { get; set; }
        [Output("EntityReference output")]
        public OutArgument<int> ContactReferenceOutput { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();             
            IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.InitiatingUserId);
            var query = new QueryExpression("connection");
            query.Criteria.AddCondition(new ConditionExpression(Parameter1FieldNameInput.Get(context), ConditionOperator.Equal, Parameter1Input.Get(context)));
            query.Criteria.AddCondition(new ConditionExpression(Parameter2FieldNameInput.Get(context), ConditionOperator.Equal, Parameter2Input.Get(context)));
            query.ColumnSet = new ColumnSet(true);
            var results = service.RetrieveMultiple(query);
            int count = results.TotalRecordCount;
            if (count==0)
            {
                StatusOutput.Set(context, 2);
            }
            else if (count == 1)
            {
                StatusOutput.Set(context, 0);
                ContactReferenceOutput.Set(context, results.Entities.FirstOrDefault().ToEntityReference());
            }
            else
            {
                StatusOutput.Set(context, 3);
            }
        }
    }
}
